using System;
using System.Collections.Generic;
using System.Text;

namespace vehicle.Car
{
    class Cars : Vehicles
    {
        string color;
        public override void input()
        {
            base.input();
            Console.WriteLine("Input color:");
            color = Console.ReadLine();
        }
        public override void display()
        {
            base.display();
            Console.WriteLine("Color:"+color);
        } 
    }
}
