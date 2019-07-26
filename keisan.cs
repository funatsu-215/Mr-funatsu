using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Class1
    {
        protected int jibun;
        protected int aite;
        protected int sasihiki;

        public int Jibun
        {
            set { jibun = value; }

            get { return jibun; }
        }
        public int Aite
        {
            set { aite = value; }

            get { return aite; }
        }
        public int Sasihiki()
        {
            sasihiki = jibun - aite;
            return sasihiki;
          
        }
        public void Method()
        {
            Console.WriteLine("クラスでの差し引き値　{0}", sasihiki);
        }
        public void Kekka()
        {
            Console.WriteLine("自分{0}　-　相手{1} =　結果{2}",jibun,aite,jibun-aite);
        }
    }
}
