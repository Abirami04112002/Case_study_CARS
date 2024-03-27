using CARS.Entities;
using CARS.PackageDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    internal class CasesService
    {
        public CasesService() { }
        public void CaseDirectory()
        {
            CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
            int choice = 0;
            do
            {
                Console.WriteLine("****Case Details****");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"1: getAllCaseDetails\n2. Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        List<Cases> cases2 = new List<Cases>();
                        Console.WriteLine("****GetListofCases****");
                        cases2 = crimeAnalysisServiceImpl.getAllCases();
                        foreach (Cases c in cases2)
                        {
                            Console.WriteLine(c);
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
