using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Anoymous
    {
        public delegate void DisplayEx(string a, string b);
        public delegate string[] CreateFunction(int a);
        public void TestDelegate3()
        {
            DisplayEx m = delegate (string a, string b)
            {
                Console.WriteLine("Parameter a: " + a);
                Console.WriteLine("Paremeter b: " + b);
            };
            m("Minh", "Long");
            m.Invoke("Lan", "Linh");

            m += delegate (string c, string d)
            {
                Console.WriteLine("+= parameter c: " + c);
                Console.WriteLine("+= parameter d: " + d);
            };

            m += delegate (string X, String Y)
            {
                Console.WriteLine("+= parameter X: " + X);
                Console.WriteLine("+= parameter Y: " + Y);
            };
            m("Minh", "Ha");
            m.Invoke("Len", "Hung");
        }
        public void TestDelegate4()
        {
            CreateFunction function = delegate (int a)
            {
                string[] abc = new string[a];
                return abc;
            };
            function(5);
            Console.WriteLine(function.Invoke(6).Length);
        }
    }
}
