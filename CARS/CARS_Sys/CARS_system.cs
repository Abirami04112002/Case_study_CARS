using CARS.Entities;
using CARS.Exceptions;
using CARS.PackageDao;
using CARS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.CARS_Sys
{
    internal class CARS_system
    {
        public CARS_system() { }
        public static void run()
        {
            int option = 0;
            ServiceImplementationClass serviceImplementationClass= new ServiceImplementationClass();
            do
            {
                Console.WriteLine("********Crime Analysis Management System********");
                Console.WriteLine("1. Incidents\n2. Evidences\n3. LawEnforcementAgencies\n4. Cases\n5. Officers\n6. Suspects\n7. Victims\n8. Implemented Methods\n9. Exit\n");
                Console.WriteLine("Enter the operation you want to perform::");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("****Incidents****");
                        IncidentService incidentService = new IncidentService();
                        incidentService.IncidentDirectory();
                        break;

                    case 2:
                        Console.WriteLine("****Evidences****");
                        EvidenceService evidenceService = new EvidenceService();
                        evidenceService.EvidenceDirectory();
                        break;

                    case 3:
                        Console.WriteLine("****LawEnforcementAgencies****");
                        LawEnforcementServicecs lawEnforcementServicecs = new LawEnforcementServicecs();
                        lawEnforcementServicecs.LawEnforcementDirectory();
                        break;

                    case 4:
                        Console.WriteLine("****Cases****");
                        CasesService casesService = new CasesService();
                        casesService.CaseDirectory();
                        break;

                    case 5:
                        Console.WriteLine("****Officers****");
                        OfficerService officerService = new OfficerService();
                        officerService.OfficerDirectory();
                        break;

                    case 6:
                        Console.WriteLine("****Suspects****");
                        SuspectsService service = new SuspectsService();
                        service.SuspectDirectory();
                         break;

                    case 7:
                        Console.WriteLine("****Victims****");
                        VictimService victimService = new VictimService();
                        victimService.VictimDirectory();
                        break;

                    case 8:
                        Console.WriteLine("****Implemented Methods****");
                        serviceImplementationClass.run();
                        break;

                    case 9:
                        Console.WriteLine("Thank You!! Exiting..");
                        break;

                    default: Console.WriteLine("Invalid Option"); break;
                }

            } while (option != 9);


        }
    }
}
