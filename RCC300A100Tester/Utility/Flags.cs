using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RCC300A100Tester
{
    public static class Flags
    {
        public static bool 日常点検中 { get; set; }//日常点検中はTrue、通常試験はFalse
        public static bool OtherPage { get; set; }
        public static bool ReturnFromOtherPage { get; set; }

        //試験開始時に初期化が必要なフラグ
        public static bool StopInit周辺機器 { get; set; }
        public static bool Initializing周辺機器 { get; set; }
        public static bool Testing { get; set; }
        public static bool PowOn { get; set; }//メイン電源ON/OFF
        public static bool コネクタ逆検知チェック { get; set; }
        public static bool ShowErrInfo { get; set; }
        public static bool AddDecision { get; set; }
        public static bool BattleMode { get; set; }

        //public static bool DialogPushed { get; set; }// ダイアログボックス表示中に、OK or CANSEL or 丸スイッチを押したかどうか
        //public static bool DialogReturn { get; set; }// OK/CANSELダイアログボックスの戻り値
        //public static bool ClickStopButton { get; set; }
        //public static bool Click確認Button { get; set; }
        //public static bool ShowLabelPage { get; set; }


        //日常点検のステータス
        private static bool _State日常点検;
        public static bool State日常点検
        {
            get { return _State日常点検; }
            set
            {
                _State日常点検 = value;
                State.VmTestStatus.Color日常点検 = value ? Brushes.DodgerBlue : Brushes.OrangeRed;
            }
        }

        //周辺機器ステータス
        private static bool _StateEpx64;
        public static bool StateEpx64
        {
            get { return _StateEpx64; }
            set
            {
                _StateEpx64 = value;
                State.VmTestStatus.ColorEpx64s = value ? Brushes.DodgerBlue : Brushes.OrangeRed;
            }
        }

        private static bool _StateHostPc;
        public static bool StateHostPc
        {
            get { return _StateHostPc; }
            set
            {
                _StateHostPc = value;
                State.VmTestStatus.ColorHostPc = value ? Brushes.DodgerBlue : Brushes.OrangeRed;
            }
        }


        public static bool AllOk周辺機器接続 { get; set; }



    }
}
