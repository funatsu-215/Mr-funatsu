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
            var keisan = new Keisan1();

            //Random aite = new System.Random();
            keisan.Aite = 1; //aite.Next(1, 4);
                
            Console.WriteLine("どれを出す？");
            Console.WriteLine("1:グー\t2:チョキ\t3:パー");
            keisan.Jibun = int.Parse(Console.ReadLine());

            //相手の手を表示
            Console.WriteLine("相手の手 \t {0}", keisan.Aite);
            keisan.Sasihiki();
            //計算結果確認用
            keisan.Kekka();
            //return確認（クラス）
            keisan.Method();

            //勝敗結果確認（継承先から呼び出し）
            var shouhai = new Shouhai1();
            shouhai.Shouhai2();

            shouhai.Kakunin();
        }
    }
}
