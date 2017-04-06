using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCC300A100Tester
{
    public static  class Constants
    {

        //作業者へのメッセージ
        public const string MessOpecode = "バーコードリーダーで工番を読みとってください";
        public const string MessOperator = "作業者名を選択してください";
        public const string MessSet = "製品をセットしてレバーを下げてください";
        public const string MessRemove = "製品を取り外してください";
        public const string MessPressOpen = "一度プレスのレバーを上げて下さい";

        public const string MessWait = "検査中！　しばらくお待ちください・・・";
        public const string MessCheckConnectMachine = "周辺機器の接続を確認してください！";
        public const string MessDailyCheck = "点検用サンプルをセットして開始を押して下さい";

        //パラメータファイルのパス
        public const string DataRootPath = @"C:\RCC300A100";

        public static readonly string filePath_Configuration = Path.Combine(DataRootPath, @"ConfigData\Configuration.config");
        public static readonly string filePath_TestSpec = Path.Combine(DataRootPath, @"ConfigData\TestSpec.config");


        //検査データフォルダのパス
        public static readonly string PassDataFolderPath = Path.Combine(DataRootPath, @"検査データ\合格品データ\");
        public static readonly string FailDataFolderPath = Path.Combine(DataRootPath, @"検査データ\不良品データ\");
        public static readonly string fileName_RetryLog = Path.Combine(DataRootPath, @"検査データ\不良品データ\リトライ履歴.txt");

        public static readonly string fileName_日常点検 = Path.Combine(DataRootPath, @"日常点検\日常点検.txt");

        public static readonly string HostConnectCheckPath = @"C:\RCC300A100\";
        public static readonly string 成績書用ログフォルダのパス = @"C:\RCC300A100\";
        //public static readonly string 成績書用ログフォルダのパス = @"\\Rcc300-40-pc\rcc300_data\RCC300ALog\";
        public static readonly string 成績書印刷用PCのパス = @"\\Rcc300-40-pc\rcc300_data";


        //時刻同期用バッチファイルのパス
        public static readonly string FilePathTimeBat = Path.Combine(State.CurrDir, @"TestRcc300A100.bat");

        //Imageの透明度
        public const double OpacityMax = 1.0;
        public const double OpacityMin = 0.16;

        //リトライ回数
        public static readonly int RetryCount = 1;










    

    }
}
