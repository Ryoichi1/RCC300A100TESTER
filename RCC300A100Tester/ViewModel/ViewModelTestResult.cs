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
    public class ViewModelTestResult : BindableBase
    {
        //コネクタ実装チェック
        private string _ResultCN1;
        public string ResultCN1
        {
            get { return _ResultCN1; }
            set { SetProperty(ref _ResultCN1, value); }
        }

        private string _ResultCN3;
        public string ResultCN3
        {
            get { return _ResultCN3; }
            set { SetProperty(ref _ResultCN3, value); }
        }

        private string _ResultCN10_11;
        public string ResultCN10_11
        {
            get { return _ResultCN10_11; }
            set { SetProperty(ref _ResultCN10_11, value); }
        }

        private string _ResultCN26;
        public string ResultCN26
        {
            get { return _ResultCN26; }
            set { SetProperty(ref _ResultCN26, value); }
        }

        private string _ResultTB1;
        public string ResultTB1
        {
            get { return _ResultTB1; }
            set { SetProperty(ref _ResultTB1, value); }
        }

        private string _ResultTB2;
        public string ResultTB2
        {
            get { return _ResultTB2; }
            set { SetProperty(ref _ResultTB2, value); }
        }

        private string _ResultTB3;
        public string ResultTB3
        {
            get { return _ResultTB3; }
            set { SetProperty(ref _ResultTB3, value); }
        }


        //期待値
        private Brush _ColorK1Exp;
        public Brush ColorK1Exp { get { return _ColorK1Exp; } set { SetProperty(ref _ColorK1Exp, value); } }
        private Brush _ColorK2Exp;
        public Brush ColorK2Exp { get { return _ColorK2Exp; } set { SetProperty(ref _ColorK2Exp, value); } }
        private Brush _ColorK3Exp;
        public Brush ColorK3Exp { get { return _ColorK3Exp; } set { SetProperty(ref _ColorK3Exp, value); } }
        private Brush _ColorK4Exp;
        public Brush ColorK4Exp { get { return _ColorK4Exp; } set { SetProperty(ref _ColorK4Exp, value); } }
        private Brush _ColorK5Exp;
        public Brush ColorK5Exp { get { return _ColorK5Exp; } set { SetProperty(ref _ColorK5Exp, value); } }
        private Brush _ColorK6Exp;
        public Brush ColorK6Exp { get { return _ColorK6Exp; } set { SetProperty(ref _ColorK6Exp, value); } }
        private Brush _ColorK7Exp;
        public Brush ColorK7Exp { get { return _ColorK7Exp; } set { SetProperty(ref _ColorK7Exp, value); } }
        private Brush _ColorK8Exp;
        public Brush ColorK8Exp { get { return _ColorK8Exp; } set { SetProperty(ref _ColorK8Exp, value); } }

        private Brush _ColorK9Exp;
        public Brush ColorK9Exp { get { return _ColorK9Exp; } set { SetProperty(ref _ColorK9Exp, value); } }

        private Brush _ColorK10Exp;
        public Brush ColorK10Exp { get { return _ColorK10Exp; } set { SetProperty(ref _ColorK10Exp, value); } }

        private Brush _ColorCirTb1Exp;
        public Brush ColorCirTb1Exp { get { return _ColorCirTb1Exp; } set { SetProperty(ref _ColorCirTb1Exp, value); } }
        private Brush _ColorHirTb1Exp;
        public Brush ColorHirTb1Exp { get { return _ColorHirTb1Exp; } set { SetProperty(ref _ColorHirTb1Exp, value); } }
        private Brush _ColorThwExp;
        public Brush ColorThwExp { get { return _ColorThwExp; } set { SetProperty(ref _ColorThwExp, value); } }
        private Brush _ColorEsc1Tb1Exp;
        public Brush ColorEsc1Tb1Exp { get { return _ColorEsc1Tb1Exp; } set { SetProperty(ref _ColorEsc1Tb1Exp, value); } }
        private Brush _ColorEsh1Tb1Exp;
        public Brush ColorEsh1Tb1Exp { get { return _ColorEsh1Tb1Exp; } set { SetProperty(ref _ColorEsh1Tb1Exp, value); } }
        private Brush _ColorEsonExp;
        public Brush ColorEsonExp { get { return _ColorEsonExp; } set { SetProperty(ref _ColorEsonExp, value); } }
        private Brush _ColorEsoffExp;
        public Brush ColorEsoffExp { get { return _ColorEsoffExp; } set { SetProperty(ref _ColorEsoffExp, value); } }
        private Brush _ColorCmExp;
        public Brush ColorCmExp { get { return _ColorCmExp; } set { SetProperty(ref _ColorCmExp, value); } }
        private Brush _ColorHmExp;
        public Brush ColorHmExp { get { return _ColorHmExp; } set { SetProperty(ref _ColorHmExp, value); } }
        private Brush _ColorEdmExp;
        public Brush ColorEdmExp { get { return _ColorEdmExp; } set { SetProperty(ref _ColorEdmExp, value); } }

        private Brush _ColorVbExp;
        public Brush ColorVbExp { get { return _ColorVbExp; } set { SetProperty(ref _ColorVbExp, value); } }

        private Brush _ColorClsExp;
        public Brush ColorClsExp { get { return _ColorClsExp; } set { SetProperty(ref _ColorClsExp, value); } }

        private Brush _ColorCirCn10Exp;
        public Brush ColorCirCn10Exp { get { return _ColorCirCn10Exp; } set { SetProperty(ref _ColorCirCn10Exp, value); } }
        private Brush _ColorHirCn10Exp;
        public Brush ColorHirCn10Exp { get { return _ColorHirCn10Exp; } set { SetProperty(ref _ColorHirCn10Exp, value); } }
        private Brush _ColorEsc1Cn10Exp;
        public Brush ColorEsc1Cn10Exp { get { return _ColorEsc1Cn10Exp; } set { SetProperty(ref _ColorEsc1Cn10Exp, value); } }
        private Brush _ColorEsh1Cn10Exp;
        public Brush ColorEsh1Cn10Exp { get { return _ColorEsh1Cn10Exp; } set { SetProperty(ref _ColorEsh1Cn10Exp, value); } }

        private Brush _ColorCirCn11Exp;
        public Brush ColorCirCn11Exp { get { return _ColorCirCn11Exp; } set { SetProperty(ref _ColorCirCn11Exp, value); } }
        private Brush _ColorHirCn11Exp;
        public Brush ColorHirCn11Exp { get { return _ColorHirCn11Exp; } set { SetProperty(ref _ColorHirCn11Exp, value); } }
        private Brush _ColorEsc1Cn11Exp;
        public Brush ColorEsc1Cn11Exp { get { return _ColorEsc1Cn11Exp; } set { SetProperty(ref _ColorEsc1Cn11Exp, value); } }
        private Brush _ColorEsh1Cn11Exp;
        public Brush ColorEsh1Cn11Exp { get { return _ColorEsh1Cn11Exp; } set { SetProperty(ref _ColorEsh1Cn11Exp, value); } }

        //出力値
        private Brush _ColorK1Out;
        public Brush ColorK1Out { get { return _ColorK1Out; } set { SetProperty(ref _ColorK1Out, value); } }
        private Brush _ColorK2Out;
        public Brush ColorK2Out { get { return _ColorK2Out; } set { SetProperty(ref _ColorK2Out, value); } }
        private Brush _ColorK3Out;
        public Brush ColorK3Out { get { return _ColorK3Out; } set { SetProperty(ref _ColorK3Out, value); } }
        private Brush _ColorK4Out;
        public Brush ColorK4Out { get { return _ColorK4Out; } set { SetProperty(ref _ColorK4Out, value); } }
        private Brush _ColorK5Out;
        public Brush ColorK5Out { get { return _ColorK5Out; } set { SetProperty(ref _ColorK5Out, value); } }
        private Brush _ColorK6Out;
        public Brush ColorK6Out { get { return _ColorK6Out; } set { SetProperty(ref _ColorK6Out, value); } }
        private Brush _ColorK7Out;
        public Brush ColorK7Out { get { return _ColorK7Out; } set { SetProperty(ref _ColorK7Out, value); } }
        private Brush _ColorK8Out;
        public Brush ColorK8Out { get { return _ColorK8Out; } set { SetProperty(ref _ColorK8Out, value); } }
        private Brush _ColorK9Out;
        public Brush ColorK9Out { get { return _ColorK9Out; } set { SetProperty(ref _ColorK9Out, value); } }

        private Brush _ColorK10Out;
        public Brush ColorK10Out { get { return _ColorK10Out; } set { SetProperty(ref _ColorK10Out, value); } }

        private Brush _ColorCirOut;
        public Brush ColorCirOut { get { return _ColorCirOut; } set { SetProperty(ref _ColorCirOut, value); } }

        private Brush _ColorHirOut;
        public Brush ColorHirOut { get { return _ColorHirOut; } set { SetProperty(ref _ColorHirOut, value); } }

        private Brush _ColorThwOut;
        public Brush ColorThwOut { get { return _ColorThwOut; } set { SetProperty(ref _ColorThwOut, value); } }

        private Brush _ColorEsc1Out;
        public Brush ColorEsc1Out { get { return _ColorEsc1Out; } set { SetProperty(ref _ColorEsc1Out, value); } }

        private Brush _ColorEsh1Out;
        public Brush ColorEsh1Out { get { return _ColorEsh1Out; } set { SetProperty(ref _ColorEsh1Out, value); } }

        private Brush _ColorEsonOut;
        public Brush ColorEsonOut { get { return _ColorEsonOut; } set { SetProperty(ref _ColorEsonOut, value); } }

        private Brush _ColorEsoffOut;
        public Brush ColorEsoffOut { get { return _ColorEsoffOut; } set { SetProperty(ref _ColorEsoffOut, value); } }

        private Brush _ColorCmOut;
        public Brush ColorCmOut { get { return _ColorCmOut; } set { SetProperty(ref _ColorCmOut, value); } }

        private Brush _ColorHmOut;
        public Brush ColorHmOut { get { return _ColorHmOut; } set { SetProperty(ref _ColorHmOut, value); } }

        private Brush _ColorEdmOut;
        public Brush ColorEdmOut { get { return _ColorEdmOut; } set { SetProperty(ref _ColorEdmOut, value); } }

        private Brush _ColorVbOut;
        public Brush ColorVbOut { get { return _ColorVbOut; } set { SetProperty(ref _ColorVbOut, value); } }


        private Brush _ColorClsOut;
        public Brush ColorClsOut { get { return _ColorClsOut; } set { SetProperty(ref _ColorClsOut, value); } }



       
    }
}
