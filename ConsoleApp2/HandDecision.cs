using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class HandDecision : Base
    {
        public HandDecision(int player_count, int cpu_count, int times) : base(player_count, cpu_count, times)
        {
            /*
            cpu_hand = new int[cpu_count];
            player_hand = new int[player_count];
            this.cpu_count = cpu_count;
            this.player_count = player_count;
            */
        }   
        public void CpuHand()
        {
            for (int i = 0; i < cpu_hand.Length; i++)
            {
                if (cpu_hand[i] == 0)
                {
                    Console.WriteLine("CPU({0})の手　　 ==>　グー", i);
                }
                else if (cpu_hand[i] == 1)
                {
                    Console.WriteLine("CPU({0})の手　　 ==>　チョキ", i);
                }
                else if (cpu_hand[i] == 2)
                {
                    Console.WriteLine("CPU({0})の手　　 ==>　パー", i);
                }
                else
                {
                    Console.WriteLine("エラーです、管理人に報告してください");
                }
            }
        }
        public void PlayerHand()
        {
            for (int i = 0; i < player_hand.Length; i++)
            {
                if (player_hand[i] == 0)
                {
                    Console.WriteLine("PLAYER({0})の手　==>　グー", i);
                }
                else if (player_hand[i] == 1)
                {
                    Console.WriteLine("PLAYER({0})の手　==>　チョキ", i);
                }
                else if (player_hand[i] == 2)
                {
                    Console.WriteLine("PLAYER({0})の手　==>　パー", i);
                }
                else
                {
                    Console.WriteLine("エラーです、管理人に報告してください");
                }
            }
            Console.WriteLine("\n");
        }
    }
}