using System;
using System.Collections.Generic;
using System.Text;

namespace vehicle.Truck
{
    class Trucks : Vehicles
    {
        int truckload;
        public override void input()
        {
            base.input();
            Console.WriteLine("Input truckload:");
            truckload = Convert.ToInt32(Console.ReadLine());
        }
        public override void display()
        {
            base.display();
            Console.WriteLine("Truckload:" + truckload);
        }
    }
}
