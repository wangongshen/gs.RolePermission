using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutDemo
{
    static class Program
    {
        //public readonly string bb;


        static void Main(string[] args)
        {
            //Program program = new Program();
            //int a =3;

            //int b = 5; 
            //Swap(a, b); 
            //Console.WriteLine("a={0} b={1}", a, b);



            int num = 2;
            Console.WriteLine("num1:" + num);
            num =num.GetT();
            Console.WriteLine("num2:"+num);
            Console.ReadKey();

        }

        #region 扩展方式
        public static int GetT(this int num)
        {
            //计算值的2倍
            return 2 * num;
        }
        #endregion

        #region ref和out
        static void Swap(int a, int b)
        {
            Console.WriteLine(a + b);
            int t = 0;
            t = a;
            a = b;
            b = t;
        }
        #endregion

    }
}
