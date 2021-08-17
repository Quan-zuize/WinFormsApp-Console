using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Sinhvien : Nguoi
    {
        double diemToan;
        double diemHoa;
        public override void input()
        {
            base.input();
            Console.Write("Math Mark:");
            diemToan = Convert.ToDouble(Console.ReadLine());
            Console.Write("Chemitry Mark:");
            diemHoa = Convert.ToDouble(Console.ReadLine());
        }
        public override void display()
        {
            base.display();
            Console.WriteLine("Math's Mark: " + diemToan);
            Console.WriteLine("Chemitry's Mark: " + diemHoa);
        }
    }
}



