using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Windows;

namespace RCC300A100Tester
{
    public class InputData
    {
        public INPUT_NAME name;
        public bool input;
    }


    public enum INPUT_NAME
    {

        SRC, SRH, RC, RH, CHSTON, MF, BON, PD, MENTE, CM, HM, EDM,/*CN26*/
        CIR, HIR, THW, ESC1, ESH1, ESON, ESOFF,/*TB1,CN10,CN11*/
        CLS, VB/*TB3*/
    }

    public class TestSpecs
    {
        public int Key;
        public string Value;
        public bool PowSw;

        public TestSpecs(int key, string value, bool powSW = true)
        {
            this.Key = key;
            this.Value = value;
            this.PowSw = powSW;

        }
    }

    public static class State
    {
        //データソース（バインディング用）
        public static ViewModelMainWindow VmMainWindow = new ViewModelMainWindow();
        public static ViewModelTestStatus VmTestStatus = new ViewModelTestStatus();
        public static ViewModelTestResult VmTestResults = new ViewModelTestResult();
        public static TestCommand testCommand = new TestCommand();

        public static List<InputData> InputDataList = new List<InputData>();


        //パブリックメンバ
        public static Configuration Setting { get; set; }
        public static TestSpec TestSpec { get; set; }

        public static string CurrDir { get; set; }

        public static string AssemblyInfo { get; set; }

        public static double CurrentThemeOpacity { get; set; }

        public static Uri uriErrInfoPage { get; set; }


        //リトライ履歴保存用リスト
        public static List<string> RetryLogList = new List<string>();


        public static List<TestSpecs> 日常点検項目 = new List<TestSpecs>()
        {


        };


        public static List<TestSpecs> テスト項目 = new List<TestSpecs>()
        {
            new TestSpecs(100, "コネクタ実装チェック", false),

            new TestSpecs(200, "K3 チェック", true),
            new TestSpecs(201, "K4 チェック", true),
            new TestSpecs(202, "K5 チェック", true),
            new TestSpecs(203, "K6 チェック", true),
            new TestSpecs(204, "K7 チェック", true),
            new TestSpecs(205, "K8 チェック", true),
            new TestSpecs(206, "K9 チェック", true),
            new TestSpecs(207, "K10 チェック", true),

            new TestSpecs(300, "CM チェック", true),
            new TestSpecs(301, "HM チェック", true),
            new TestSpecs(302, "EDM チェック", true),

            new TestSpecs(400, "TB1-CIR チェック", true),
            new TestSpecs(401, "TB1-HIR チェック", true),
            new TestSpecs(402, "THW チェック", true),
            new TestSpecs(403, "TB1-ESC1 チェック", true),
            new TestSpecs(404, "TB1-ESH1 チェック", true),
            new TestSpecs(405, "ESON チェック", true),
            new TestSpecs(406, "ESOFF チェック", true),
            new TestSpecs(407, "CN10-CIR チェック", true),
            new TestSpecs(408, "CN10-HIR チェック", true),
            new TestSpecs(409, "CN10-ESC1 チェック", true),
            new TestSpecs(410, "CN10-ESH1 チェック", true),
            new TestSpecs(411, "CN11-CIR チェック", true),
            new TestSpecs(412, "CN11-HIR チェック", true),
            new TestSpecs(413, "CN11-ESC1 チェック", true),
            new TestSpecs(414, "CN11-ESH1 チェック", true),

            new TestSpecs(500, "VB チェック", true),
            new TestSpecs(501, "CLS チェック", true),


        };


        //個別設定のロード
        public static void LoadConfigData()
        {
            //Configファイルのロード
            Setting = Deserialize<Configuration>(Constants.filePath_Configuration);
            if (Setting.日付 != DateTime.Now.ToString("yyyyMMdd"))
            {
                Setting.日付 = DateTime.Now.ToString("yyyyMMdd");
                Setting.TodayOkCount = 0;
                Setting.TodayNgCount = 0;
            }

            VmMainWindow.ListOperator = Setting.作業者リスト;
            VmMainWindow.Theme = Setting.PathTheme;
            VmMainWindow.ThemeOpacity = Setting.OpacityTheme;
            VmTestStatus.OkCount = Setting.TodayOkCount.ToString() + "台";
            VmTestStatus.NgCount = Setting.TodayNgCount.ToString() + "台";
            VmTestStatus.TotalCount = Setting.TotalTestCount.ToString() + "台";

            //TestSpecファイルのロード
            TestSpec = Deserialize<TestSpec>(Constants.filePath_TestSpec);//TODO:

        }


        //インスタンスをXMLデータに変換する
        public static bool Serialization<T>(T obj, string xmlFilePath)
        {
            try
            {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                //書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(xmlFilePath, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, obj);
                //ファイルを閉じる
                sw.Close();

                return true;

            }
            catch
            {
                return false;
            }

        }

        //XMLデータからインスタンスを生成する
        public static T Deserialize<T>(string xmlFilePath)
        {
            System.Xml.Serialization.XmlSerializer serializer;
            using (var sr = new System.IO.StreamReader(xmlFilePath, new System.Text.UTF8Encoding(false)))
            {
                serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        //********************************************************
        //個別設定データの保存
        //********************************************************
        public static bool Save個別データ()
        {
            try
            {
                //Configファイルの保存
                Setting.作業者リスト = VmMainWindow.ListOperator;
                Setting.PathTheme = VmMainWindow.Theme;
                Setting.OpacityTheme = VmMainWindow.ThemeOpacity;

                Serialization<Configuration>(Setting, Constants.filePath_Configuration);

                return true;
            }
            catch
            {
                return false;

            }

        }







    }

}
