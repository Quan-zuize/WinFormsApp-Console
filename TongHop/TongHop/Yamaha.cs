using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace motor.yamaha
{
    class Yamaha
    {
        static List<Serius> seriusList = new List<Serius>();
        static List<Jupiter> jupitersList = new List<Jupiter>();
        public static void menu()
        {
            Console.WriteLine("1.Input");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Sort");
            Console.WriteLine("4.Search");
            Console.WriteLine("5.Exit");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                menu();
                Console.Write("Enter your choice: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        input();
                        break;
                    case 2:
                        display();
                        break;
                    case 3:
                        sort();
                        break;
                    case 4:
                        find();
                        break;
                    case 5:
                        return;
                }
            }

        }
        public static void input()
        {
        A:
            Console.Write("Enter the number of jupiter vehicles, at least 3 : ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a < 3) goto A;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Information jupiter " + (i + 1));
                Jupiter j = new Jupiter();
                j.inputInfo();
                jupitersList.Add(j);
            }
        B:
            Console.Write("Enter the number of serius vehicles, at least 3 : ");
            int b = Convert.ToInt32(Console.ReadLine());
            if (b < 3) goto B;
            for (int i = 0; i < b; i++)
            {
                Console.WriteLine("Information serius " + (i + 1));
                Serius s = new Serius();
                s.inputInfo();
                seriusList.Add(s);
            }
        }

        public static void display()
        {
            foreach (Jupiter j in jupitersList)
            {
                j.displayInfo();
            }
            foreach (Serius s in seriusList)
            {
                s.displayInfo();
            } 
        }
        public static void sort()
        {
            Console.WriteLine("Before sort");
            display();
            Console.WriteLine("After sort");
            List<Serius> sortedSerList = seriusList.OrderBy(s => s.Capacity).ToList();
            List<Jupiter> sortedJupList = jupitersList.OrderBy(j => j.Capacity).ToList();

            foreach (Jupiter j in sortedJupList)
            {
                j.displayInfo();
            }
            foreach (Serius s in sortedSerList)
            {
                s.displayInfo();
            }
        }

        public static void find()
        {
            int type;
            string search;

            do
            {
                Console.Write("Choose type to search(0 = Serius; 1 = Jupiter): ");
                type = Convert.ToInt16(Console.ReadLine());
            } while (!(type == 1 || type == 0));

            Console.Write("Enter name to search: ");
            search = Console.ReadLine();
            if (type == 0)
            {
                Serius findSer = seriusList.Find(s => s.Name.Equals(search));
                findSer.displayInfo();
            }
            if (type == 1)
            {
                Jupiter findJup = jupitersList.Find(j => j.Name.Equals(search));
                findJup.displayInfo();
            }

        }
    }
}
