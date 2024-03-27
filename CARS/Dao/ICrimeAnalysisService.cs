using CARS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.PackageDao
{
    public interface ICrimeAnalysisService
    {
         bool CreateIncident(Incidents incidents);
         bool updateIncidentStatus(int incidentID,string status);
         List<Incidents> getIncidentsInDateRange(DateTime StartDate, DateTime EndDate);
         List<Incidents> searchIncidents(object criteria);
         Reports generateIncidentReport(object incidents);
         bool createCase( Cases cases);
         Cases getCaseDetails(int caseId);
         bool updateCaseDetails(Cases cases);
         List<Cases> getAllCases();
    }
}
