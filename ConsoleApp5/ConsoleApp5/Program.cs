using System;

namespace vehicle
{
    class Vehicles : IVehicle
    {
        String maker;

        String model;

        double price;

        public Vehicles(double price, string maker, string model)
        {
            this.price = price;
            this.maker = maker;
            this.model = model;
        }

        public Vehicles()
        {
        }

        public string Maker { get => maker; set => maker = value; }
        public string Model { get => model; set => model = value; }
        public double Price { get => price; set => price = value; }

        public virtual void input()
        {
            Console.WriteLine("Input maker:");
            maker = Console.ReadLine();
            Console.WriteLine("Input model:");
            model = Console.ReadLine();
            Console.WriteLine("Input price:");
            price = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void display()
        {
            Console.WriteLine(@"Maker:"+maker);
            Console.WriteLine(@"model:"+model);
            Console.WriteLine(@"price:"+price);
        }
    }
    
    
    public interface IVehicle
    {
        public void input() 
        {
        
        }
        public void display() 
        {
        
        }
    }
    class Program
    {
    }
}
