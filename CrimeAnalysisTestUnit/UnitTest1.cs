using Microsoft.VisualStudio.TestPlatform.TestHost;
using CARS.Entities;
using CARS.Entities;
using CARS.PackageDao;
using CARS.Exceptions;

namespace CrimeAnalysisTestUnit
{
    public class CrimeAnalysisTest
    {

        CrimeAnalysisServiceImpl crimeAnalysisService;

        [SetUp]
        public void Setup()
        {
            crimeAnalysisService = new CrimeAnalysisServiceImpl();
        }

        [Test]
        public void CreateIncidentMethod_Test1()
        {
            //assign
            Incidents incidents1 = new Incidents()
            {

                IncidentType = "Robbery",
                Description = "missing of laptop",
                Location = "Street A, City B, Country C",
                IncidentDate = DateTime.Now.AddDays(-9),
                Status = "open",
                VictimID = 1,
                SuspectID = 2
            };
            bool success = crimeAnalysisService.CreateIncident(incidents1);
            Assert.AreEqual(true, success);
        }
        [Test]
        public void StatusUpdate_Test2()
        {
            int incidentid = 2;
            string updated_status1 = "open";
            bool success = crimeAnalysisService.updateIncidentStatus(incidentid, updated_status1);
            //assert
            Assert.AreEqual(true, success);
        }

        [Test]
        public void StatusUpdate_Test3()
        {
            try
            {
                int incidentid = 2;
                string updated_status1 = "not";

                //assert
                InvalidIncidentStatusException.InvalidIncidentStatus(updated_status1);
                crimeAnalysisService.updateIncidentStatus(incidentid, updated_status1);
            }
            catch(Exception ex) { Assert.IsTrue(ex.Message.Contains("Invalid !!!!")); }
            
        }

    }
}