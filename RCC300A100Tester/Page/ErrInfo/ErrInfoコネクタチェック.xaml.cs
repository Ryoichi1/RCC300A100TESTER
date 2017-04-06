using Microsoft.Practices.Prism.Mvvm;
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

namespace RCC300A100Tester
{
    /// <summary>
    /// ErrInfoコネクタチェック.xaml の相互作用ロジック
    /// </summary>
    public partial class ErrInfoコネクタチェック
    {

        public class vm : BindableBase
        {
            private Visibility _VisCN1 = Visibility.Hidden;
            public Visibility VisCN1 { get { return _VisCN1; } internal set { SetProperty(ref _VisCN1, value); } }

            private Visibility _VisCN3 = Visibility.Hidden;
            public Visibility VisCN3 { get { return _VisCN3; } internal set { SetProperty(ref _VisCN3, value); } }

            private Visibility _VisCN10_11 = Visibility.Hidden;
            public Visibility VisCN10_11 { get { return _VisCN10_11; } internal set { SetProperty(ref _VisCN10_11, value); } }

            private Visibility _VisCN26 = Visibility.Hidden;
            public Visibility VisCN26 { get { return _VisCN26; } internal set { SetProperty(ref _VisCN26, value); } }

            private Visibility _VisTB1 = Visibility.Hidden;
            public Visibility VisTB1 { get { return _VisTB1; } internal set { SetProperty(ref _VisTB1, value); } }

            private Visibility _VisTB2 = Visibility.Hidden;
            public Visibility VisTB2 { get { return _VisTB2; } internal set { SetProperty(ref _VisTB2, value); } }

            private Visibility _VisTB3 = Visibility.Hidden;
            public Visibility VisTB3 { get { return _VisTB3; } internal set { SetProperty(ref _VisTB3, value); } }

            private string _NgList = "";
            public string NgList { get { return _NgList; } internal set { SetProperty(ref _NgList, value); } }
        }

        private vm viewmodel;

        public ErrInfoコネクタチェック()
        {
            viewmodel = new vm();
            this.DataContext = viewmodel;
            SetErrInfo();

        }

        private void SetErrInfo()
        {

            var NgList = ConnectorCheck.ListCnSpec.Where(cn => !cn.result);

            viewmodel.VisCN1 = Visibility.Hidden;
            //viewmodel.VisCN3 = Visibility.Hidden;
            viewmodel.VisCN10_11 = Visibility.Hidden;
            viewmodel.VisCN26 = Visibility.Hidden;
            viewmodel.VisTB1 = Visibility.Hidden;
            viewmodel.VisTB2 = Visibility.Hidden;
            viewmodel.VisTB3 = Visibility.Hidden;

            foreach (var cn in NgList)
            {
                switch (cn.name)
                {
                    case TC74HC4051.InputName.CN1:
                        viewmodel.VisCN1 = Visibility.Visible;
                        viewmodel.NgList += "CN1\r\n";
                        break;

                    //case TC74HC4051.InputName.CN3:
                    //    viewmodel.VisCN3 = Visibility.Visible;
                    //    viewmodel.NgList += "CN3\r\n";
                    //    break;

                    case TC74HC4051.InputName.CN10_11:
                        viewmodel.VisCN10_11 = Visibility.Visible;
                        viewmodel.NgList += "CN10, CN11\r\n";
                        break;

                    case TC74HC4051.InputName.CN26:
                        viewmodel.VisCN26 = Visibility.Visible;
                        viewmodel.NgList += "CN26\r\n";
                        break;

                    case TC74HC4051.InputName.TB1:
                        viewmodel.VisTB1 = Visibility.Visible;
                        viewmodel.NgList += "TB1\r\n";
                        break;

                    case TC74HC4051.InputName.TB2:
                        viewmodel.VisTB2 = Visibility.Visible;
                        viewmodel.NgList += "TB2\r\n";
                        break;

                    case TC74HC4051.InputName.TB3:
                        viewmodel.VisTB3 = Visibility.Visible;
                        viewmodel.NgList += "TB3\r\n";
                        break;
                }

            }


        }


        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            State.VmMainWindow.TabIndex = 0;
        }




    }
}
