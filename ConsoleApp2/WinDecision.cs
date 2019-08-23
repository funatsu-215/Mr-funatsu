using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class WinDecision : Base
    {
        public WinDecision(int player_count, int cpu_count, int times) : base(player_count, cpu_count, times)
        {
            /*
            this.cpu_count = cpu_count;
            this.player_count = player_count;
            this.times = times;
            cpu_hand = new int[cpu_count];
            player_hand = new int[player_count];
            player_victory_number = new int[player_count];
            cpu_victory_number = new int[cpu_count];
            */
        }
        public int Continues
        {
            set { continues = value; }
            get { return continues; }
        }
        public void Result()
        {
            Console.WriteLine("勝者は.........");
            Console.WriteLine("\n");
            for (int i = 0; i < player_hand.Length; i++)
            {
                result = result | (1 << player_hand[i]);
            }
            for (int i = 0; i < cpu_hand.Length; i++)
            {
                result = result | (1 << cpu_hand[i]);
            }

            if (result == 1 || result == 2 || result == 4 || result == 7)
            {
                Console.WriteLine("あいこだよ");
                continues = 0;
            }
            else if (result == 6)
            {
                Console.WriteLine("チョキの勝ち");
                for (int i = 0; i < player_hand.Length; i++)
                {
                    if (player_hand[i] == 1)
                    {
                        Console.WriteLine("PLAYER({0})", i);
                        player_victory_number[i] += 1;
                    }
                    else if (player_hand[i] == 0 || player_hand[i] == 2)
                    {
                        player_victory_number[i] += 0;
                    }
                }
                for (int i = 0; i < cpu_hand.Length; i++)
                {
                    if (cpu_hand[i] == 1)
                    {
                        Console.WriteLine("CPU({0})", i);
                        cpu_victory_number[i] += 1;
                    }
                    else if (cpu_hand[i] == 0 || cpu_hand[i] == 2)
                    {
                        cpu_victory_number[i] += 0;
                    }
                }
                continues = 1;
            }
            else if (result == 5)
            {
                Console.WriteLine("パーの勝ち");
                for (int i = 0; i < player_hand.Length; i++)
                {
                    if (player_hand[i] == 2)
                    {
                        Console.WriteLine("PLAYER({0})", i);
                        player_victory_number[i] += 1;
                    }
                    else if (player_hand[i] == 0 || player_hand[i] == 2)
                    {
                        player_victory_number[i] += 0;
                    }
                }
                for (int i = 0; i < cpu_hand.Length; i++)
                {
                    if (cpu_hand[i] == 2)
                    {
                        Console.WriteLine("CPU({0})", i);
                        cpu_victory_number[i] += 1;
                    }
                    else if (cpu_hand[i] == 0 || cpu_hand[i] == 2)
                    {
                        cpu_victory_number[i] += 0;
                    }
                }
                continues = 1;
            }
            else if (result == 3)
            {
                Console.WriteLine("グーの勝ち");
                for (int i = 0; i < player_hand.Length; i++)
                {
                    if (player_hand[i] == 0)
                    {
                        Console.WriteLine("PLAYER({0})", i);
                        player_victory_number[i] += 1;
                    }
                    else if (player_hand[i] == 0 || player_hand[i] == 2)
                    {
                        player_victory_number[i] += 0;
                    }
                }
                for (int i = 0; i < cpu_hand.Length; i++)
                {
                    if (cpu_hand[i] == 0)
                    {
                        Console.WriteLine("CPU({0})", i);
                        cpu_victory_number[i] += 1;
                    }
                    else if (cpu_hand[i] == 0 || cpu_hand[i] == 2)
                    {
                        cpu_victory_number[i] += 0;
                    }
                }
                continues = 1;
            }
            else
            {
                Console.WriteLine("エラーが起きてるよ");
                Console.WriteLine("kekka{0}", result);
                continues = 2;
            }
            Console.WriteLine("\n");
        }
        
    }
}