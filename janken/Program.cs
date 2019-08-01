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
            //cpu人数入力
            Console.WriteLine("cpu人数");
            int cpuninzu = int.Parse(Console.ReadLine());
            //player人数入力
            Console.WriteLine("player人数");
            int playerninzu = int.Parse(Console.ReadLine());
            //回数入力
            Console.WriteLine("回数");
            int kaisu = int.Parse(Console.ReadLine());
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
                    //cpuの手:内容開示
                    foreach (int nakami in keisan.cpu)
                    {
                        Console.WriteLine("{0}", nakami);
                    }
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
                foreach(int nakami in shouhai.pcount)
                {
                    Console.WriteLine("pcountの中身　{0}", nakami);
                }
                foreach(int nakami in shouhai.ccount)
                {
                    Console.WriteLine("ccountの中身　{0}", nakami);
                }
            }
            shouhai.Pshouritsu();
            shouhai.Cshouritsu();
            Console.ReadLine();
        }
    }
}
