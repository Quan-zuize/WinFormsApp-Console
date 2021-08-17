using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<SinhvienCNTT> list = new List<SinhvienCNTT>();
            int n;
            Console.WriteLine("Nhập số sinh viên CNTT : ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                SinhvienCNTT sv = new SinhvienCNTT();
                sv.setSV();
                list.Add(sv);
            }

            foreach (SinhvienCNTT SV in list)
            {
                if (SV.tongdiem() > 10)
                {
                    Console.WriteLine("Các sinh viên có tổng điểm hơn 10 là ");
                    SV.viewSV();
                }
            }
            Console.WriteLine();
            foreach (SinhvienCNTT SV in list)
            {
                if (SV.tongdiem() < 5)
                {
                    Console.WriteLine("Các sinh viên có tổng điểm nhỏ hơn 5 là ");
                    SV.viewSV();
                }
            }
        }
    }
}
