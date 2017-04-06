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
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

namespace RCC300A100Tester
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class Mente
    {
        Brush OffColor;
        Brush OnColor;

        ViewModelEpx64Status ioState;

        public Mente()
        {
            InitializeComponent();
            ioState = new ViewModelEpx64Status();
            this.DataContext = ioState;
            OffColor = Brushes.Transparent;
            OnColor = Brushes.DodgerBlue;

            buttonPow.Background = Brushes.Transparent;
        }

        private async void _MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var name = (Label)sender;
            switch (name.Name)
            {
                case "P00":
                    ioState.P00Value = (ioState.P00Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b0, ioState.P00Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P01":
                    ioState.P01Value = (ioState.P01Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b1, ioState.P01Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P02":
                    ioState.P02Value = (ioState.P02Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b2, ioState.P02Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P03":
                    ioState.P03Value = (ioState.P03Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b3, ioState.P03Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P04"://合格スタンプへの出力のため、0.3秒OnしてすぐにOffする
                    ioState.P04Value = OnColor;
                    await General.合格印();
                    ioState.P04Value = OffColor;
                    break;
                case "P05":
                    ioState.P05Value = (ioState.P05Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b5, ioState.P05Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P06":
                    ioState.P06Value = (ioState.P06Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b6, ioState.P06Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P07":
                    ioState.P07Value = (ioState.P07Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b7, ioState.P07Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;


                case "P10":
                    ioState.P10Value = (ioState.P10Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b0, ioState.P10Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P11":
                    ioState.P11Value = (ioState.P11Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b1, ioState.P11Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P12":
                    ioState.P12Value = (ioState.P12Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b2, ioState.P12Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P13":
                    ioState.P13Value = (ioState.P13Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b3, ioState.P13Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P14":
                    ioState.P14Value = (ioState.P14Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b4, ioState.P14Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P15":
                    ioState.P15Value = (ioState.P15Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b5, ioState.P15Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P16":
                    ioState.P16Value = (ioState.P16Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b6, ioState.P16Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P17":
                    ioState.P17Value = (ioState.P17Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b7, ioState.P17Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;

                case "P20":
                    ioState.P20Value = (ioState.P20Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b0, ioState.P20Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P21":
                    ioState.P21Value = (ioState.P21Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b1, ioState.P21Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P22":
                    ioState.P22Value = (ioState.P22Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b2, ioState.P22Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P23":
                    ioState.P23Value = (ioState.P23Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b3, ioState.P23Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P24":
                    ioState.P24Value = (ioState.P24Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b4, ioState.P24Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P25":
                    ioState.P25Value = (ioState.P25Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b5, ioState.P25Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P26":
                    ioState.P26Value = (ioState.P26Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b6, ioState.P26Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P27":
                    ioState.P27Value = (ioState.P27Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b7, ioState.P27Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;

                case "P40":
                    ioState.P40Value = (ioState.P40Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b0, ioState.P40Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P41":
                    ioState.P41Value = (ioState.P41Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b1, ioState.P41Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P42":
                    ioState.P42Value = (ioState.P42Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b2, ioState.P42Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P43":
                    ioState.P43Value = (ioState.P43Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b3, ioState.P43Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P44":
                    ioState.P44Value = (ioState.P44Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b4, ioState.P44Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P45":
                    ioState.P45Value = (ioState.P45Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b5, ioState.P45Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P46":
                    ioState.P46Value = (ioState.P46Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b6, ioState.P46Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P47":
                    ioState.P47Value = (ioState.P47Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b7, ioState.P47Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;

                case "P50":
                    ioState.P50Value = (ioState.P50Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b0, ioState.P50Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P51":
                    ioState.P51Value = (ioState.P51Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b1, ioState.P51Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P52":
                    ioState.P52Value = (ioState.P52Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, ioState.P52Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P53":
                    ioState.P53Value = (ioState.P53Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, ioState.P53Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P54":
                    ioState.P54Value = (ioState.P54Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, ioState.P54Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P55":
                    ioState.P55Value = (ioState.P55Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b5, ioState.P55Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P56":
                    ioState.P56Value = (ioState.P56Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b6, ioState.P56Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "P57":
                    ioState.P57Value = (ioState.P57Value == OnColor) ? OffColor : OnColor;
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b7, ioState.P57Value == OnColor ? EPX64S.OUT.H : EPX64S.OUT.L);
                    break;
                case "AllOff":
                    ioState.AllOffValue = OnColor;
                    await Task.Delay(40);
                    General.ResetIo();
                    ResetOutputColor();
                    ioState.AllOffValue = OffColor;

                    break;

            }






        }

        private void ResetOutputColor()
        {
            ioState.P00Value = OffColor;
            ioState.P01Value = OffColor;
            ioState.P02Value = OffColor;
            ioState.P03Value = OffColor;
            ioState.P04Value = OffColor;
            ioState.P05Value = OffColor;
            ioState.P06Value = OffColor;
            ioState.P07Value = OffColor;

            ioState.P10Value = OffColor;
            ioState.P11Value = OffColor;
            ioState.P12Value = OffColor;
            ioState.P13Value = OffColor;
            ioState.P14Value = OffColor;
            ioState.P15Value = OffColor;
            ioState.P16Value = OffColor;
            ioState.P17Value = OffColor;

            ioState.P20Value = OffColor;
            ioState.P21Value = OffColor;
            ioState.P22Value = OffColor;
            ioState.P23Value = OffColor;
            ioState.P24Value = OffColor;
            ioState.P25Value = OffColor;
            ioState.P26Value = OffColor;
            ioState.P27Value = OffColor;

            ioState.P40Value = OffColor;
            ioState.P41Value = OffColor;
            ioState.P42Value = OffColor;
            ioState.P43Value = OffColor;
            ioState.P44Value = OffColor;
            ioState.P45Value = OffColor;
            ioState.P46Value = OffColor;
            ioState.P47Value = OffColor;

            ioState.P40Value = OffColor;
            ioState.P41Value = OffColor;
            ioState.P42Value = OffColor;
            ioState.P43Value = OffColor;
            ioState.P44Value = OffColor;
            ioState.P45Value = OffColor;
            ioState.P46Value = OffColor;
            ioState.P47Value = OffColor;

            ioState.P50Value = OffColor;
            ioState.P51Value = OffColor;
            ioState.P52Value = OffColor;
            ioState.P53Value = OffColor;
            ioState.P54Value = OffColor;
            ioState.P55Value = OffColor;
            ioState.P56Value = OffColor;
            ioState.P57Value = OffColor;


        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            General.ResetIo();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


        }

        bool FlagPow;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FlagPow = !FlagPow;

            if (FlagPow)
            {
                buttonPow.Background = Brushes.DodgerBlue;
                General.Supply12V(true);
                await Task.Delay(300);

                //試験機K104,K105をONする処理
                General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b2, EPX64S.OUT.H);
                await Task.Delay(300);

                //製品のCN1 1-3にAC200Vを入力する（試験機K100、K101をONする）
                General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b0, EPX64S.OUT.H);
                await Task.Delay(300);
            }
            else
            {
                buttonPow.Background = Brushes.Transparent;
                General.ResetIo();
            }

        }
    }
}
