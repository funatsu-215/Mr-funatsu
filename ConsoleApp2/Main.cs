using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int cpu_count;
            int player_count;
            int times;
            while (true)
            {
                while (true)
                {
                    try
                    {
                        //cpu人数入力
                        Console.WriteLine("cpu人数:半角英数字で入力してね");
                        cpu_count = int.Parse(Console.ReadLine());
                    }
                    catch (System.Exception) 
                    {
                        Console.WriteLine("※※半角英数字で入力してください※※");
                        Console.WriteLine("※※0～2147483647で入力してください※※\n");
                        continue;
                    }                  
                    if (cpu_count >= -2147483647 && cpu_count <= -1) //マイナス値をキャッチ
                    {
                        Console.WriteLine("※※人数がマイナス...?※※");
                        Console.WriteLine("※※もう一度入力してね※※\n");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    try
                    {
                        //player人数入力
                        Console.WriteLine("player人数:半角英数字で入力してね");
                        player_count = int.Parse(Console.ReadLine());
                    }
                    catch (System.Exception) 
                    {
                        Console.WriteLine("※※半角英数字で入力してください※※");
                        Console.WriteLine("※※0～2147483647で入力してください※※\n");
                        continue;
                    }
                    break;
                }
                if ((cpu_count == 1 && player_count == 0) || (cpu_count == 0 && player_count == 1) || (cpu_count == 0 && player_count == 0))
                {
                    Console.WriteLine("※※相手がいなきゃじゃんけんできんよ※※");
                    Console.WriteLine("※※もう一度入力してね※※\n");
                    continue;
                }
                else if (player_count >= -2147483647 && player_count <= -1) //マイナス値をキャッチ
                {
                    Console.WriteLine("※※人数がマイナス...?※※");
                    Console.WriteLine("※※もう一度入力してね※※\n");
                    continue;
                }
                else break;
            }
            while (true)
            {
                try
                {
                    //回数入力
                    Console.WriteLine("回数");
                    times = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)　
                {
                    Console.WriteLine("※※半角英数字で入力してください※※");
                    Console.WriteLine("※※0～2147483647で入力してください※※\n");
                    continue;
                }
                if (times == 0) //０回をキャッチ
                {
                    Console.WriteLine("※※なにもしないんだったら起動しないで※※");
                    continue;
                }
                break;
            }
            //クラス作成:コンストラクタ値渡し
            var HandDecision = new HandDecision(player_count, cpu_count, times);
            //継承クラス作成：コンストラクタ値渡し
            var WinDecision = new WinDecision(player_count, cpu_count, times);
            var WinRate = new WinRate(player_count, cpu_count, times);
            //乱数初期化
            var ransu = new System.Random();

            for (int k = 1; k <= times; k++)
            {
                Console.WriteLine("{0}回目", k);

                //あいこの時継続させる:それ以外は抜け出す
                while (WinDecision.Continues == 0)
                {
                    //cpuの手決定：乱数
                    for (int i = 0; i < cpu_count; i++)
                    {
                        HandDecision.cpu_hand[i] = ransu.Next(0, 3);
                        WinDecision.cpu_hand[i] = HandDecision.cpu_hand[i];
                    }
                    //playerの手決定:入力
                    for (int i = 0; i < player_count; i++)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※");
                                Console.WriteLine("※※　Player({0})は何を出す？数字で選んでね 　　※※", i);
                                Console.WriteLine("※※　　　　0:グー　1:チョキ　2:パー　　　　　※※");
                                Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※");
                                HandDecision.player_hand[i] = int.Parse(Console.ReadLine());
                            }
                            catch (System.FormatException) //文字をキャッチ
                            {
                                Console.WriteLine("※※半角英数字で入力してください※※\n");
                                continue;
                            }
                            catch (System.OverflowException) //int型を超える整数をキャッチ
                            {
                                Console.WriteLine("※※0～2147483647で入力してください※※\n");
                                continue;
                            }
                            if (HandDecision.player_hand[i] >= -2147483647 && HandDecision.player_hand[i] <= -1)
                            {
                                Console.WriteLine("目見えてますか？？\n");
                                continue;
                            }
                            else if (HandDecision.player_hand[i] >= 3)
                            {
                                Console.WriteLine("目見えてますか？？\n");
                                continue;
                            }
                            break;
                        }

                        WinDecision.player_hand[i] = HandDecision.player_hand[i];
                    }
                    //Cpuの手を表示
                    HandDecision.CpuHand();
                    //Playerの手を表示
                    HandDecision.PlayerHand();
                    //結果表示
                    WinDecision.Result();
                    for(int i = 0; i < player_count; i++)
                    {
                        WinRate.player_victory_number[i] = WinDecision.player_victory_number[i];
                    }
                    for (int i = 0; i < cpu_count; i++)
                    {
                        WinRate.cpu_victory_number[i] = WinDecision.cpu_victory_number[i];
                    }
                    //ビット演算初期化
                    WinDecision.result = 0;
                }
                WinDecision.Continues = 0;
            }
            WinRate.PlayerWinningPercentage();
            WinRate.CpuWinningPercentage();
            Console.ReadLine();
        }
    }
}