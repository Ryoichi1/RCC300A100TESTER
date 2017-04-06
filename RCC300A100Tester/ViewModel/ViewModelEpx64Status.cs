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
    public class ViewModelEpx64Status : BindableBase
    {
        //出力系■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        private Brush _P00Value;
        private Brush _P01Value;
        private Brush _P02Value;
        private Brush _P03Value;
        private Brush _P04Value;
        private Brush _P05Value;
        private Brush _P06Value;
        private Brush _P07Value;

        private Brush _P10Value;
        private Brush _P11Value;
        private Brush _P12Value;
        private Brush _P13Value;
        private Brush _P14Value;
        private Brush _P15Value;
        private Brush _P16Value;
        private Brush _P17Value;

        private Brush _P20Value;
        private Brush _P21Value;
        private Brush _P22Value;
        private Brush _P23Value;
        private Brush _P24Value;
        private Brush _P25Value;
        private Brush _P26Value;
        private Brush _P27Value;

        private Brush _P40Value;
        private Brush _P41Value;
        private Brush _P42Value;
        private Brush _P43Value;
        private Brush _P44Value;
        private Brush _P45Value;
        private Brush _P46Value;
        private Brush _P47Value;

        private Brush _P50Value;
        private Brush _P51Value;
        private Brush _P52Value;
        private Brush _P53Value;
        private Brush _P54Value;
        private Brush _P55Value;
        private Brush _P56Value;
        private Brush _P57Value;

        private Brush _AllOffValue;

        public Brush P00Value { get { return _P00Value; } set { SetProperty(ref _P00Value, value); } }
        public Brush P01Value { get { return _P01Value; } set { SetProperty(ref _P01Value, value); } }
        public Brush P02Value { get { return _P02Value; } set { SetProperty(ref _P02Value, value); } }
        public Brush P03Value { get { return _P03Value; } set { SetProperty(ref _P03Value, value); } }
        public Brush P04Value { get { return _P04Value; } set { SetProperty(ref _P04Value, value); } }
        public Brush P05Value { get { return _P05Value; } set { SetProperty(ref _P05Value, value); } }
        public Brush P06Value { get { return _P06Value; } set { SetProperty(ref _P06Value, value); } }
        public Brush P07Value { get { return _P07Value; } set { SetProperty(ref _P07Value, value); } }

        public Brush P10Value { get { return _P10Value; } set { SetProperty(ref _P10Value, value); } }
        public Brush P11Value { get { return _P11Value; } set { SetProperty(ref _P11Value, value); } }
        public Brush P12Value { get { return _P12Value; } set { SetProperty(ref _P12Value, value); } }
        public Brush P13Value { get { return _P13Value; } set { SetProperty(ref _P13Value, value); } }
        public Brush P14Value { get { return _P14Value; } set { SetProperty(ref _P14Value, value); } }
        public Brush P15Value { get { return _P15Value; } set { SetProperty(ref _P15Value, value); } }
        public Brush P16Value { get { return _P16Value; } set { SetProperty(ref _P16Value, value); } }
        public Brush P17Value { get { return _P17Value; } set { SetProperty(ref _P17Value, value); } }

        public Brush P20Value { get { return _P20Value; } set { SetProperty(ref _P20Value, value); } }
        public Brush P21Value { get { return _P21Value; } set { SetProperty(ref _P21Value, value); } }
        public Brush P22Value { get { return _P22Value; } set { SetProperty(ref _P22Value, value); } }
        public Brush P23Value { get { return _P23Value; } set { SetProperty(ref _P23Value, value); } }
        public Brush P24Value { get { return _P24Value; } set { SetProperty(ref _P24Value, value); } }
        public Brush P25Value { get { return _P25Value; } set { SetProperty(ref _P25Value, value); } }
        public Brush P26Value { get { return _P26Value; } set { SetProperty(ref _P26Value, value); } }
        public Brush P27Value { get { return _P27Value; } set { SetProperty(ref _P27Value, value); } }

        public Brush P40Value { get { return _P40Value; } set { SetProperty(ref _P40Value, value); } }
        public Brush P41Value { get { return _P41Value; } set { SetProperty(ref _P41Value, value); } }
        public Brush P42Value { get { return _P42Value; } set { SetProperty(ref _P42Value, value); } }
        public Brush P43Value { get { return _P43Value; } set { SetProperty(ref _P43Value, value); } }
        public Brush P44Value { get { return _P44Value; } set { SetProperty(ref _P44Value, value); } }
        public Brush P45Value { get { return _P45Value; } set { SetProperty(ref _P45Value, value); } }
        public Brush P46Value { get { return _P46Value; } set { SetProperty(ref _P46Value, value); } }
        public Brush P47Value { get { return _P47Value; } set { SetProperty(ref _P47Value, value); } }

        public Brush P50Value { get { return _P50Value; } set { SetProperty(ref _P50Value, value); } }
        public Brush P51Value { get { return _P51Value; } set { SetProperty(ref _P51Value, value); } }
        public Brush P52Value { get { return _P52Value; } set { SetProperty(ref _P52Value, value); } }
        public Brush P53Value { get { return _P53Value; } set { SetProperty(ref _P53Value, value); } }
        public Brush P54Value { get { return _P54Value; } set { SetProperty(ref _P54Value, value); } }
        public Brush P55Value { get { return _P55Value; } set { SetProperty(ref _P55Value, value); } }
        public Brush P56Value { get { return _P56Value; } set { SetProperty(ref _P56Value, value); } }
        public Brush P57Value { get { return _P57Value; } set { SetProperty(ref _P57Value, value); } }

        public Brush AllOffValue { get { return _AllOffValue; } set { SetProperty(ref _AllOffValue, value); } }



        //入力系■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        private Brush _P30Value;
        private Brush _P31aValue;
        private Brush _P31bValue;
        private Brush _P31cValue;
        private Brush _P31dValue;
        private Brush _P31eValue;
        private Brush _P31fValue;
        private Brush _P31gValue;
        private Brush _P31hValue;
        private Brush _P31iValue;
        
        private Brush _P32Value;
        private Brush _P33Value;
        private Brush _P34Value;
        private Brush _P35Value;
        private Brush _P36Value;
        private Brush _P37Value;

        private Brush _P60Value;
        private Brush _P61Value;
        private Brush _P62Value;
        private Brush _P63Value;
        private Brush _P64Value;
        private Brush _P65Value;
        private Brush _P66Value;
        private Brush _P67Value;

        private Brush _P70Value;
        private Brush _P71Value;
        private Brush _P72Value;
        private Brush _P73Value;
        private Brush _P74Value;
        private Brush _P75Value;
        private Brush _P76Value;
        private Brush _P77Value;

        public Brush P30Value { get { return _P30Value; } set { SetProperty(ref _P30Value, value); } }
        public Brush P31aValue { get { return _P31aValue; } set { SetProperty(ref _P31aValue, value); } }
        public Brush P31bValue { get { return _P31bValue; } set { SetProperty(ref _P31bValue, value); } }
        public Brush P31cValue { get { return _P31cValue; } set { SetProperty(ref _P31cValue, value); } }
        public Brush P31dValue { get { return _P31dValue; } set { SetProperty(ref _P31dValue, value); } }
        public Brush P31eValue { get { return _P31eValue; } set { SetProperty(ref _P31eValue, value); } }
        public Brush P31fValue { get { return _P31fValue; } set { SetProperty(ref _P31fValue, value); } }
        public Brush P31gValue { get { return _P31gValue; } set { SetProperty(ref _P31gValue, value); } }
        public Brush P31hValue { get { return _P31hValue; } set { SetProperty(ref _P31hValue, value); } }
        public Brush P31iValue { get { return _P31iValue; } set { SetProperty(ref _P31iValue, value); } }

        public Brush P32Value { get { return _P32Value; } set { SetProperty(ref _P32Value, value); } }
        public Brush P33Value { get { return _P33Value; } set { SetProperty(ref _P33Value, value); } }
        public Brush P34Value { get { return _P34Value; } set { SetProperty(ref _P34Value, value); } }
        public Brush P35Value { get { return _P35Value; } set { SetProperty(ref _P35Value, value); } }
        public Brush P36Value { get { return _P36Value; } set { SetProperty(ref _P36Value, value); } }
        public Brush P37Value { get { return _P37Value; } set { SetProperty(ref _P37Value, value); } }

        public Brush P60Value { get { return _P60Value; } set { SetProperty(ref _P60Value, value); } }
        public Brush P61Value { get { return _P61Value; } set { SetProperty(ref _P61Value, value); } }
        public Brush P62Value { get { return _P62Value; } set { SetProperty(ref _P62Value, value); } }
        public Brush P63Value { get { return _P63Value; } set { SetProperty(ref _P63Value, value); } }
        public Brush P64Value { get { return _P64Value; } set { SetProperty(ref _P64Value, value); } }
        public Brush P65Value { get { return _P65Value; } set { SetProperty(ref _P65Value, value); } }
        public Brush P66Value { get { return _P66Value; } set { SetProperty(ref _P66Value, value); } }
        public Brush P67Value { get { return _P67Value; } set { SetProperty(ref _P67Value, value); } }
        
        public Brush P70Value { get { return _P70Value; } set { SetProperty(ref _P70Value, value); } }
        public Brush P71Value { get { return _P71Value; } set { SetProperty(ref _P71Value, value); } }
        public Brush P72Value { get { return _P72Value; } set { SetProperty(ref _P72Value, value); } }
        public Brush P73Value { get { return _P73Value; } set { SetProperty(ref _P73Value, value); } }
        public Brush P74Value { get { return _P74Value; } set { SetProperty(ref _P74Value, value); } }
        public Brush P75Value { get { return _P75Value; } set { SetProperty(ref _P75Value, value); } }
        public Brush P76Value { get { return _P76Value; } set { SetProperty(ref _P76Value, value); } }
        public Brush P77Value { get { return _P77Value; } set { SetProperty(ref _P77Value, value); } }

    }
}
