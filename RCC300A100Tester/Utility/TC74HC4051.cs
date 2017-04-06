using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RCC300A100Tester
{
    public static class TC74HC4051
    {
        public enum InputName { CN1, CN3, CN10_11, CN26, TB1, TB2, TB3, K10NC, K10NO }

        public static int GetP31Data(InputName name)
        {

            //MP1,MP2のイネーブル信号を禁止にする
            General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b5, EPX64S.OUT.H);
            General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b6, EPX64S.OUT.H);
            Thread.Sleep(50);

            switch (name)
            {
                case InputName.CN1:
                case InputName.K10NO:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.L);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.L);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.L);//C
                    break;

                case InputName.CN3:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.H);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.L);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.L);//C
                    break;
                case InputName.CN10_11:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.L);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.H);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.L);//C
                    break;
                case InputName.CN26:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.H);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.H);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.L);//C
                    break;
                case InputName.TB1:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.L);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.L);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.H);//C
                    break;
                case InputName.TB2:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.H);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.L);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.H);//C
                    break;
                case InputName.TB3:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.L);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.H);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.H);//C
                    break;
                case InputName.K10NC:
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b2, EPX64S.OUT.H);//A
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b3, EPX64S.OUT.H);//B
                    General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b4, EPX64S.OUT.H);//C
                    break;

            }


            if (name != InputName.K10NO)
            {
                General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b5, EPX64S.OUT.L);
            }
            else
            {
                General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b6, EPX64S.OUT.L);
            }

            Thread.Sleep(50);

            General.io.ReadInputData(EPX64S.PORT.P3);
            return General.io.P3InputData & 0x02;

        }










    }
}
