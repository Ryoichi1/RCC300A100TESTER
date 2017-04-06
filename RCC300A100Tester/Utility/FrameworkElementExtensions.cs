using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RCC300A100Tester
{
    public static class FrameworkElementExtensions
    {
        public static T FindByName<T>(this FrameworkElement self, string name) where T : FrameworkElement
        {
            return self.FindName(name) as T;
        }
    }
}