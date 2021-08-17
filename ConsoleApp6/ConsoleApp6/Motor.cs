using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor
{
    class Motor : IMotor
    {
        String code; // Mã xe
        String name; // Tên loại xe
        double capacity; // Dung tích xi lanh
        int num; // Kiểu truyền lực là mấy số

        public string Code { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        public int Num { get; set; }

        public Motor()
        {

        }

        public Motor(string _code, string _name, double _capacity, int _num)
        {
            code = _code;
            name = _name;
            capacity = _capacity;
            num = _num;

        }
        public void changeInfo()
        {
            throw new NotImplementedException();
        }

        public virtual void displayInfo()
        {
            Console.WriteLine("Code: " + code);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Capacity: " + capacity);
            Console.WriteLine("Num: " + num);
        }

        public virtual void inputInfo()
        {
            Console.Write("Enter code: ");
            code = Console.ReadLine();
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter capacity: ");
            capacity = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter num: ");
            num = Convert.ToInt32(Console.ReadLine());
        }
    }
}
