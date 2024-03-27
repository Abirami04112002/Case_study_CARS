using CARS.CARS_Sys;
using CARS.Entities;
using CARS.Exceptions;
using CARS.PackageDao;
using CARS.Service;
using System.Transactions;

namespace CARS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CARS_system.run();
        }
    }
}
