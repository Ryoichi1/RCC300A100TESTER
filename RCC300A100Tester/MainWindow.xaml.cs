using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Threading;
using System.IO;
using System.Reflection;
using System.Threading;

namespace RCC300A100Tester
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow
    {
        DispatcherTimer timerTextInput;

        Uri uriTestPage = new Uri("Page/Test/Test.xaml", UriKind.Relative);
        Uri uriConfPage = new Uri("Page/Config/Conf.xaml", UriKind.Relative);
        Uri uriHelpPage = new Uri("Page/Help/Help.xaml", UriKind.Relative);


        public MainWindow()
        {
            InitializeComponent();
            App._naviTest = FrameTest.NavigationService;
            App._naviConf = FrameConf.NavigationService;
            App._naviHelp = FrameHelp.NavigationService;
            App._naviErrInfo = FrameErrInfo.NavigationService;

            this.MouseLeftButtonDown += (sender, e) => this.DragMove();//ウィンドウ全体でドラッグ可能にする

            this.DataContext = State.VmMainWindow;

            //タイマーの設定
            timerTextInput = new DispatcherTimer(DispatcherPriority.Normal);
            timerTextInput.Interval = TimeSpan.FromMilliseconds(1000);
            timerTextInput.Tick += timerTextInput_Tick;
            timerTextInput.Start();


            GetInfo();

            //カレントディレクトリの取得
            State.CurrDir = Directory.GetCurrentDirectory();

            //試験用パラメータのロード
            State.LoadConfigData();



            //デートコード表記の設定
            var 年 = System.DateTime.Now.ToString("yy");
            var 月 = (Int32.Parse(System.DateTime.Now.ToString("MM")) * 4).ToString("D2");
            var 日 = System.DateTime.Now.ToString("dd");

            //IOボードの初期化
            General.io = new EPX64S();

            General.Init周辺機器();//非同期処理です


            //日常点検が実施されているかの確認
            //Flags.State日常点検 = true;//日常点検サンプルが完成するまでの暫定
            Flags.State日常点検 = General.Check日常点検データ();


            InitMainForm();//メインフォーム初期化

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            ////IOボードの初期化
            //General.io = new EPX64S();

            //General.Init周辺機器();//非同期処理です


            ////日常点検が実施されているかの確認
            ////Flags.State日常点検 = true;//日常点検サンプルが完成するまでの暫定
            //Flags.State日常点検 = General.Check日常点検データ();


            //InitMainForm();//メインフォーム初期化
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            try
            {
                while (Flags.Initializing周辺機器) ;

                if (General.io.Status == EPX64S.EPX64S_OK)
                {
                    General.ResetIo();
                    General.io.Close();//IO閉じる
                }


                if (!State.Save個別データ())
                {
                    MessageBox.Show("個別データの保存に失敗しました");
                }


            }
            catch
            {

            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Flags.Testing)
            {
                e.Cancel = true;
            }
            else
            {
                Flags.StopInit周辺機器 = true;
            }
        }



        void timerTextInput_Tick(object sender, EventArgs e)
        {
            timerTextInput.Stop();
            if (!State.VmMainWindow.SetOpecode)
            {
                State.VmMainWindow.Opecode = "";
            }
        }

        private void cbOperator_DropDownClosed(object sender, EventArgs e)
        {
            if (cbOperator.SelectedIndex == -1)
                return;
            State.VmMainWindow.SetOperator = true;

            if (State.VmMainWindow.SetOpecode)
            {
                SetFocus();
                return;
            }

            tbOpecode.IsReadOnly = false;
            tbOpecode.Focus();
            SetFocus();
        }



        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            if (Flags.Testing) return;
            State.VmMainWindow.SetOperator = false;
            State.VmMainWindow.SetOpecode = false;
            tbOpecode.IsReadOnly = true;
            SetFocus();
        }

        private void tbOpecode_TextChanged(object sender, TextChangedEventArgs e)
        {
            //１文字入力されるごとに、タイマーを初期化する
            timerTextInput.Stop();
            timerTextInput.Start();

            if (State.VmMainWindow.Opecode.Length != 13) return;
            //以降は工番が正しく入力されているかどうかの判定
            if (System.Text.RegularExpressions.Regex.IsMatch(
                State.VmMainWindow.Opecode, @"^\d-\d\d-\d\d\d\d-\d\d\d$",
                System.Text.RegularExpressions.RegexOptions.ECMAScript))
            {
                timerTextInput.Stop();
                State.VmMainWindow.SetOpecode = true;
                tbOpecode.IsReadOnly = true;
                SetFocus();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TabMenu.SelectedIndex = 0;
        }




        //アセンブリ情報の取得
        private void GetInfo()
        {
            //アセンブリバージョンの取得
            var asm = Assembly.GetExecutingAssembly();
            var M = asm.GetName().Version.Major.ToString();
            var N = asm.GetName().Version.Minor.ToString();
            var B = asm.GetName().Version.Build.ToString();
            State.AssemblyInfo = M + "." + N + "." + B;

        }

        //フォームのイニシャライズ
        private void InitMainForm()
        {
            TabErrInfo.Header = "";//実行時はエラーインフォタブのヘッダを空白にして作業差に見えないようにする
            TabErrInfo.IsEnabled = false; //作業差がTABを選択できないようにします

            tbOpecode.IsReadOnly = true;
            State.VmMainWindow.EnableOtherButton = true;

        }

        //フォーカスのセット
        public void SetFocus()
        {
            if (!State.VmMainWindow.SetOperator)
            {
                State.VmTestStatus.Message = Constants.MessOperator;
                //General.PlaySound(General.soundOperator);
                if (!cbOperator.IsFocused)
                    cbOperator.Focus();

                return;
            }


            if (!State.VmMainWindow.SetOpecode)
            {

                State.VmTestStatus.Message = Constants.MessOpecode;
                //General.PlaySound(General.soundOpecode);
                if (!tbOpecode.IsFocused)
                    tbOpecode.Focus();
                return;
            }


        }


        private void TabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = TabMenu.SelectedIndex;
            if (index == 0)
            {
                if (Flags.ShowErrInfo)//エラーインフォページから遷移してきた場合は何もしない（非同期でTestCommandのTESTメソッドが動いている）
                {
                    return;
                }

                Flags.OtherPage = false;//フラグを初期化しておく

                Task.Run(() =>
                {
                    Flags.ReturnFromOtherPage = false;
                    while (true)
                    {
                        if (!General.CheckPress())
                        {
                            Flags.ReturnFromOtherPage = true;
                            break;
                        }
                        Thread.Sleep(200);
                    }
                });

                App._naviTest.Navigate(uriTestPage);
                SetFocus();//テスト画面に移行する際にフォーカスを必須項目入力欄にあ
            }
            else if (index == 1)
            {
                Flags.OtherPage = true;
                App._naviConf.Navigate(uriConfPage);
                App._naviHelp.Refresh();
            }
            else if (index == 2)
            {
                Flags.OtherPage = true;
                App._naviHelp.Navigate(uriHelpPage);
                App._naviConf.Refresh();
            }
            else if (index == 3)//ErrInfoタブ 作業者がこのタブを選択することはない。 TEST画面のエラー詳細ボタンを押した時にこのタブが選択されるようコードビハインドで記述
            {
                Flags.OtherPage = true;
                App._naviHelp.Navigate(uriHelpPage);
                App._naviConf.Refresh();
            }

        }









    }
}
