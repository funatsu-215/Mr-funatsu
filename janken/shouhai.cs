using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Keishou1 : Class1
    {
        public int kekka = 0;
        public int zokkou = 0;
        public int[] pcount;
        public int[] ccount;
        public float[] pshouritsu;
        public float[] cshouritsu;
        public Keishou1(int playerninzu, int cpuninzu, int kaisu) : base(playerninzu,cpuninzu,kaisu)
        {
            pshouritsu = new float[playerninzu];
            cshouritsu = new float[cpuninzu];
            pcount = new int[playerninzu];
            ccount = new int[cpuninzu];
        }
        public int Zokkou
        {
            set { zokkou = value; }
            get { return zokkou; }
        }
        public void Kekka()
        {
            Console.WriteLine("勝者は.........");
            Console.WriteLine("\n");
            for (int i = 0; i < player.Length; i++)
            {
                kekka = kekka | (1 << player[i]);
            }
            for (int i = 0; i < cpu.Length; i++)
            {
                kekka = kekka | (1 << cpu[i]);
            }

            if (kekka == 1 || kekka == 2 || kekka == 4 || kekka == 7)
            {
                Console.WriteLine("あいこだよ");
                zokkou = 0;
            }
            else if (kekka == 6)
            {
                Console.WriteLine("チョキの勝ち");
                for (int i = 0; i < player.Length; i++)
                {
                    if (player[i] == 1)
                    {
                        Console.WriteLine("PLAYER({0})", i);
                        pcount[i] += 1;
                    }
                    else if (player[i] == 0 || player[i] == 2)
                    {
                        pcount[i] += 0;
                    }
                }
                for (int i = 0; i < cpu.Length; i++)
                {
                    if (cpu[i] == 1)
                    {
                        Console.WriteLine("CPU({0})", i);
                        ccount[i] += 1;
                    }
                    else if (cpu[i] == 0 || cpu[i] == 2)
                    {
                        ccount[i] += 0;
                    }
                }
                zokkou = 1;
            }
            else if (kekka == 5)
            {
                Console.WriteLine("パーの勝ち");
                for (int i = 0; i < player.Length; i++)
                {
                    if (player[i] == 2)
                    {
                        Console.WriteLine("PLAYER({0})", i);
                        pcount[i] += 1;
                    }
                    else if (player[i] == 0 || player[i] == 2)
                    {
                        pcount[i] += 0;
                    }
                }
                for (int i = 0; i < cpu.Length; i++)
                {
                    if (cpu[i] == 2)
                    {
                        Console.WriteLine("CPU({0})", i);
                        ccount[i] += 1;
                    }
                    else if (cpu[i] == 0 || cpu[i] == 2)
                    {
                        ccount[i] += 0;
                    }
                }
                zokkou = 1;
            }
            else if (kekka == 3)
            {
                Console.WriteLine("グーの勝ち");
                for (int i = 0; i < player.Length; i++)
                {
                    if (player[i] == 0)
                    {
                        Console.WriteLine("PLAYER({0})", i);
                        pcount[i] += 1;
                    }
                    else if (player[i] == 0 || player[i] == 2)
                    {
                        pcount[i] += 0;
                    }
                }
                for (int i = 0; i < cpu.Length; i++)
                {
                    if (cpu[i] == 0)
                    {
                        Console.WriteLine("CPU({0})", i);
                        ccount[i] += 1;
                    }
                    else if (cpu[i] == 0 || cpu[i] == 2)
                    {
                        ccount[i] += 0;
                    }
                }
                zokkou = 1;
            }
            else
            {
                Console.WriteLine("エラーが起きてるよ");
                Console.WriteLine("kekka{0}", kekka);
                zokkou = 2;
            }
            Console.WriteLine("\n");
        }
        public void Pshouritsu()
        {
            Console.WriteLine("勝率");
            Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
            for (int i = 0; i < player.Length; i++)
            {
                pshouritsu[i] = (100 * pcount[i]) / kaisu;
                Console.WriteLine("※※PLAYER({0})　{1}勝　勝率{2}%　　　　　　　　　　　　※※", i,pcount[i], pshouritsu[i]);
            }
        }
        public void Cshouritsu()
        {
            for (int i = 0; i < cpu.Length; i++)
            {
                cshouritsu[i] = (100 * ccount[i]) / kaisu;
                Console.WriteLine("※※CPU({0})　{1}勝　勝率{2}%　　　　　　　　　　　　　　※※", i,ccount[i], cshouritsu[i]);
            }
            Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
        }
    }
}
