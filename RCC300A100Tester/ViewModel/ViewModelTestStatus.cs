using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;


namespace RCC300A100Tester
{
    public class ViewModelTestStatus : BindableBase
    {
        //単体試験チェックボックスとコンボボックスの可視切り替え
        private Visibility _EnableButtonErrInfo = Visibility.Hidden;
        public Visibility EnableButtonErrInfo
        {
            get { return _EnableButtonErrInfo; }

            internal set
            {
                SetProperty(ref _EnableButtonErrInfo, value);
            }
        }


        //label判定Color
        private Brush _Colorlabel判定;
        public Brush Colorlabel判定
        {
            get { return _Colorlabel判定; }
            internal set { SetProperty(ref _Colorlabel判定, value); }
        }

        //単体試験のプロパティ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        //単体試験チェックボックスとコンボボックスの可視切り替え
        private Visibility _EnableUnitTest;
        public  Visibility EnableUnitTest
        {
            get { return _EnableUnitTest; }

            set
            {
                SetProperty(ref _EnableUnitTest, value);
            }
        }

        //単体試験チェックボックスがチェックされているかどうかの判定
        private bool? _CheckUnitTest;
        public bool? CheckUnitTest
        {
            get { return _CheckUnitTest; }
            set { SetProperty(ref _CheckUnitTest, value); }
        }

        //単体試験コンボボックスのアイテムソース
        private List<string> _UnitTestItems;
        public List<string> UnitTestItems
        {

            get { return _UnitTestItems; }
            set { SetProperty(ref _UnitTestItems, value); }

        }

        //単体試験コンボボックスの選択されたアイテム
        private string _UnitTestName;
        public string UnitTestName
        {

            get { return _UnitTestName; }
            set { SetProperty(ref _UnitTestName, value); }

        }


        //判定表示のプロパティ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        //判定表示　PASS or FAIL
        private string _Decision;
        public string Decision
        {
            get { return _Decision; }
            set { SetProperty(ref _Decision, value); }
        }

        //FAIL判定時に表示するエラー情報
        private string _FailInfo;
        public string FailInfo
        {
            get { return _FailInfo; }
            set { SetProperty(ref _FailInfo, value); }
        }

        //FAIL判定時に表示する試験スペック
        private string _Spec;
        public string Spec
        {
            get { return _Spec; }
            set { SetProperty(ref _Spec, value); }
        }

        //FAIL判定時に表示する計測値
        private string _MeasValue;
        public string MeasValue
        {
            get { return _MeasValue; }
            set { SetProperty(ref _MeasValue, value); }
        }

        //判定表示の可視性
        private Visibility _DecisionVisibility;
        public Visibility DecisionVisibility
        {
            get { return _DecisionVisibility; }
            set { SetProperty(ref _DecisionVisibility, value); }
        }

        //規格値、計測値の可視性
        private Visibility _ErrInfoVisibility;
        public Visibility ErrInfoVisibility
        {
            get { return _ErrInfoVisibility; }
            set { SetProperty(ref _ErrInfoVisibility, value); }
        }


        //判定表示の色
        private DropShadowEffect _ColorDecision;
        public DropShadowEffect ColorDecision
        {
            get { return _ColorDecision; }
            set { SetProperty(ref _ColorDecision, value); }
        }





        //ステータス表示部のプロパティ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private string _OkCount;
        public string OkCount
        {
            get { return _OkCount; }
            set { SetProperty(ref _OkCount, value); }
        }

        private string _NgCount;
        public string NgCount
        {
            get { return _NgCount; }
            set { SetProperty(ref _NgCount, value); }
        }

        private string _TotalCount;
        public string TotalCount
        {
            get { return _TotalCount; }
            set { SetProperty(ref _TotalCount, value); }
        }



        //プログレスリングのプロパティ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        //プログレスリングのEndAngle
        private int _進捗度;
        public int 進捗度
        {
            get { return _進捗度; }
            set { SetProperty(ref _進捗度, value); }
        }

        //プログレスリングの可視性
        private Visibility _RingVisibility;
        public Visibility RingVisibility
        {
            get { return _RingVisibility; }
            set { SetProperty(ref _RingVisibility, value); }
        }


        //その他のプロパティ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        //テスト時間
        private string _TestTime;
        public string TestTime
        {
            get { return _TestTime; }
            set { SetProperty(ref _TestTime, value); }
        }

        //作業者へのメッセージ
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }



        private string _TestLog;
        public string TestLog
        {
            get { return _TestLog; }
            set { SetProperty(ref _TestLog, value); }
        }


        private Brush _Color日常点検;
        public Brush Color日常点検
        {
            get { return _Color日常点検; }
            set { SetProperty(ref _Color日常点検, value); }
        }

        private Brush _ColorEPX64S;
        public Brush ColorEpx64s
        {
            get { return _ColorEPX64S; }
            set { SetProperty(ref _ColorEPX64S, value); }
        }

        private Brush _ColorHostPc;
        public Brush ColorHostPc
        {
            get { return _ColorHostPc; }
            set { SetProperty(ref _ColorHostPc, value); }
        }

        private Brush _ColorRetry;
        public Brush ColorRetry
        {
            get { return _ColorRetry; }
            set { SetProperty(ref _ColorRetry, value); }
        }
    }
}
