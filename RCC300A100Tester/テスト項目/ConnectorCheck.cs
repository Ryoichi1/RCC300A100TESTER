using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RCC300A100Tester
{
    public static class ConnectorCheck
    {
        public class CnSpec
        {
            public TC74HC4051.InputName name;
            public bool result;
        }

        public static List<CnSpec> ListCnSpec;

        public static void InitList()
        {
            ListCnSpec = new List<CnSpec>
                {
                    new CnSpec {name = TC74HC4051.InputName.CN1, result = false},
                    //new CnSpec {name = TC74HC4051.InputName.CN3, result = false},
                    new CnSpec {name = TC74HC4051.InputName.CN10_11, result = false},
                    new CnSpec {name = TC74HC4051.InputName.CN26, result = false},
                    new CnSpec {name = TC74HC4051.InputName.TB1, result = false},
                    new CnSpec {name = TC74HC4051.InputName.TB2, result = false},
                    new CnSpec {name = TC74HC4051.InputName.TB3, result = false},

                };
        }

        //
        public static async Task<bool> CheckConnector()
        {
            bool result = false;
            return await Task<bool>.Run(() =>
            {
                try
                {
                    InitList();
                    foreach (var spec in ListCnSpec)
                    {
                        spec.result = TC74HC4051.GetP31Data(spec.name) == 0x00;
                    }
                    return result = ListCnSpec.All(s => s.result);
                }
                catch
                {
                    return result = false;
                }
                finally
                {
                    if (!result)
                    {
                        State.uriErrInfoPage = new Uri("Page/ErrInfo/ErrInfoコネクタチェック.xaml", UriKind.Relative);
                        State.VmTestStatus.EnableButtonErrInfo = System.Windows.Visibility.Visible;
                    }
                }
            });


        }
    }
}
