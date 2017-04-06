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
    /// Theme.xaml の相互作用ロジック
    /// </summary>
    public partial class Theme
    {
        public Theme()
        {
            InitializeComponent();
            this.DataContext = State.VmMainWindow;
        }

        private void Pic1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/sumetal1.jpg";
        }

        private void Pic2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/sumetal3.jpg";
        }

        private void Pic3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/babymetal2.jpg";
        }

        private void Pic4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State.VmMainWindow.Theme = "Resources/babymetal.jpg";
        }
    }
}
