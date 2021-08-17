using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor
{
    class Jupiter : Motor
    {
        int warranty;
        public string Warranty { get; set; }
        public override void inputInfo()
        {
            base.inputInfo();
            Console.Write("Enter warranty: ");
            warranty = Convert.ToInt32(Console.ReadLine());
        }
        public override void displayInfo()
        {
            base.displayInfo();
            Console.WriteLine("Warranty: "+ warranty);
        }
    }
}
