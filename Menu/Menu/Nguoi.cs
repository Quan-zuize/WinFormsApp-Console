using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Nguoi
    {
        public int Id, Tuoi;
        public String Ten;

        public string id { get; set; }
        public string ten { get; set; }
        public double tuoi { get; set; }

        public virtual void input()
        {
            Console.Write("Enter id: ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            Ten = Console.ReadLine();
        LuuY:
            Console.WriteLine("Enter age. ");
            Console.Write("Age must be in 0 and 200 : ");
            Tuoi = Int32.Parse(Console.ReadLine());
            if (Tuoi < 0 || Tuoi > 200)
            {
                goto LuuY;
            }
        }

        public virtual void display()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Ten);
            Console.WriteLine("Age: " + Tuoi);
        }
    }
}
