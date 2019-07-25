using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Shouhai1 : Keisan1
    {
        public void Shouhai2()
        {
            if (Sasihiki() == -1 || Sasihiki() == 2)
            {
                Console.WriteLine("あなたの勝ち");
                Console.ReadLine();
            }
            else if (Sasihiki() == 1 || Sasihiki() == -2)
            {
                Console.WriteLine("あなたの負け");
                Console.ReadLine();
            }
            else if (Sasihiki() == 0)
            {
                Console.WriteLine("あいこ");
                Console.ReadLine();
            }
        }
        public void Kakunin()
        {
            Console.WriteLine("自分{0}　-　相手{1} =　結果{2}", jibun, aite, jibun - aite);
            Console.ReadLine();
        }
    }
}
