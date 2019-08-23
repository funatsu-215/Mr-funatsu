using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Base
    {
        protected int cpu_count;
        protected int player_count;
        public int times;
        public int result = 0;
        public int continues = 0;
        public int[] cpu_hand;
        public int[] player_hand;
        public int[] player_victory_number;
        public int[] cpu_victory_number;
        public float[] player_winning_percentage;
        public float[] cpu_winning_percentage;

        public Base(int player_count, int cpu_count, int times)
        {
            this.cpu_count = cpu_count;
            this.player_count = player_count;
            this.times = times;
            cpu_hand = new int[cpu_count];
            player_hand = new int[player_count];
            player_victory_number = new int[player_count];
            cpu_victory_number = new int[cpu_count];
            player_winning_percentage = new float[player_count];
            cpu_winning_percentage = new float[cpu_count];
        }
    }
}
