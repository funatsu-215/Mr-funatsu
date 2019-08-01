using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class1
    {
        public int[] cpu;
        public int[] player;
        public int kaisu;
        protected int cpuninzu;
        protected int playerninzu;
        public int kekka = 0;
        public int goukei = 0;
        public Class1(int playerninzu,int cpuninzu, int kaisu)
        {
            cpu = new int[cpuninzu];
            player = new int[playerninzu];
            this.cpuninzu = cpuninzu;
            this.playerninzu = playerninzu;
            this.kaisu = kaisu;
        }
        public int CpuNinzu
        {
            set { cpuninzu = value; }
            get { return cpuninzu; }
        }
        public int PlayerNinzu
        {
            set { playerninzu = value; }
            get { return playerninzu; }
        }
        public int Kaisu
        {
            set { kaisu = value; }
            get { return kaisu; }
        }

        public void Cpute()
        {
            for (int i = 0; i < cpu.Length; i++)
            {
                if (cpu[i] == 0)
                {
                    Console.WriteLine("CPU({0})の手　==>　グー",i);
                }
                else if (cpu[i] == 1)
                {
                    Console.WriteLine("CPU({0})の手　==>　チョキ",i);
                }
                else if (cpu[i] == 2)
                {
                    Console.WriteLine("CPU({0})の手　==>　パー",i);
                }
                else
                {
                    Console.WriteLine("エラーです、管理人に報告してください");
                }
            }
        }
        public void Playerte()
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i] == 0)
                {
                    Console.WriteLine("PLAYER({0})の手　==>　グー", i);
                }
                else if (player[i] == 1)
                {
                    Console.WriteLine("PLAYER({0})の手　==>　チョキ", i);
                }
                else if (player[i] == 2)
                {
                    Console.WriteLine("PLAYER({0})の手　==>　パー", i);
                }
                else
                {
                    Console.WriteLine("エラーです、管理人に報告してください");
                }
            }
        }
        //kekka()のあった位置
        

    }
}
