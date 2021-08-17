using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor
{
    class Motor : IMotor
    {
        string code;
        string name;
        double capacity;
        int num;

        public Motor() { }

        public Motor(string code, string name, double capacity, int num)
        {
            this.code = code;
            this.name = name;
            this.capacity = capacity;
            this.num = num;
        }
        public string Code { get; set; }
        public string Name { get { return name; } set { } }
        public double Capacity { get { return capacity; } set { }}
        public int Num { get; set; }

        public virtual void inputInfo()
        {
            Console.Write("Enter id: ");
            code = Console.ReadLine();
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter capacity: ");
            capacity = Double.Parse(Console.ReadLine());
            Console.Write("Enter num: ");
            num = int.Parse(Console.ReadLine());
        }
        public virtual void displayInfo()
        {
            Console.Write($"|Code: {code} |Name: {name} |Capacity: {capacity} |Num: {num} |");
        }
        public virtual void changeInfo()
        {

        }
    }
}
