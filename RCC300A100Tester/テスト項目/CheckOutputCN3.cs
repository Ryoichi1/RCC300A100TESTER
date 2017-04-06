using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RCC300A100Tester
{

    public static class CheckOutputCN3
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
                           case INPUT_NAME.SRC://K1をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b5, EPX64S.OUT.H);
                               State.VmTestResults.ColorK1Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.SRH://K2をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b6, EPX64S.OUT.H);
                               State.VmTestResults.ColorK2Exp = Brushes.DodgerBlue;
                               break;
                       }

                       Thread.Sleep(200);//出力安定待ち

                       resultOn = General.CheckAllInput(name, true);
                       if (!resultOn) return false;

                       switch (name)
                       {
                           case INPUT_NAME.SRC://K1をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b5, EPX64S.OUT.L);
                               State.VmTestResults.ColorK1Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.SRH://K2をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b6, EPX64S.OUT.L);
                               State.VmTestResults.ColorK2Exp = Brushes.Transparent;
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
