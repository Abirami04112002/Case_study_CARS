using CARS.Entities;
using CARS.Exceptions;
using CARS.PropertyUtil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.PackageDao
{
   public class CrimeAnalysisServiceImpl:ICrimeAnalysisService
    {   //Instances for class
        Incidents Incidents = new Incidents();
        Suspects suspects = new Suspects();
        Victims Victims = new Victims();

        //repository 
        IncidentsRepository IncidentsRepository = new IncidentsRepository();
        ReportsRespository ReportsRespository = new ReportsRespository();
        CasesRepository casesRepository = new CasesRepository();

        SqlConnection connect = null;
        SqlCommand cmd = null;
        public CrimeAnalysisServiceImpl()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        
        public bool CreateIncident(Incidents incidents)
        {
            
                
                cmd.CommandText = "Insert into Incidents values(@type,@date,@location,@description,@caseStatus,@victimID,@suspectID)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@type", incidents.IncidentType);
                cmd.Parameters.AddWithValue("@date", incidents.IncidentDate);
                cmd.Parameters.AddWithValue("@location", incidents.Location);
                cmd.Parameters.AddWithValue("@description", incidents.Description);
                cmd.Parameters.AddWithValue("@caseStatus", incidents.Status);
                cmd.Parameters.AddWithValue("@victimID", incidents.VictimID);
                cmd.Parameters.AddWithValue("@suspectID", incidents.SuspectID);

                cmd.Connection = connect;
                connect.Open();
                int creationstatus = cmd.ExecuteNonQuery();
                Console.WriteLine("Incident created!!!");
            if(creationstatus != 0) 
            {
                return true;
            }

            return false;
        }
        
        public bool updateIncidentStatus(int incidentId,string case_status)
        {
            try
            {
                InvalidIncidentStatusException.InvalidIncidentStatus(case_status);
                cmd.CommandText = "update Incidents set Case_Status=@caseStatus where IncidentID=@incidentid";
                cmd.Connection = connect;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@caseStatus", case_status);
                cmd.Parameters.AddWithValue("@incidentid", incidentId);
                connect.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Status updated!!!!");
            }
            catch ( Exception ex) { Console.WriteLine(ex.Message); }
            connect.Close();


            return true;

        }
        public List<Incidents> getIncidentsInDateRange(DateTime StartDate,DateTime EndDate)
        {
            List<Incidents> incidents1 = new List<Incidents>();
            cmd.CommandText = "select * from Incidents where IncidentDate between @startdate  and @enddate";
            cmd.Connection=connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@startdate",StartDate);
            cmd.Parameters.AddWithValue("@enddate",EndDate);
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Incidents incidents = new Incidents();
                incidents.IncidentID = (int)reader["IncidentID"];
                incidents.IncidentType = (string)reader["IncidentType"];
                incidents.IncidentDate = (DateTime)reader["IncidentDate"];
                incidents.Location = (string)reader["Locations"];
                incidents.Description = (string)reader["Descriptions"];
                incidents.Status = (string)reader["Case_Status"];
                incidents.VictimID = (int)reader["VictimId"];
                incidents.SuspectID = (int)reader["SuspectId"];
                incidents1.Add(incidents);

            }
            connect.Close();
            return incidents1;
        }

        public List<Incidents> searchIncidents(object criteria)
        {
            List<Incidents> incidents2= new List<Incidents>();
            cmd.CommandText = "select * from Incidents where IncidentType=@criteria";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@criteria", criteria);
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Incidents incidents = new Incidents();
                incidents.IncidentID = (int)reader["IncidentID"];
                incidents.IncidentType = (string)reader["IncidentType"];
                incidents.IncidentDate = (DateTime)reader["IncidentDate"];
                incidents.Location = (string)reader["Locations"];
                incidents.Description = (string)reader["Descriptions"];
                incidents.Status = (string)reader["Case_Status"];
                incidents.VictimID = (int)reader["VictimId"];
                incidents.SuspectID = (int)reader["SuspectId"];
                incidents2.Add(incidents);

            }
            connect.Close();
            return incidents2;
        }
        public Reports generateIncidentReport(object incidents)
        {
            Console.WriteLine();
            Reports reports = new Reports();
            cmd.CommandText = "Select * from Reports where IncidentID=@incidentid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@incidentid", incidents);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                reports.ReportID = (int)reader["ReportID"];
                reports.ReportingOfficerID = (int)reader["ReportingOfficerID"];
                reports.IncidentID = (int)reader["IncidentID"];
                reports.Status = (string)reader["evidence_status"];
                reports.ReportDate = (DateTime)reader["ReportDate"];
                reports.ReportDescription = (string)reader["ReportDetails"];
                

            }
            connect.Close();
            return reports;
        }
        public bool createCase( Cases cases)
        {

            cmd.CommandText = "insert into Cases values(@des,@status,@id)";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@des", cases.caseDescription);
            cmd.Parameters.AddWithValue("@status", cases.caseStatus);
            cmd.Parameters.AddWithValue("@id", cases.incidentId);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            IncidentsRepository incidentsRepository = new IncidentsRepository();
            List<Incidents> Caseincident = new List<Incidents>();
            Caseincident = incidentsRepository.getIncidents();
            //foreach (Incidents incidents in Caseincident)
            //{

            //    if (incidentID == incidents.IncidentID)
            //    {

            //        cases.incidents.Add(incidents);
            //    }
            //}
            Console.WriteLine("Case Details Created Succesfully!!!");
            //Console.WriteLine("CaseDescription::")
            return true;
        }
        public Cases getCaseDetails(int caseId)
        {

            
            cmd.CommandText = "Select * from Cases where caseID=@caseid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@caseid",caseId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            Cases case1 = new Cases();

            while (reader.Read())
            {
                case1.CaseId = (int)reader["CaseId"];
                case1.caseDescription = (string)reader["CaseDescription"];
                case1.caseStatus = (string)reader["caseStatus"];
                case1.incidentId = (int)reader["incidentId"];

            }
            connect.Close();
            return case1;
           
        }
        public bool updateCaseStatus(int caseid)
        {
            try
            {

                Console.WriteLine("Enter the CaseStatustoUpdate::");
                string case_Status = Console.ReadLine();
                InvalidIncidentStatusException.InvalidIncidentStatus(case_Status);
                cmd.CommandText = "update Cases set caseStatus=@casestatus  where caseID=@caseid";
                cmd.Connection = connect;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@casestatus", case_Status);
                cmd.Parameters.AddWithValue("@caseid", caseid);
                connect.Open() ;
                cmd.ExecuteNonQuery();
                connect.Close();
                Console.WriteLine("**Status Updated**");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return true;
        }

        public bool updateCaseDetails(Cases cases)
        {
            cmd.CommandText = "update Cases set caseStatus=@casestatus,CaseDescription=@des,incidentId=@incid  where caseID=@caseid";
            cmd.Connection = connect;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@casestatus", cases.caseStatus);
            cmd.Parameters.AddWithValue("@caseid", cases.CaseId);
            cmd.Parameters.AddWithValue("des",cases.caseDescription);
            cmd.Parameters.AddWithValue("incid",cases.incidentId);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close() ;
            Console.WriteLine("Case Details Updated!!!!!");
            return true;
        }
        public List<Cases> getAllCases()
        {
          List<Cases> cases = new List<Cases>();
          CasesRepository casesRepository = new CasesRepository();
           cases= casesRepository.getCases();
           return cases;
        }
    }
}
