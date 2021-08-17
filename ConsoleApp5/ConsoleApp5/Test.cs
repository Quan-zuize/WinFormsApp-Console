using System;
using System.Collections.Generic;
using System.Text;
using vehicle.Car;
using vehicle.Truck;

namespace vehicle.test
{
    class Test
    {
        
        static void Main(string[] args)
        {
            Cars car = new Cars();
            Trucks truck = new Trucks();

            List<Cars> carss = new List<Cars>(); 
            List<Trucks> truckss = new List<Trucks>();

            
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Mời bạn nhập lựa chọn sau:");
                Console.WriteLine("1.input");
                Console.WriteLine("2.display");
                Console.WriteLine("3.Sort by price");
                Console.WriteLine("4.Sort by model");
                Console.WriteLine("5.Exit");
                int choose;
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        car.input();
                        truck.input();
                        Console.WriteLine("/n");
                        carss.Add(car);
                        truckss.Add(truck);
                        break;
                    case 2:
                        foreach (Cars c in carss)
                        {
                            car.display();
                        }
                        Console.WriteLine("/n");    
                        foreach (Trucks t in truckss)
                        {
                            truck.display();
                        }
                        break;
                    case 3:
                        foreach (Cars c in carss)
                        {
                            car.display();
                        }
                        Console.WriteLine("/n");
                        foreach (Trucks t in truckss)
                        {
                            truck.display();
                        }
                        carss.Sort();
                        Console.WriteLine("/n");
                        truckss.Sort();
                        foreach (Cars c in carss)
                        {
                            car.display();
                        }
                        foreach (Trucks t in truckss)
                        {
                            truck.display();
                        }
                        break;
                    case 4:
                        break;
                    case 5:
                        default:
                        break;
                }

            }
        }
    }
}
