using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutDemo
{
    class Program
    {
        public readonly string bb;

        Program() {
            bb = "eqwe";
            bb = "11";
            Console.WriteLine("bb:"+ bb);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int a =3;
       
            int b = 5; 
            Swap(a, b); 
            Console.WriteLine("a={0} b={1}", a, b);
            Console.ReadKey();

        }

        static void Swap(int a, int b) {
            Console.WriteLine(a+b);
            int t = 0;
            t = a; 
            a = b; 
            b = t; 
        }
    }
}
