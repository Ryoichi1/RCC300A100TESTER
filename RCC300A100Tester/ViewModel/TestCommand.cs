
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace RCC300A100Tester
{
    public class TestCommand
    {

        //デリゲートの宣言
        public Action RefreshDataContext;//Test.Xaml内でテスト結果をクリアするために使用すする
        public Action SbRingLoad;
        public Action SbPass;
        public Action SbFail;

        private bool FlagTestTime;

        DropShadowEffect effect判定表示PASS;
        DropShadowEffect effect判定表示FAIL;

        public TestCommand()
        {

            effect判定表示PASS = new DropShadowEffect();
            effect判定表示PASS.Color = Colors.Aqua;
            effect判定表示PASS.Direction = 0;
            effect判定表示PASS.ShadowDepth = 0;
            effect判定表示PASS.Opacity = 1.0;
            effect判定表示PASS.BlurRadius = 80;

            effect判定表示FAIL = new DropShadowEffect();
            effect判定表示FAIL.Color = Colors.HotPink; ;
            effect判定表示FAIL.Direction = 0;
            effect判定表示FAIL.ShadowDepth = 0;
            effect判定表示FAIL.Opacity = 1.0;
            effect判定表示FAIL.BlurRadius = 40;



        }

        public async Task StartCheck()
        {
            while (true)
            {
                await Task.Run(() =>
                {


                    while (true)
                    {
                    RETRY:
                        if (Flags.OtherPage) goto LOOP_CANCEL;
                        Thread.Sleep(400);


                        //作業者名、工番が正しく入力されているかの判定
                        if (!(State.VmMainWindow.SetOperator && State.VmMainWindow.SetOpecode)) continue;

                        if (!Flags.AllOk周辺機器接続)
                        {
                            State.VmTestStatus.Message = Constants.MessCheckConnectMachine;
                            continue;
                        }

                        if (Flags.State日常点検)
                        {
                            State.VmTestStatus.Message = Constants.MessSet;
                        }
                        else
                        {
                            State.VmTestStatus.Message = Constants.MessDailyCheck;
                        }

                        //TESTページがロードされたときに、プレスのレバーが下がっていたら一度上げるように指示を出す
                        while (true)
                        {
                            if (!Flags.ReturnFromOtherPage)
                            {
                                State.VmTestStatus.Message = Constants.MessPressOpen;
                            }
                            else
                            {
                                State.VmTestStatus.Message = Constants.MessSet;
                                break;
                            }
                        }

                        //プレスが閉じるのを待つ
                        while (!General.CheckPress())
                        {
                            Thread.Sleep(600);
                            if (Flags.OtherPage) goto LOOP_CANCEL;//クリアボタンで入力項目がクリアされたらループキャンセルする
                            if (!State.VmMainWindow.SetOperator) goto RETRY;//クリアボタンが押されていたらリトライ
                        }


                        if (Flags.State日常点検)
                        {
                            Flags.日常点検中 = false;//通常試験モード
                        }
                        else
                        {
                            Flags.日常点検中 = true;//日常点検モード
                        }

                    LOOP_CANCEL:
                        break;
                    }
                });

                if (Flags.OtherPage) return;
                State.VmMainWindow.EnableOtherButton = false;
                Flags.Testing = true;
                await Test();//メインルーチンへ


                //試験合格後、ラベル貼り付けページを表示する場合は下記のステップを追加すること
                //if (Flags.ShowLabelPage) return;

                //日常点検合格、一項目試験合格、試験NGの場合は、Whileループを繰り返す
                //通常試験合格の場合は、ラベル貼り付けフォームがロードされた時点で、一旦StartCheckメソッドを終了します
                //その後、ラベル貼り付けフォームが閉じられた後に、Test.xamlがリロードされ、そのフォームロードイベントでStartCheckメソッドがコールされます

            }

        }



        private void Timer()
        {
            var t = Task.Run(() =>
            {
                //Stopwatchオブジェクトを作成する
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                while (FlagTestTime)
                {
                    Thread.Sleep(200);
                    State.VmTestStatus.TestTime = sw.Elapsed.ToString().Substring(3, 5);
                }
                sw.Stop();
            });
        }

        //メインルーチン
        public async Task Test()
        {
            //バトルモードにするかどうかの判定（夕方5時以降に突入）
            if (Int32.Parse(System.DateTime.Now.ToString("HH")) >= 18)
            {
                Flags.BattleMode = true;
            }
            else
            {
                Flags.BattleMode = false;
            }


            State.VmTestStatus.Message = Constants.MessWait;

            //現在のテーマ透過度の保存
            State.CurrentThemeOpacity = State.VmMainWindow.ThemeOpacity;
            State.VmMainWindow.ThemeOpacity = Constants.OpacityMin;

            await Task.Delay(500);

            FlagTestTime = true;
            Timer();

            int FailStepNo = 0;
            int RetryCnt = 0;//リトライ用に使用する
            string FailTitle = "";




            var テスト項目最新 = new List<TestSpecs>();
            if (State.VmTestStatus.CheckUnitTest == true)
            {
                //チェックしてある項目の百の桁の解析
                var re = Int32.Parse(State.VmTestStatus.UnitTestName.Split('_').ToArray()[0]);
                int 上位桁 = Int32.Parse(State.VmTestStatus.UnitTestName.Substring(0, (re >= 1000) ? 2 : 1));
                var 抽出データ = State.テスト項目.Where(p => (p.Key / 100) == 上位桁);
                foreach (var p in 抽出データ)
                {
                    テスト項目最新.Add(new TestSpecs(p.Key, p.Value, p.PowSw));
                }
            }
            else
            {
                テスト項目最新 = State.テスト項目;
            }


            try
            {
                //IO初期化
                General.ResetIo();
                Thread.Sleep(200);

                General.Supply12V(true);
                await Task.Delay(300);

                //試験機K104,K105をONする処理
                General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b2, EPX64S.OUT.H);
                Thread.Sleep(200);

                //製品のCN1 1-3にAC200Vを入力する（試験機K100、K101をONする）
                General.io.OutBit(EPX64S.PORT.P0, EPX64S.BIT.b0, EPX64S.OUT.H);
                Thread.Sleep(400);


                foreach (var d in テスト項目最新.Select((s, i) => new { i, s }))
                {
                    State.VmTestStatus.Spec = "規格値 : ---";
                    State.VmTestStatus.MeasValue = "計測値 : ---";
                    Flags.AddDecision = true;

                    SetTestLog(d.s.Key.ToString() + "_" + d.s.Value);


                Retry:


                    switch (d.s.Key)
                    {
                        case 100://コネクタ実装チェック
                            if (await ConnectorCheck.CheckConnector()) break;
                            goto case 5000;

                        case 200://K3 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.RC)) break;
                            goto case 5000;

                        case 201://K4 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.RH)) break;
                            goto case 5000;

                        case 202://K5 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.CHSTON)) break;
                            goto case 5000;

                        case 203://K6 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.MF)) break;
                            goto case 5000;

                        case 204://K7 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.BON)) break;
                            goto case 5000;

                        case 205://K8 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.PD)) break;
                            goto case 5000;

                        case 206://K9 チェック
                            if (await CheckOutputTB2.Check(INPUT_NAME.MENTE)) break;
                            goto case 5000;


                        case 300://CM チェック
                            if (await CheckOutputTB1.Check(INPUT_NAME.CM)) break;
                            goto case 5000;

                        case 301://HM チェック
                            if (await CheckOutputTB1.Check(INPUT_NAME.HM)) break;
                            goto case 5000;

                        case 302://EDM チェック
                            if (await CheckOutputTB1.Check(INPUT_NAME.EDM)) break;
                            goto case 5000;

                        case 400://TB1-CIR チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.CIR)) break;
                            goto case 5000;

                        case 401://TB1-HIR チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.HIR)) break;
                            goto case 5000;

                        case 402://TB1-THW チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.THW)) break;
                            goto case 5000;

                        case 403://TB1-ESC1 チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.ESC1)) break;
                            goto case 5000;

                        case 404://TB1-ESH1 チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.ESH1)) break;
                            goto case 5000;

                        case 405://TB1-ESON チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.ESON)) break;
                            goto case 5000;

                        case 406://TB1-ESOFF チェック
                            if (await CheckOutputCN26.CheckFromTb1(INPUT_NAME.ESOFF)) break;
                            goto case 5000;

                        case 407://CN10-CIR チェック
                            if (await CheckOutputCN26.CheckFromCn10(INPUT_NAME.CIR)) break;
                            goto case 5000;

                        case 408://CN10-HIR チェック
                            if (await CheckOutputCN26.CheckFromCn10(INPUT_NAME.HIR)) break;
                            goto case 5000;

                        case 409://CN10-ESC1 チェック
                            if (await CheckOutputCN26.CheckFromCn10(INPUT_NAME.ESC1)) break;
                            goto case 5000;

                        case 410://CN10-ESH1 チェック
                            if (await CheckOutputCN26.CheckFromCn10(INPUT_NAME.ESH1)) break;
                            goto case 5000;

                        case 411://CN11-CIR チェック
                            if (await CheckOutputCN26.CheckFromCn11(INPUT_NAME.CIR)) break;
                            goto case 5000;

                        case 412://CN11-HIR チェック
                            if (await CheckOutputCN26.CheckFromCn11(INPUT_NAME.HIR)) break;
                            goto case 5000;

                        case 413://CN11-ESC1 チェック
                            if (await CheckOutputCN26.CheckFromCn11(INPUT_NAME.ESC1)) break;
                            goto case 5000;

                        case 414://CN11-ESH1 チェック
                            if (await CheckOutputCN26.CheckFromCn11(INPUT_NAME.ESH1)) break;
                            goto case 5000;

                        case 500://VB チェック
                            if (await CheckOutputCN26.InputVB()) break;
                            goto case 5000;

                        case 501://CLS チェック
                            if (await CheckOutputCN26.InputCLS()) break;
                            goto case 5000;






                        case 5000://NGだっときの処理

                            FailStepNo = d.s.Key;
                            FailTitle = d.s.Value;

                            await Task.Delay(500);

                            if (RetryCnt++ != Constants.RetryCount)
                            {
                                //リトライ履歴リスト更新
                                State.RetryLogList.Add(FailStepNo.ToString() + "," + FailTitle + "," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                                State.VmTestStatus.ColorRetry = Brushes.DodgerBlue;
                                goto Retry;

                            }

                            goto FAIL; //作業者がリトライ処理をキャンセルしたのでFAIL終了処理へ

                    }

                    //↓↓各ステップが合格した時の処理です↓↓
                    SetTestLog("---- PASS\r\n");

                    //リトライステータスをリセットする
                    RetryCnt = 0;
                    State.VmTestStatus.ColorRetry = Brushes.Transparent;


                    State.VmTestStatus.進捗度 = (int)(((d.i + 1) / (double)テスト項目最新.Count()) * 100);

                }


                //↓↓すべての項目が合格した時の処理です↓↓
                General.ResetIo();
                await Task.Delay(500);



                if (Flags.日常点検中)
                {
                    if (State.VmTestStatus.CheckUnitTest != true) //null or False アプリ立ち上げ時はnullになっている！
                    {
                        using (var file = new System.IO.StreamWriter(Constants.fileName_日常点検, true, Encoding.GetEncoding("Shift_JIS")))
                        {
                            file.WriteLine(System.DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss"));
                        }
                        Flags.State日常点検 = true;
                        State.VmTestStatus.Color日常点検 = Brushes.DodgerBlue;
                    }

                    State.VmTestStatus.Message = Constants.MessRemove;
                }
                else
                {
                    if (State.VmTestStatus.CheckUnitTest != true) //null or False アプリ立ち上げ時はnullになっている！
                    {
                        //通しで試験が合格したときの処理です

                        //念のため、検査データ保存前にホストＰＣとの接続をチェックする
                        //試験中に誤ってホストＰＣの電源をOFFしてしまう可能性があるため！！！
                        Flags.StateHostPc = General.CheckHostConnection();

                        if (!Flags.StateHostPc || /*ホスト接続失敗*/
                            !General.SaveTestData() || /*試験データの保存失敗*/
                            !General.SaveTestLog() /*検査成績書印刷用のログ生成失敗*/
                            )
                        {
                            FailStepNo = 5000;
                            FailTitle = "ホストＰＣ接続";
                            goto FAIL_DATA_SAVE;
                        }


                        //当日試験合格数をインクリメント
                        State.VmTestStatus.OkCount = (State.Setting.TodayOkCount++).ToString() + "台";

                        //合格印押し
                        await General.合格印();

                    }
                    else
                    {
                        //１項目試験が合格したときの処理です
                        State.VmTestStatus.Message = Constants.MessRemove;
                    }
                }


                FlagTestTime = false;


                State.VmTestStatus.Colorlabel判定 = Brushes.White;
                State.VmTestStatus.Decision = Flags.BattleMode ? "WIN" : "PASS";
                State.VmTestStatus.ColorDecision = effect判定表示PASS;

                ResetRing();
                SetDecision();
                SbPass();

                General.PlaySound(General.soundPass);

                await Task.Run(() =>
                {
                    while (true)
                    {
                        if (!General.CheckPress()) break;//通常はこちらの条件式で判定する。
                        Thread.Sleep(300);
                    }
                });

                return;

            //不合格時の処理
            FAIL:


                if (Flags.AddDecision)
                {
                    SetTestLog("---- FAIL\r\n");
                }

                General.ResetIo();
                await Task.Delay(500);



            FAIL_DATA_SAVE:

                FlagTestTime = false;

                //当日試験不合格数をインクリメント
                State.VmTestStatus.NgCount = (State.Setting.TodayNgCount++).ToString() + "台";
                await Task.Delay(100);

                State.VmTestStatus.Colorlabel判定 = Brushes.White;
                State.VmTestStatus.Decision = "FAIL";
                State.VmTestStatus.ColorDecision = effect判定表示FAIL;

                SetErrorMessage(FailStepNo, FailTitle);
                State.VmTestStatus.Message = Constants.MessRemove;

                var NgDataList = new List<string>()
                                    {
                                        State.VmMainWindow.Opecode,
                                        State.VmMainWindow.Operator,
                                        System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                        State.VmTestStatus.FailInfo,
                                        State.VmTestStatus.Spec,
                                        State.VmTestStatus.MeasValue
                                    };

                General.SaveNgData(NgDataList);


                ResetRing();
                SetDecision();
                SetErrInfo();
                SbFail();

                General.PlaySound(General.soundFail);

                await Task.Run(() =>
                {
                    while (true)
                    {
                        if (!General.CheckPress()) break;
                        Thread.Sleep(100);
                    }
                });

                return;

            }
            catch
            {
                MessageBox.Show("想定外の例外発生DEATH！！！\r\n申し訳ありませんが再起動してください");
                Environment.Exit(0);

            }
            finally
            {
                State.Setting.TotalTestCount++;//トータルテスト回数は内部的に保持するだけでViewには表示しない
                General.ResetIo();
                SbRingLoad();

                General.ResetViewModel();
                RefreshDataContext();
            }

        }

        //フォームきれいにする処理いろいろ
        private void ClearForm()
        {
            SbRingLoad();
            RefreshDataContext();
        }


        private void SetErrorMessage(int stepNo, string title)
        {
            State.VmTestStatus.FailInfo = "エラーコード " + stepNo.ToString("00") + "   " + title + "異常";
        }


        //テストログの更新
        private void SetTestLog(string addData)
        {
            State.VmTestStatus.TestLog += addData;
        }




        private void ResetRing()
        {
            State.VmTestStatus.RingVisibility = System.Windows.Visibility.Hidden;

        }

        private void SetDecision()
        {
            State.VmTestStatus.DecisionVisibility = System.Windows.Visibility.Visible;
        }
        private void SetErrInfo()
        {
            State.VmTestStatus.ErrInfoVisibility = System.Windows.Visibility.Visible;
        }



    }
}
