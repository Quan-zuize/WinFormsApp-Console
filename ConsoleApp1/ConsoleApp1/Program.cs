using System;

namespace ConsoleApp1
{
    class Program
    {
        public static System.Random random = new System.Random();
        public static int[] TaoMang1Chieu(int soPhanTu)
        {
            int[] ar = new int[soPhanTu];
            for (int i = 0; i < soPhanTu; i++)
            {
                ar[i] = random.Next();
            }
            return ar;
        }
        public static int[,] TaoMang2Chieu(int a, int b)
        {
            int[,] ar = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    ar[i, j] = random.Next();
                }
            }
            return ar;
        }
        static void Main(string[] args)
        {
            int[,] arr2D = TaoMang2Chieu(3, 2);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("Phan tu thu {0}; {1}; {2} ", i, j, arr2D[i, j]);
                }
            }
        }
    }
}
