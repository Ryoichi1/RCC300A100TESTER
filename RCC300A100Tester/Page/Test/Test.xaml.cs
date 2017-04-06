using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RCC300A100Tester
{
    /// <summary>
    /// Test.xaml の相互作用ロジック
    /// </summary>
    public partial class Test
    {
        public Test()
        {
            this.InitializeComponent();


            // オブジェクト作成に必要なコードをこの下に挿入します。
            this.DataContext = State.VmTestStatus;
            Canvas検査データ.DataContext = State.VmTestResults;


            (FindResource("Blink") as Storyboard).Begin();

            //試験合格後（１項目試験 or 日常点検）と試験不合格後に、検査ステータス以外をクリアするための処理
            State.testCommand.RefreshDataContext = (() =>
            {
                Canvas検査データ.DataContext = State.VmTestResults;
                tbTestLog.DataContext = State.VmTestStatus;

            });

            //ストーリーボードの初期化
            State.testCommand.SbRingLoad = (() => { (FindResource("StoryboardRingLoad") as Storyboard).Begin(); });
            State.testCommand.SbPass = (() => { (FindResource("StoryboardDecision") as Storyboard).Begin(); });
            State.testCommand.SbFail = (() => { (FindResource("StoryboardDecision") as Storyboard).Begin(); });


        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ////カメラの初期化(フォーム上にカメラ画像を表示している場合下記の処理を行う)
            //State.SetCam0Prop();
            ////Imageの透明度を30%に設定する（非試験時）
            //General.cam0.ImageOpacity = Constants.OpacityMin;
            //img0.DataContext = General.cam0;

            //エラーインフォメーションページからテストページに遷移する場合は、
            //下記のif文を有効にする
            if (Flags.ShowErrInfo)
            {
                Flags.ShowErrInfo = false;
            }
            else
            {
                //フォームの初期化
                SetUnitTest();
                State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Hidden;
                State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Hidden;
                State.VmTestStatus.TestTime = "00:00";
                await State.testCommand.StartCheck();
            }
        }

        private void tbTestLog_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbTestLog.ScrollToEnd();
            //tbTestLog.Select(tbTestLog.Text.Length, 0)
        }

        private void canvasUnitTest_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CheckBoxUnitTest.IsChecked = false;
            cbUnitTest.SelectedIndex = 0;
        }

        private void SetUnitTest()
        {
            var SelectedItem = State.テスト項目.Where(item => item.Key % 100 == 0);
            var list = new List<string>();
            foreach (var t in SelectedItem)
            {
                list.Add(t.Key.ToString() + "_" + t.Value);
            }
            State.VmTestStatus.UnitTestItems = list;

        }

        private void ButtonErrInfo_Click(object sender, RoutedEventArgs e)
        {
            Flags.ShowErrInfo = true;
            State.VmMainWindow.TabIndex = 3;
            App._naviErrInfo.Navigate(State.uriErrInfoPage);
        }
    }
}
