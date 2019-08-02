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
            int cpuninzu;
            int playerninzu;
            int kaisu;
            while (true)
            {
                while (true)
                {
                    try
                    {
                        //cpu人数入力
                        Console.WriteLine("cpu人数");
                        cpuninzu = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException) //文字入力、改行をキャッチ
                    {
                        Console.WriteLine("※※半角英数字で入力してください※※");
                        continue;
                    }
                    catch (System.OverflowException) //int型を超える整数をキャッチ
                    {
                        Console.WriteLine("※※0～2147483647で入力してください※※");
                        continue;
                    }
                    if (cpuninzu >= -2147483647 && cpuninzu <= -1) //マイナス値をキャッチ
                    {
                        Console.WriteLine("※※人数がマイナス...?※※");
                        Console.WriteLine("※※お前誰か殺すのか？※※");
                        Console.WriteLine("※※もう一度入力してね※※");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    try
                    {
                        //player人数入力
                        Console.WriteLine("player人数");
                        playerninzu = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException) //文字入力、改行をキャッチ
                    {
                        Console.WriteLine("※※半角英数字で入力してください※※");
                        continue;
                    }
                    catch (System.OverflowException) //int型を超える整数をキャッチ
                    {
                        Console.WriteLine("※※0～2147483647で入力してください※※");
                        continue;
                    }
                    break;
                }
                if ((cpuninzu == 1 && playerninzu == 0) || (cpuninzu == 0 && playerninzu == 1) || (cpuninzu == 0 && playerninzu == 0))
                {
                    Console.WriteLine("※※相手がいなきゃじゃんけんできんよ※※");
                    Console.WriteLine("※※もう一度入力してね※※");
                    continue;
                }
                else if(playerninzu >= -2147483647 && playerninzu <= -1) //マイナス値をキャッチ
                {
                    Console.WriteLine("※※人数がマイナス...?※※");
                    Console.WriteLine("※※お前誰か殺すのか？※※");
                    Console.WriteLine("※※もう一度入力してね※※");
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
                    kaisu = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)　//文字入力、改行をキャッチ
                {
                    Console.WriteLine("※※半角英数字で入力してください※※");
                    continue;
                }
                catch (System.OverflowException) //int型を超える整数をキャッチ
                {
                    Console.WriteLine("※※0～2147483647で入力してください※※");
                    continue;
                }
                if (kaisu == 0) //０回をキャッチ
                {
                    Console.WriteLine("※※なにもしないんだったら起動しないで※※");
                    continue;
                }
                break;
            }
            //クラス作成:コンストラクタ値渡し
            var keisan = new Class1(playerninzu,cpuninzu,kaisu);
            //継承クラス作成：コンストラクタ値渡し
            var shouhai = new Keishou1(playerninzu,cpuninzu,kaisu);

            //乱数初期化
            var ransu = new System.Random();

            for (int k = 1; k <= kaisu; k++)
            {
                Console.WriteLine("{0}回目", k);
                //あいこの時継続させる:それ以外は抜け出す
                while (shouhai.Zokkou == 0)
                {
                    //cpuの手決定：乱数
                    for (int i = 0; i < cpuninzu; i++)
                    {
                        keisan.cpu[i] = ransu.Next(0, 3);
                        shouhai.cpu[i] = keisan.cpu[i];
                    }
                    //cpuの手:内容開示（確認用）
                    //foreach (int nakami in keisan.cpu)
                    //{
                    //    Console.WriteLine("{0}", nakami);
                    //}
                    //playerの手決定:入力
                    for (int i = 0; i < playerninzu; i++)
                    {
                        Console.WriteLine("Player{0}は何を出す？数字で選んでね", i);
                        Console.WriteLine("0:グー　1:チョキ　2:パー");
                        keisan.player[i] = int.Parse(Console.ReadLine());
                        shouhai.player[i] = keisan.player[i];
                    }
                    //Cpuの手を表示
                    keisan.Cpute();
                    //Playerの手を表示
                    keisan.Playerte();
                    //結果表示
                    shouhai.Kekka();
                    //ビット演算初期化
                    shouhai.kekka = 0;
                }
                shouhai.Zokkou = 0;

                //確認用
                //foreach(int nakami in shouhai.pcount)
                //{
                //    Console.WriteLine("pcountの中身　{0}", nakami);
                //}
                //foreach(int nakami in shouhai.ccount)
                //{
                //    Console.WriteLine("ccountの中身　{0}", nakami);
                //}
            }
            shouhai.Pshouritsu();
            shouhai.Cshouritsu();
            Console.ReadLine();
        }
    }
}
