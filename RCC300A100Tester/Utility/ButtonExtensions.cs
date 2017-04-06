using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace RCC300A100Tester
{
    public static class ButtonExtensions
    {
        public static void PerformClick(this Button self)
        {
            //
            // WinFormsでいうPerformClickを実行.
            //   System.Windows.Automation.Peers
            //   System.Windows.Automation.Provider
            // 名前空間が必要。
            //
            // IInvokeProviderインターフェースは、UIAutomationProvider.dll
            // の参照設定が追加で必要となる。
            //
            var peer = new ButtonAutomationPeer(self);
            var provider = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;

            provider.Invoke();
        }
    }
}
