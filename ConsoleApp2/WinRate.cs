using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class WinRate : WinDecision
    {
        public WinRate(int player_count, int cpu_count, int times) : base(player_count, cpu_count, times)
        {
            player_winning_percentage = new float[player_count];
            cpu_winning_percentage = new float[cpu_count];
            //player_victory_number = new int[player_count];
            //cpu_victory_number = new int[cpu_count];
        }
        public void PlayerWinningPercentage()
        {
            Console.WriteLine("勝率");
            Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
            for (int i = 0; i < player_hand.Length; i++)
            {
                player_winning_percentage[i] = (100 * player_victory_number[i]) / times;
                Console.WriteLine("※※PLAYER({0})　{1}勝　勝率{2}%　　　　　　　　　　　　※※", i, player_victory_number[i], player_winning_percentage[i]);
            }
        }
        public void CpuWinningPercentage()
        {
            for (int i = 0; i < cpu_hand.Length; i++)
            {
                cpu_winning_percentage[i] = (100 * cpu_victory_number[i]) / times;
                Console.WriteLine("※※CPU({0})　{1}勝　勝率{2}%　　　　　　　　　　　　　　※※", i, cpu_victory_number[i], cpu_winning_percentage[i]);
            }
            Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
        }
    }
}
