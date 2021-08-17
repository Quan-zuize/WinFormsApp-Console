using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.yamaha
{
    class Serius : Motor
    {
        int warranty;

        public int Warranty { get; set; }
        public override void inputInfo()
        {
            base.inputInfo();
            Console.Write("Enter Warranty: ");
            warranty = Convert.ToInt32(Console.ReadLine());

        }
        public override void displayInfo()
        {
            base.displayInfo();
            Console.WriteLine($"Warranty: {warranty} |");
        }
        public override void changeInfo()
        {
            base.changeInfo();
        }
    }
}
