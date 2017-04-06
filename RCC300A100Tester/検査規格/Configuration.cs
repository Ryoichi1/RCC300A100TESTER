using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCC300A100Tester
{
    public class Configuration
    {

        public string 日付 { get; set; }
        public int TotalTestCount { get; set; }
        public int TodayOkCount { get; set; }
        public int TodayNgCount { get; set; }
        public string PathTheme { get; set; }
        public double OpacityTheme { get; set; }
        public List<string> 作業者リスト { get; set; }

    }
}
