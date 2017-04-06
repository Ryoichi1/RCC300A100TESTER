using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RCC300A100Tester
{

    public static class CheckOutputTB2
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
                           case INPUT_NAME.RC://K3をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b7, EPX64S.OUT.H);
                               State.VmTestResults.ColorK3Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.RH://K4をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b0, EPX64S.OUT.H);
                               State.VmTestResults.ColorK4Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.CHSTON://K5をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b1, EPX64S.OUT.H);
                               State.VmTestResults.ColorK5Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.MF://K6をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b2, EPX64S.OUT.H);
                               State.VmTestResults.ColorK6Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.BON://K7をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b3, EPX64S.OUT.H);
                               State.VmTestResults.ColorK7Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.PD://K8をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b4, EPX64S.OUT.H);
                               State.VmTestResults.ColorK8Exp = Brushes.DodgerBlue;
                               break;
                           case INPUT_NAME.MENTE://K9をONさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b5, EPX64S.OUT.H);
                               State.VmTestResults.ColorK9Exp = Brushes.DodgerBlue;
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
                           case INPUT_NAME.RC://K3をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b7, EPX64S.OUT.L);
                               State.VmTestResults.ColorK3Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.RH://K4をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b0, EPX64S.OUT.L);
                               State.VmTestResults.ColorK4Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.CHSTON://K5をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b1, EPX64S.OUT.L);
                               State.VmTestResults.ColorK5Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.MF://K6をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b2, EPX64S.OUT.L);
                               State.VmTestResults.ColorK6Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.BON://K7をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b3, EPX64S.OUT.L);
                               State.VmTestResults.ColorK7Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.PD://K8をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b4, EPX64S.OUT.L);
                               State.VmTestResults.ColorK8Exp = Brushes.Transparent;
                               break;
                           case INPUT_NAME.MENTE://K9をOFFさせる処理
                               General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b5, EPX64S.OUT.L);
                               State.VmTestResults.ColorK9Exp = Brushes.Transparent;
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




        public static async Task<bool> CheckK10()
        {

            bool resultOn = false;
            bool resultOff = false;

            try
            {
                return await Task<bool>.Run(() =>
                {
                    try
                    {
                        //試験機K104,K105をOFFする処理
                        General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b2, EPX64S.OUT.L);
                        Thread.Sleep(100);
                        //製品のCN1 1-3にAC200Vを入力する（試験機K100、K101をONする）
                        General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b0, EPX64S.OUT.H);
                        Thread.Sleep(200);

                        //製品のK10をONさせる処理
                        General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b6, EPX64S.OUT.H);
                        State.VmTestResults.ColorK10Exp = Brushes.DodgerBlue;
                        Thread.Sleep(200);

                        //製品のTB3 1番と3番の出力を確認して期待値と一致しているかチェックする
                        var reNc = TC74HC4051.GetP31Data(TC74HC4051.InputName.K10NC);
                        var reNo = TC74HC4051.GetP31Data(TC74HC4051.InputName.K10NO);

                        resultOn = (reNc != 0x00) && (reNo == 0x00);
                        State.VmTestResults.ColorK10Out = resultOn ? Brushes.DodgerBlue : Brushes.Transparent;
                        if (!resultOn) return false;

                        //製品のK10をOFFさせる処理
                        General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b6, EPX64S.OUT.L);
                        State.VmTestResults.ColorK10Exp = Brushes.Transparent;
                        Thread.Sleep(200);

                        //製品のTB3 1番と3番の出力を確認して期待値と一致しているかチェックする
                        reNc = TC74HC4051.GetP31Data(TC74HC4051.InputName.K10NC);
                        reNo = TC74HC4051.GetP31Data(TC74HC4051.InputName.K10NO);

                        resultOff = (reNc == 0x00) && (reNo != 0x00);
                        State.VmTestResults.ColorK10Out = resultOff ? Brushes.Transparent : Brushes.DodgerBlue;


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
                //試験機リレーの初期化
                General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b2, EPX64S.OUT.L);
                General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b0, EPX64S.OUT.L);
                General.io.OutBit(EPX64S.PORT.P1, EPX64S.BIT.b6, EPX64S.OUT.L);
                Thread.Sleep(150);

                //ビューモデルの更新など
            }
        }










    }
}
