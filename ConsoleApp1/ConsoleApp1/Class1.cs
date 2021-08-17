using System;
using System.Text;

namespace ConsoleApp1
{
    class Class1
    {
        static int[] TaoMang1Chieu_DiemToan()
        {
            int[] Diem = new int[6];
            Diem[0] = 2;
            Diem[1] = 4;
            Diem[2] = 10;
            Diem[3] = 7;
            Diem[4] = 6;
            Diem[5] = 0;
            return Diem;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int[] mang1 = TaoMang1Chieu_DiemToan();
            for (int i = 0; i < mang1.Length; i++)
            {
                String comment = (mang1[i] >= 8 && mang1[i] <= 10) ? "gioi" : (mang1[i] >= 6.5 && mang1[i] < 8) ? "kha" : (mang1[i] >= 5 && mang1[i] < 6.5) ? "trung binh" : (mang1[i] >= 3 && mang1[i] < 5) ? "kem" : (mang1[i] >= 0 && mang1[i] < 3) ? "yeu" : "diem nam tu 1 den 10";
                Console.WriteLine("Hoc sinh dat diem " + mang1[i] + ":" + comment);
            }
        }
    }
}
