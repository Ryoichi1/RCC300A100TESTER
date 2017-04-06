using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using System.Diagnostics;

namespace RCC300A100Tester
{


    public static class General
    {

        //インスタンス変数の宣言
        public static EPX64S io;
        public static SoundPlayer player = null;
        public static SoundPlayer soundPass = null;
        public static SoundPlayer soundFail = null;
        public static SoundPlayer soundOperator = null;
        public static SoundPlayer soundModel = null;
        public static SoundPlayer soundOpecode = null;
        public static SoundPlayer soundAlarm = null;
        public static SoundPlayer soundKuru = null;
        public static SoundPlayer soundCutin = null;
        public static SoundPlayer soundWavePass = null;
        public static SoundPlayer soundSerialLabel = null;

        static General()
        {
            //オーディオリソースを取り出す
            General.soundPass = new SoundPlayer(@"Resources\Pass.wav");
            General.soundFail = new SoundPlayer(@"Resources\Fail.wav");
            General.soundOperator = new SoundPlayer(@"Resources\Operator.wav");
            General.soundModel = new SoundPlayer(@"Resources\Model.wav");
            General.soundOpecode = new SoundPlayer(@"Resources\Opecode.wav");
            General.soundAlarm = new SoundPlayer(@"Resources\Alarm.wav");
            General.soundKuru = new SoundPlayer(@"Resources\Kuru.wav");
            //General.soundCutin = new SoundPlayer(@"Resources\enshutsu01.wav");
            //General.soundSerialLabel = new SoundPlayer(@"Resources\BGM_Label.wav");
        }


        public static bool Check日常点検データ()
        {
            try
            {
                // StringBuilder クラスの新しいインスタンスを生成する
                var sbTarget = new System.Text.StringBuilder();

                // 日常点検データファイルを開く
                using (var sr = new System.IO.StreamReader(Constants.fileName_日常点検, Encoding.GetEncoding("Shift_JIS")))//ANSI = Shift_JIS 
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadToEnd();
                        // 出力する
                        sbTarget.Append(line);
                    }
                }
                var allData = sbTarget.ToString();
                var today = System.DateTime.Now.ToString("yyyy/MM/dd");
                return allData.IndexOf(today) >= 0;
            }
            catch
            {
                return false;
            }

        }


        //nameの出力がSWで指定した値と同じであること確認
        //name以外の出力がすべてOFFであることの確認
        public static bool CheckAllInput(INPUT_NAME name, bool sw)
        {
            State.InputDataList.Clear();


            General.io.ReadInputData(EPX64S.PORT.P3);
            var buffP3 = General.io.P3InputData;

            General.io.ReadInputData(EPX64S.PORT.P6);
            var buffP6 = General.io.P6InputData;

            General.io.ReadInputData(EPX64S.PORT.P7);
            var buffP7 = General.io.P7InputData;


            State.InputDataList.Add(new InputData { name = INPUT_NAME.SRC,       input = (buffP3 & 0x04) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.SRH,       input = (buffP3 & 0x08) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.RC,        input = (buffP3 & 0x10) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.RH,        input = (buffP3 & 0x20) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.CHSTON,    input = (buffP3 & 0x40) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.MF,        input = (buffP3 & 0x80) == 0x00 ? true : false });

            State.InputDataList.Add(new InputData { name = INPUT_NAME.BON,       input = (buffP6 & 0x01) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.PD,        input = (buffP6 & 0x02) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.MENTE,     input = (buffP6 & 0x04) == 0x00 ? true : false });
            State.InputDataList.Add(new InputData { name = INPUT_NAME.THW,       input = (buffP6 & 0x08) != 0x00 ? true : false });//他と論理が逆

            State.InputDataList.Add(new InputData { name = INPUT_NAME.CIR,   input = (buffP6 & 0x10) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.ESC1,  input = (buffP6 & 0x20) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.HIR,   input = (buffP6 & 0x40) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.ESH1,  input = (buffP6 & 0x80) != 0x00 ? true : false });//他と論理が逆

            State.InputDataList.Add(new InputData { name = INPUT_NAME.ESOFF,     input = (buffP7 & 0x01) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.ESON,      input = (buffP7 & 0x02) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.CM,        input = (buffP7 & 0x04) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.HM,        input = (buffP7 & 0x08) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.EDM,       input = (buffP7 & 0x10) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.CLS,       input = (buffP7 & 0x20) != 0x00 ? true : false });//他と論理が逆
            State.InputDataList.Add(new InputData { name = INPUT_NAME.VB,       input = (buffP7 & 0x40) == 0x00 ? true : false });


            //ビューモデルの更新（各端子の出力値を反映させる）
            //CN3(未実装)
            State.VmTestResults.ColorK1Out = State.InputDataList.Find(d => d.name == INPUT_NAME.SRC).input ?     Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK2Out = State.InputDataList.Find(d => d.name == INPUT_NAME.SRH).input ?     Brushes.DodgerBlue : Brushes.Transparent;

            //TB2
            State.VmTestResults.ColorK3Out = State.InputDataList.Find(d => d.name == INPUT_NAME.RC).input ?      Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK4Out = State.InputDataList.Find(d => d.name == INPUT_NAME.RH).input ?      Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK5Out = State.InputDataList.Find(d => d.name == INPUT_NAME.CHSTON).input ?  Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK6Out = State.InputDataList.Find(d => d.name == INPUT_NAME.MF).input ?      Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK7Out = State.InputDataList.Find(d => d.name == INPUT_NAME.BON).input ?     Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK8Out = State.InputDataList.Find(d => d.name == INPUT_NAME.PD).input ?      Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorK9Out = State.InputDataList.Find(d => d.name == INPUT_NAME.MENTE).input ?   Brushes.DodgerBlue : Brushes.Transparent;

            //TB1、CN10、CN11
            State.VmTestResults.ColorCirOut = State.InputDataList.Find(d => d.name == INPUT_NAME.CIR).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorHirOut = State.InputDataList.Find(d => d.name == INPUT_NAME.HIR).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorThwOut = State.InputDataList.Find(d => d.name == INPUT_NAME.THW).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorEsc1Out = State.InputDataList.Find(d => d.name == INPUT_NAME.ESC1).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorEsh1Out = State.InputDataList.Find(d => d.name == INPUT_NAME.ESH1).input ? Brushes.DodgerBlue : Brushes.Transparent;


            State.VmTestResults.ColorEsonOut = State.InputDataList.Find(d => d.name == INPUT_NAME.ESON).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorEsoffOut = State.InputDataList.Find(d => d.name == INPUT_NAME.ESOFF).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorCmOut = State.InputDataList.Find(d => d.name == INPUT_NAME.CM).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorHmOut = State.InputDataList.Find(d => d.name == INPUT_NAME.HM).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorEdmOut = State.InputDataList.Find(d => d.name == INPUT_NAME.EDM).input ? Brushes.DodgerBlue : Brushes.Transparent;

            //TB3
            State.VmTestResults.ColorVbOut = State.InputDataList.Find(d => d.name == INPUT_NAME.VB).input ? Brushes.DodgerBlue : Brushes.Transparent;
            State.VmTestResults.ColorClsOut = State.InputDataList.Find(d => d.name == INPUT_NAME.CLS).input ? Brushes.DodgerBlue : Brushes.Transparent;
            

            //判定処理
            var resultOnoff = State.InputDataList.Find(d => d.name == name).input == sw;
            var resultOther = State.InputDataList.Where(d => d.name != name).All(d => d.input == false); 
            Thread.Sleep(200); //更新したビューモデルを作業者に認識させるため少しウェイトを入れる
            return resultOnoff && resultOther;

        }

        //**************************************************************************
        //プレス治具のレバーが下がっているかどうかの判定
        //引数：なし
        //戻値：bool　プレスのレバーが下がっていればtrue
        //**************************************************************************
        public static bool CheckPress()
        {
            byte p31Data = 0;
            byte buff = 0;

            io.ReadInputData(EPX64S.PORT.P3);
            buff = io.P3InputData;
            p31Data = (byte)(buff & 0x02);//代入演算子の右側にある算術式が既定でintに評価されるため、キャストする
            return (p31Data == 0x00);
        }

        public static async Task WaitPressOff()
        {
            byte p31Data = 0;
            byte buff = 0;

            await Task.Run(() =>
            {
                while (true)
                {
                    io.ReadInputData(EPX64S.PORT.P3);
                    buff = io.P3InputData;
                    p31Data = (byte)(buff & 0x02);//代入演算子の右側にある算術式が既定でintに評価されるため、キャストする
                    if (p31Data != 0x00) break;
                }
            });
        }

        public static bool CheckHostConnection()
        {
            //HostPCが立ち上がっているかの確認
            return (System.IO.Directory.Exists(Constants.HostConnectCheckPath));

        }


        public static bool SaveTestLog()
        {

            //書き込みデータの生成
            var 年 = System.DateTime.Now.ToString("yy");
            var 月 = (Int32.Parse(System.DateTime.Now.ToString("MM")) * 4).ToString("D2");
            var dc = 年 + 月 + "Ne";
            var opecode = State.VmMainWindow.Opecode;

            var passedTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string[] DataArray = { dc, opecode, passedTime };
            var FinalData = string.Join(",", DataArray);//リストの要素をカンマで連結

            //ファイルパス生成
            string filePath = Constants.成績書用ログフォルダのパス + opecode + ".txt";

            bool append = System.IO.File.Exists(filePath);

            //出力用のファイルを開く appendをtrueにすると既存のファイルに追記、falseにするとファイルを新規作成する
            using (var sw = new System.IO.StreamWriter(filePath, append, Encoding.GetEncoding("Shift_JIS")))
            {
                try
                {
                    sw.WriteLine(FinalData);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        public static bool SaveRetryLog()
        {
            if (State.RetryLogList.Count() == 0) return true;

            //出力用のファイルを開く appendをtrueにすると既存のファイルに追記、falseにするとファイルを新規作成する
            using (var sw = new System.IO.StreamWriter(Constants.fileName_RetryLog, true, Encoding.GetEncoding("Shift_JIS")))
            {
                try
                {
                    State.RetryLogList.ForEach(d =>
                    {
                        sw.WriteLine(d);
                    });

                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }



        private static List<string> MakePassTestData()//TODO:
        {
            var ListData = new List<string>
            {
                "AssemblyVer " + State.AssemblyInfo,
                "TestSpecVer " + State.TestSpec.TestSpecVer,
                State.VmMainWindow.Opecode,
                State.VmMainWindow.Operator,
                System.DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH：mm：ss"),
            };


            return ListData;

        }

        public static bool SaveTestData()
        {
            try
            {
                var 日付 = System.DateTime.Now.ToString("yyyy.MM.dd");

                var OkDataFilePath = Constants.PassDataFolderPath + 日付 + ".csv";

                if (!System.IO.File.Exists(OkDataFilePath))
                {
                    //既存検査データがなければ新規作成
                    File.Copy(Constants.PassDataFolderPath + "Format.csv", OkDataFilePath);
                }



                var dataList = MakePassTestData();
                // リストデータをすべてカンマ区切りで連結する
                string stCsvData = string.Join(",", dataList);

                // appendをtrueにすると，既存のファイルに追記
                //         falseにすると，ファイルを新規作成する
                var append = true;

                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(OkDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.WriteLine(stCsvData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        //**************************************************************************
        //検査データの保存　　　　
        //引数：なし
        //戻値：なし
        //**************************************************************************

        public static bool SaveNgData(List<string> dataList)
        {
            try
            {
                var NgDataFilePath = Constants.FailDataFolderPath + State.VmMainWindow.Opecode + ".csv";
                if (!System.IO.File.Exists(NgDataFilePath))
                {
                    //既存検査データがなければ新規作成
                    File.Copy(Constants.FailDataFolderPath + "FormatNg.csv", NgDataFilePath);
                }

                var stArrayData = dataList.ToArray();
                // リストデータをすべてカンマ区切りで連結する
                string stCsvData = string.Join(",", stArrayData);

                // appendをtrueにすると，既存のファイルに追記
                //         falseにすると，ファイルを新規作成する
                var append = true;

                // 出力用のファイルを開く
                using (var sw = new System.IO.StreamWriter(NgDataFilePath, append, Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.WriteLine(stCsvData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        //**************************************************************************
        //EPX64のリセット
        //引数：なし
        //戻値：なし
        //**************************************************************************
        public static void ResetIo() //P7:0 P6:1 P5:1 P4:1  P3:0 P2:1 P1:1 P0:1  
        {
            //IOを初期化する処理（出力をすべてＬに落とす）
            io.OutByte(EPX64S.PORT.P0, 0x00);
            io.OutByte(EPX64S.PORT.P1, 0x00);
            io.OutByte(EPX64S.PORT.P2, 0x00);
            io.OutByte(EPX64S.PORT.P4, 0x00);
            io.OutByte(EPX64S.PORT.P5, 0x00);
        }

        public static void Supply12V(bool sw)
        {
            if (Flags.PowOn == sw) return;

            Thread.Sleep(200);
            io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b3, sw ? EPX64S.OUT.H : EPX64S.OUT.L);
            Flags.PowOn = sw;
        }

        //public static void Supply200V(bool sw)
        //{
        //    if (Flags.PowOn == sw) return;

        //    Thread.Sleep(200);
        //    io.OutBit(EPX64S.PORT.P4, EPX64S.BIT.b0, sw ? EPX64S.OUT.H : EPX64S.OUT.L);
        //    Flags.PowOn = sw;
        //}




        //**************************************************************************
        //WAVEファイルを再生する
        //引数：なし
        //戻値：なし
        //**************************************************************************  

        //WAVEファイルを再生する（非同期で再生）
        public static void PlaySound(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.Play();
        }

        public static void PlaySoundLoop(SoundPlayer p)
        {
            //再生されているときは止める
            if (player != null)
                player.Stop();

            //waveファイルを読み込む
            player = p;
            //最後まで再生し終えるまで待機する
            player.PlayLooping();
        }

        //再生されているWAVEファイルを止める
        public static void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        public static async Task 合格印()
        {
            await Task.Run(() =>
            {
                io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b4, EPX64S.OUT.H);
                Thread.Sleep(300);
                io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b4, EPX64S.OUT.L);
            });
        }

        public static void ResetViewModel()//TODO:
        {
            State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Hidden;
            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Hidden;

            State.VmTestStatus.RingVisibility = System.Windows.Visibility.Visible;



            State.VmTestStatus.TestTime = "00:00";
            State.VmTestStatus.進捗度 = 0;
            State.VmTestStatus.TestLog = "";

            State.VmTestStatus.FailInfo = "";
            State.VmTestStatus.Spec = "";
            State.VmTestStatus.MeasValue = "";


            //試験結果のクリア
            State.VmTestResults = new ViewModelTestResult();

            //ViewModel OK台数、NG台数、Total台数の更新
            State.VmTestStatus.OkCount = State.Setting.TodayOkCount.ToString() + "台";
            State.VmTestStatus.NgCount = State.Setting.TodayNgCount.ToString() + "台";
            State.VmTestStatus.TotalCount = State.Setting.TotalTestCount.ToString() + "台";
            State.VmTestStatus.Message = Constants.MessSet;
            State.VmMainWindow.EnableOtherButton = true;

            //各種フラグの初期化
            Flags.PowOn = false;

            Flags.Testing = false;


            //テーマ透過度を元に戻す
            State.VmMainWindow.ThemeOpacity = State.CurrentThemeOpacity;

            State.VmTestStatus.ColorRetry = Brushes.Transparent;
        }

        public static void Init周辺機器()//TODO:
        {
            Flags.Initializing周辺機器 = true;

            Task.Run(() =>
            {
                while (true)
                {

                    //IOボードの初期化
                    Flags.StateEpx64 = General.io.InitEpx64S(0x37);
                    if (Flags.StateEpx64)
                    {
                        //IOボードのリセット（出力をすべてOFFする）
                        General.ResetIo();
                        break;
                    }

                    Thread.Sleep(400);
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    //ホストPCとの接続確認
                    Flags.StateHostPc = CheckHostConnection();
                    if (Flags.StateHostPc)
                    {
                        ////管理者権限でバッチファイル（ホストPCとの時刻同期）を実行
                        //var proc = new Process();
                        //proc.StartInfo.FileName = Constants.FilePathTimeBat;
                        //proc.StartInfo.Verb = "RunAs";
                        //proc.Start();
                        break;
                    }
                    Thread.Sleep(400);
                }
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Flags.AllOk周辺機器接続 = (Flags.StateEpx64 && Flags.StateHostPc);
                    if (Flags.AllOk周辺機器接続 || Flags.StopInit周辺機器) break;
                    Thread.Sleep(400);

                }
                Flags.Initializing周辺機器 = false;
            });


        }

        /// <summary>
        /// FAN出力のON/OFFを取得する　ON=Trueが返ります
        /// </summary>
        /// <returns></returns>
        public static bool GetStateFAN()
        {
            io.ReadInputData(EPX64S.PORT.P3);
            var result = (io.P3InputData & 0x08) == 0x00;
            return result;
        }

        /// 以下、試験機のリレー制御
        public static void SetK101(bool sw) { General.io.OutBit(EPX64S.PORT.P5, EPX64S.BIT.b7, sw ? EPX64S.OUT.H : EPX64S.OUT.L); }
        public static void SetK102(bool sw) { General.io.OutBit(EPX64S.PORT.P6, EPX64S.BIT.b0, sw ? EPX64S.OUT.H : EPX64S.OUT.L); }




    }

}

