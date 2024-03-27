﻿using CARS.Entities;
using CARS.PackageDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    internal class VictimService
    {
        public VictimService() { }
        public void VictimDirectory()
        {
            VictimsRepository repository = new VictimsRepository();
            int choice = 0;
            do
            {

                Console.WriteLine("**** Victims Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: GetAllVictims\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        List<Victims> victims = new List<Victims>();
                        victims= repository.getVictims();
                        foreach(Victims victims1 in victims)
                        {
                            Console.WriteLine(victims1);
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            } while (choice != 2);
        }
    }
}
