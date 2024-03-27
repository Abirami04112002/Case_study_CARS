using CARS.Entities;
using CARS.Exceptions;
using CARS.PackageDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Service
{
    internal class ServiceImplementationClass
    {
        public ServiceImplementationClass() { }
        public void run()
        {
              int option = 0;
             CrimeAnalysisServiceImpl crimeAnalysisServiceImpl = new CrimeAnalysisServiceImpl();
            do
            {
                Console.WriteLine("********Crime Analysis Management System********");
                Console.WriteLine("1. Create Incidents\n2. UpdateIncidentStatus\n3. GetIncidentDateRange\n4. SearchIncidents\n5. GenerateIncidentReport\n6. CreateCases\n7. UpdateCaseDetails\n8. GetCaseDetails\n9. GetListofCases\n10. Exit\n");
                Console.WriteLine("Enter the operation you want to perform::");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("****Create Incidents****");
                        Console.WriteLine("Enter the IncidentType::");
                        string IncidentType = Console.ReadLine();
                        Console.WriteLine("Enter the IncidentDate::");
                        string IncidentDate = Console.ReadLine();
                        Console.WriteLine("Enter the Location of the Incident::");
                        string Location = Console.ReadLine();
                        Console.WriteLine("Description::");
                        string Description = Console.ReadLine();
                        string status ="open";
                        VictimsRepository repository= new VictimsRepository();
                        List<Victims> victims = new List<Victims>();
                        victims = repository.getVictims();
                        foreach (Victims victims1 in victims)
                        {
                            Console.WriteLine(victims1);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Enter the VictimID::");
                        int victimid = int.Parse(Console.ReadLine());
                        SuspectsRepository suspectsRepository = new SuspectsRepository();
                        List<Suspects> suspects = new List<Suspects>();
                        suspects = suspectsRepository.getSuspects();
                        Console.WriteLine("****Suspects****");
                        foreach (Suspects suspects1 in suspects)
                        {
                            Console.WriteLine(suspects1);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Enter the SuspectID::");
                        int suspectid = int.Parse(Console.ReadLine());
                        Incidents incidents= new Incidents();
                        incidents = new Incidents(IncidentType,DateTime.Parse( IncidentDate),Location,Description,status,victimid,suspectid);
                        crimeAnalysisServiceImpl.CreateIncident(incidents);
                        break;

                    case 2:
                        Console.WriteLine("****UpdateIncidentStatus****");
                        try
                        {
                            IncidentsRepository incidentsRepository1 = new IncidentsRepository();
                            List<Incidents> incidents4 = new List<Incidents>();
                            incidents4 = incidentsRepository1.getIncidents();
                            foreach (Incidents inc in incidents4)
                            {
                                Console.WriteLine(inc);
                                Console.WriteLine();
                            }
                            Console.WriteLine("Enter the Incident id to update::");
                            int incident_id = int.Parse(Console.ReadLine());
                            IncidentIdNotFoundException.IncidentIdNotFound(incident_id);
                                Console.WriteLine("Enter the updatedCase Status");
                                string casestatus = Console.ReadLine();
                                InvalidIncidentStatusException.InvalidIncidentStatus(casestatus);
                                crimeAnalysisServiceImpl.updateIncidentStatus(incident_id,casestatus);

                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 3:
                        List<Incidents> incidents1 = new List<Incidents>();
                        Console.WriteLine("****GetIncidentDateRange****");
                        Console.WriteLine("Enter the startDate::");
                        string startdate = Console.ReadLine();
                        Console.WriteLine("Enter the Enddate::");
                        string enddate = Console.ReadLine();
                        incidents1= crimeAnalysisServiceImpl.getIncidentsInDateRange(DateTime.Parse(startdate), DateTime.Parse(enddate));
                        foreach (var incidents2 in incidents1)
                        {
                            Console.WriteLine(incidents2);
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        List<Incidents> incidents_Impl = new List<Incidents>();
                        Console.WriteLine("****SearchIncidents****");
                        Console.WriteLine("Enter the incidentType::");
                        string criteria = Console.ReadLine();
                        incidents_Impl=crimeAnalysisServiceImpl.searchIncidents(criteria);
                        foreach (Incidents incidents3 in incidents_Impl)
                        {
                            Console.WriteLine(incidents3.ToString());
                            Console.WriteLine() ;
                        }
                        break;

                    case 5:
                        Console.WriteLine("****GenerateIncidentReport****");
                        Reports reports_impl = new Reports();
                        try
                        {
                            Console.WriteLine("Enter the incidents::");
                            int id = int.Parse(Console.ReadLine());
                            IncidentIdNotFoundException.IncidentIdNotFound((id));
                            reports_impl=crimeAnalysisServiceImpl.generateIncidentReport(id);
                            Console.WriteLine(reports_impl.ToString());
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 6:
                        Cases cases = new Cases();
                        Console.WriteLine("Enter the CaseStatus::");
                        string case_Status = Console.ReadLine();
                        Console.WriteLine("Enter the Description::");
                        string caseDescription = Console.ReadLine();
                        Console.WriteLine("Enter the incidentid");
                        int incidentID = int.Parse(Console.ReadLine());
                        cases = new Cases(caseDescription,case_Status,incidentID);
                        Console.WriteLine("****CreateCases****");
                        crimeAnalysisServiceImpl.createCase(cases);
                        break;

                    case 7:
                        Console.WriteLine("****UpdateCaseDetails****");
                        Cases cases_1 = new Cases();
                        Console.WriteLine("Enter the caseId to update");
                        int caseid= int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the casestatus to update");
                        string caseStatus = Console.ReadLine();
                        Console.WriteLine("Enter the case description to update");
                        string casedescrip = Console.ReadLine();
                        Console.WriteLine("Enter the IncidentId to update");
                        int incidentid = int.Parse(Console.ReadLine());
                        cases_1 = new Cases(caseid,casedescrip,caseStatus,incidentid);
                        crimeAnalysisServiceImpl.updateCaseDetails(cases_1);
                        break;

                    case 8:
                        Cases cases1 = new Cases();
                        Console.WriteLine("****GetCaseDetails****");
                        Console.WriteLine("Enter the caseID to get");
                        int caseId = int.Parse(Console.ReadLine());
                        cases1=crimeAnalysisServiceImpl.getCaseDetails(caseId);
                        Console.WriteLine(cases1.ToString());
                        IncidentsRepository incidentsRepository = new IncidentsRepository();
                        List<Incidents> Caseincident = new List<Incidents>();
                        Caseincident = incidentsRepository.getIncidents();
                        foreach(Incidents incidents4 in Caseincident )
                        {
                           
                            if(cases1.incidentId==incidents4.IncidentID)
                            {
                                
                                Console.WriteLine(incidents4);
                            }
                        }
                        break;

                    case 9:
                        List<Cases> cases2 = new List<Cases>();
                        Console.WriteLine("****GetListofCases****");
                        cases2 = crimeAnalysisServiceImpl.getAllCases();
                        foreach (Cases c in cases2)
                        {
                            Console.WriteLine(c);
                        }
                        break;
                        

                    case 10:
                        Console.WriteLine("Thank You!! Exiting..");
                        break;

                    default: Console.WriteLine("Invalid Option"); break;
                }

            } while (option != 10);


        }
    }
}
