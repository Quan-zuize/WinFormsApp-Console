using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Array objEmployeeDetails = Array.CreateInstance(typeof(string), 2, 3);
            objEmployeeDetails.SetValue("141", 0, 0);
            objEmployeeDetails.SetValue("147", 0, 1);
            objEmployeeDetails.SetValue("152", 0, 2);
            objEmployeeDetails.SetValue("Joan Fuller", 1, 0);
            objEmployeeDetails.SetValue("Barbara Boxen", 1, 1);
            objEmployeeDetails.SetValue("Paut Smith", 1, 2);
            Console.WriteLine("Rank " + objEmployeeDetails.Rank);
        }
    }
}
