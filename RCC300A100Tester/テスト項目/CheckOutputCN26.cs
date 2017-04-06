using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RCC300A100Tester
{

    public static class CheckOutputCN26
    {


        public static async Task<bool> CheckFromTb1(INPUT_NAME name)
        {
            bool resultOn = false;
            bool resultOff = false;

            try
            {
                return await Task<bool>.Run(() =>
               {
                   try
                   {

                       switch (name)
                       {
                           //TB1からの入力
                           case INPUT_NAME.CIR:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b2, EPX64S.OUT.H);
                               State.VmTestResults.ColorCirTb1Exp = Brushes.DodgerBlue;
                               break;

                           case INPUT_NAME.HIR:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b3, EPX64S.OUT.H);
                               State.VmTestResults.ColorHirTb1Exp = Brushes.DodgerBlue;
                               break;

                           case INPUT_NAME.THW:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b4, EPX64S.OUT.H);
                               State.VmTestResults.ColorThwExp = Brushes.DodgerBlue;
                               break;

                           case INPUT_NAME.ESC1:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b5, EPX64S.OUT.H);
                               State.VmTestResults.ColorEsc1Tb1Exp = Brushes.DodgerBlue;
                               break; ;

                           case INPUT_NAME.ESH1:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b6, EPX64S.OUT.H);
                               State.VmTestResults.ColorEsh1Tb1Exp = Brushes.DodgerBlue;
                               break;

                           case INPUT_NAME.ESON:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b7, EPX64S.OUT.H);
                               State.VmTestResults.ColorEsonExp = Brushes.DodgerBlue;
                               break;

                           case INPUT_NAME.ESOFF:
                               General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b0, EPX64S.OUT.H);
                               State.VmTestResults.ColorEsoffExp = Brushes.DodgerBlue;
                               break;
                       }

                       Thread.Sleep(200);//出力安定待ち

                       resultOn = General.CheckAllInput(name, true);
                       if (!resultOn) return false;

                       switch (name)
                       {
                           //TB1からの入力
                           case INPUT_NAME.CIR:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b2, EPX64S.OUT.L);
                               State.VmTestResults.ColorCirTb1Exp = Brushes.Transparent;
                               break;

                           case INPUT_NAME.HIR:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b3, EPX64S.OUT.L);
                               State.VmTestResults.ColorHirTb1Exp = Brushes.Transparent;
                               break;

                           case INPUT_NAME.THW:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b4, EPX64S.OUT.L);
                               State.VmTestResults.ColorThwExp = Brushes.Transparent;
                               break;

                           case INPUT_NAME.ESC1:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b5, EPX64S.OUT.L);
                               State.VmTestResults.ColorEsc1Tb1Exp = Brushes.Transparent;
                               break; ;

                           case INPUT_NAME.ESH1:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b6, EPX64S.OUT.L);
                               State.VmTestResults.ColorEsh1Tb1Exp = Brushes.Transparent;
                               break;

                           case INPUT_NAME.ESON:
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b7, EPX64S.OUT.L);
                               State.VmTestResults.ColorEsonExp = Brushes.Transparent;
                               break;

                           case INPUT_NAME.ESOFF:
                               General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b0, EPX64S.OUT.L);
                               State.VmTestResults.ColorEsoffExp = Brushes.Transparent;
                               break;

                       }

                       Thread.Sleep(100);//出力安定待ち

                       resultOff = General.CheckAllInput(name, false);
                       return resultOff;

                   }
                   catch
                   {
                       return  false;
                   }

               });
            }
            finally
            {
                //ビューモデルの更新など
            }
        }


        public static async Task<bool> CheckFromCn10(INPUT_NAME name)
        {
            bool resultOn = false;
            bool resultOff = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {

                        switch (name)
                        {
                            //CN10からの入力
                            case INPUT_NAME.CIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b2, EPX64S.OUT.H);
                                State.VmTestResults.ColorCirCn10Exp = Brushes.DodgerBlue;
                                break;

                            case INPUT_NAME.HIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b3, EPX64S.OUT.H);
                                State.VmTestResults.ColorHirCn10Exp = Brushes.DodgerBlue;
                                break;

                            case INPUT_NAME.ESC1:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b4, EPX64S.OUT.H);
                                State.VmTestResults.ColorEsc1Cn10Exp = Brushes.DodgerBlue;
                                break; ;

                            case INPUT_NAME.ESH1:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b5, EPX64S.OUT.H);
                                State.VmTestResults.ColorEsh1Cn10Exp = Brushes.DodgerBlue;
                                break;

                        }

                        Thread.Sleep(200);//出力安定待ち

                        resultOn = General.CheckAllInput(name, true);
                        if (!resultOn) return false;

                        switch (name)
                        {
                            //CN10からの入力
                            case INPUT_NAME.CIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b2, EPX64S.OUT.L);
                                State.VmTestResults.ColorCirCn10Exp = Brushes.Transparent;
                                break;

                            case INPUT_NAME.HIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b3, EPX64S.OUT.L);
                                State.VmTestResults.ColorHirCn10Exp = Brushes.Transparent;
                                break;

                            case INPUT_NAME.ESC1:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b4, EPX64S.OUT.L);
                                State.VmTestResults.ColorEsc1Cn10Exp = Brushes.Transparent;
                                break; ;

                            case INPUT_NAME.ESH1:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b5, EPX64S.OUT.L);
                                State.VmTestResults.ColorEsh1Cn10Exp = Brushes.Transparent;
                                break;

                        }

                        Thread.Sleep(100);//出力安定待ち

                        resultOff = General.CheckAllInput(name, false);
                        return resultOff;

                    }
                    catch
                    {
                        return false;
                    }

                });
            }
            finally
            {
                //ビューモデルの更新など
            }
        }


        public static async Task<bool> CheckFromCn11(INPUT_NAME name)
        {
            bool resultOn = false;
            bool resultOff = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {

                        switch (name)
                        {
                            //CN11からの入力
                            case INPUT_NAME.CIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b6, EPX64S.OUT.H);
                                State.VmTestResults.ColorCirCn11Exp = Brushes.DodgerBlue;
                                break;

                            case INPUT_NAME.HIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b7, EPX64S.OUT.H);
                                State.VmTestResults.ColorHirCn11Exp = Brushes.DodgerBlue;
                                break;

                            case INPUT_NAME.ESC1:
                                General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b0, EPX64S.OUT.H);
                                State.VmTestResults.ColorEsc1Cn11Exp = Brushes.DodgerBlue;
                                break; ;

                            case INPUT_NAME.ESH1:
                                General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b1, EPX64S.OUT.H);
                                State.VmTestResults.ColorEsh1Cn11Exp = Brushes.DodgerBlue;
                                break;
                        }

                        Thread.Sleep(200);//出力安定待ち

                        resultOn = General.CheckAllInput(name, true);
                        if (!resultOn) return false;

                        switch (name)
                        {
                            //CN11からの入力
                            case INPUT_NAME.CIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b6, EPX64S.OUT.L);
                                State.VmTestResults.ColorCirCn11Exp = Brushes.Transparent;
                                break;

                            case INPUT_NAME.HIR:
                                General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b7, EPX64S.OUT.L);
                                State.VmTestResults.ColorHirCn11Exp = Brushes.Transparent;
                                break;

                            case INPUT_NAME.ESC1:
                                General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b0, EPX64S.OUT.L);
                                State.VmTestResults.ColorEsc1Cn11Exp = Brushes.Transparent;
                                break; ;

                            case INPUT_NAME.ESH1:
                                General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b1, EPX64S.OUT.L);
                                State.VmTestResults.ColorEsh1Cn11Exp = Brushes.Transparent;
                                break;

                        }

                        Thread.Sleep(100);//出力安定待ち

                        resultOff = General.CheckAllInput(name, false);
                        return resultOff;

                    }
                    catch
                    {
                        return false;
                    }

                });
            }
            finally
            {
                //ビューモデルの更新など
            }
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public static async Task<bool> InputCLS()
        {
            bool resultOn = false;
            bool resultOff = false;

            try
            {
                return await Task.Run(() =>
                {
                    try
                    {
                        General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b1, EPX64S.OUT.H);
                        State.VmTestResults.ColorClsExp = Brushes.DodgerBlue;
                        Thread.Sleep(250);//出力安定待ち

                        resultOn = General.CheckAllInput(INPUT_NAME.CLS, true);
                        if (!resultOn) return false;

                        General.io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b1, EPX64S.OUT.L);
                        State.VmTestResults.ColorClsExp = Brushes.Transparent;
                        Thread.Sleep(250);//出力安定待ち

                        resultOff = General.CheckAllInput(INPUT_NAME.CLS, false);
                        return resultOff;

                    }
                    catch
                    {
                        return false;
                    }

                });
            }
            finally
            {
                //ビューモデルの更新など

            }
        }


        public static async Task<bool> InputVB()
        {
            bool resultOn = false;
            bool resultOff = false;

            try
            {
                return await Task.Run(() =>
                {
                    try
                    {


                        //製品のK10をONさせる処理
                        General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b6, EPX64S.OUT.H);
                        State.VmTestResults.ColorVbExp = Brushes.DodgerBlue;

                        Thread.Sleep(400);

                        resultOn = General.CheckAllInput(INPUT_NAME.VB, true);

                        if (!resultOn) return false;

                        //製品のK10をOFFさせる処理
                        General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b6, EPX64S.OUT.L);
                        State.VmTestResults.ColorVbExp = Brushes.Transparent;
                        Thread.Sleep(400);

                        resultOff = General.CheckAllInput(INPUT_NAME.VB, false);
                        return resultOff;
                    }
                    catch
                    {
                        return false;
                    }

                });
            }
            finally
            {

                //ビューモデルの更新など

            }
        }






    }
}
