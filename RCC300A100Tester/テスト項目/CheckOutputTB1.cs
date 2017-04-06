using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RCC300A100Tester
{

    public static class CheckOutputTB1
    {


        public static async Task<bool> Check(INPUT_NAME name)
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
                           case INPUT_NAME.CM://CN26-11
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b7, EPX64S.OUT.H);
                               State.VmTestResults.ColorCmExp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.EDM://CN26-13
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b0, EPX64S.OUT.H);
                               State.VmTestResults.ColorEdmExp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.HM://CN26-15
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b1, EPX64S.OUT.H);
                               State.VmTestResults.ColorHmExp = Brushes.DodgerBlue;
                               break;

                       }

                       Thread.Sleep(200);//出力安定待ち

                       resultOn = General.CheckAllInput(name, true);
                       if (!resultOn) return false;

                       switch (name)
                       {
                           case INPUT_NAME.CM://CN26-11
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b7, EPX64S.OUT.L);
                               State.VmTestResults.ColorCmExp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.EDM://CN26-13
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b0, EPX64S.OUT.L);
                               State.VmTestResults.ColorEdmExp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.HM://CN26-15
                               General.io.OutBit(EPX64S.PORT.P2, EPX64S.BIT.b1, EPX64S.OUT.L);
                               State.VmTestResults.ColorHmExp = Brushes.Transparent;
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












    }
}
