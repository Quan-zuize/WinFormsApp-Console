using System;
using System.Collections.Generic;
using System.Text;

namespace motor
{
    class Yamaha
    {
        static Jupiter jupiter = new Jupiter();
        static Serius serius = new Serius();

        static List<Jupiter> JupiterList = new List<Jupiter>();
        static List<Serius> SeriusList = new List<Serius>();
        static void Main(string[] args)
        {



            while (true)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1.Input");
                Console.WriteLine("2.Display");
                Console.WriteLine("3.Sort");
                Console.WriteLine("4.Search ");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        for(int i = 0; i < 3; i++)
                        {
                            nhapVao();
                        }                        
                        break;
                    case 2:
                        displayInfo();
                        break;
                    case 3:
                        sortByWarranty();
                        break;
                    case 4:
                        Console.Write("Enter model you want to search: ");
                        search(Console.ReadLine());
                        break;
                    case 5:
                    default:
                        Environment.Exit(0);
                        break;
                }

            }
        }
        public static void nhapVao()
        {
            jupiter.inputInfo();
            serius.inputInfo();
            Console.WriteLine("----------------------------------------");
            JupiterList.Add(jupiter);
            SeriusList.Add(serius);
        }

        public static void sortByWarranty()
        {
            foreach (Jupiter j in JupiterList)
            {
                jupiter.displayInfo();
            }
            Console.WriteLine();
            foreach (Serius s in SeriusList)
            {
                serius.displayInfo();
            }
            JupiterList.Sort();
            Console.WriteLine("----------------------------------------");
            SeriusList.Sort();
            foreach (Jupiter j in JupiterList)
            {
                jupiter.displayInfo();
            }
            foreach (Serius s in SeriusList)
            {
                serius.displayInfo();
            }
        }
        public static void displayInfo()
        {
            foreach (Jupiter j in JupiterList)
            {
                jupiter.displayInfo();
            }
            Console.WriteLine("----------------------------------------");
            foreach (Serius s in SeriusList)
            {
                serius.displayInfo();
            }
        }
        public static void search(String warr)
        {
            foreach (Jupiter j in JupiterList)
            {
                if (j.Warranty.Equals(warr))
                    jupiter.displayInfo();
                else
                    Console.WriteLine("There are no warranty " + warr + " in Jupiter list");
            }
            foreach (Serius s in SeriusList)
            {
                if (s.Warranty.Equals(warr))
                    serius.displayInfo();
                else
                    Console.WriteLine("There are no warranty " + warr + " in Serius list");
            }
        }
    }
}
