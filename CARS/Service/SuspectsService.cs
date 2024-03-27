﻿using CARS.Entities;
using CARS.PackageDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    internal class SuspectsService
    {
        public SuspectsService() { }
        public void SuspectDirectory()
        {
            SuspectsRepository repository = new SuspectsRepository();
            int choice = 0;
            do
            {

                Console.WriteLine("**** Suspects Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: GetAllSuspects\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        List<Suspects> suspects = new List<Suspects>();
                        suspects= repository.getSuspects();
                        Console.WriteLine("****Suspects****");
                        foreach(Suspects suspects1 in suspects)
                        {
                            Console.WriteLine(suspects1);
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
