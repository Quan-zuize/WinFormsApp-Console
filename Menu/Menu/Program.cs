using System;
using System.Collections.Generic;

namespace Menu
{
    class Program
    {
        public static List<Sinhvien> svList = new List<Sinhvien>();

        static int a;
        public static void menu()
        {

            Console.WriteLine("1.Input");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Find");
            Console.WriteLine("4.Exit");
            while (true)
            {
                Console.Write("Enter your choice: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Enter number of student: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < a; i++)
                        {
                            Console.WriteLine($"Input information of student {i + 1}");
                            Sinhvien sv = new Sinhvien();
                            sv.input();
                            svList.Add(sv);
                        }
                        break;
                    case 2:
                        foreach (Sinhvien svien in svList)
                        {
                            svien.display();
                        }
                        break;
                    case 3:
                        Console.Write("Enter name to search: ");
                        string name = Console.ReadLine();
                        Sinhvien svfound = svList.Find(
                            (Sinhvien svsv) => { return svsv.Ten == name; });
                        if(svfound != null)
                        {
                            svfound.display();
                        }
                        break;
                    case 4:
                        svList.Sort();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            menu();
        }
    }
}
