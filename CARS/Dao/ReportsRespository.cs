using CARS.Entities;
using CARS.PropertyUtil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.PackageDao
{
    internal class ReportsRespository
    {
       public  List<Reports> Reports=new List<Reports>();
       SqlConnection connect = null;
       SqlCommand cmd = null;
        public ReportsRespository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void getReports()
        {
            cmd.CommandText = "Select * from Reports";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Reports reports = new Reports();
                reports.ReportID = (int)reader["ReportID"];
                reports.ReportingOfficerID = (int)reader["ReportingOfficerID"];
                reports.IncidentID = (int)reader["IncidentID"];
                reports.Status = (string)reader["evidence_status"];
                reports.ReportDate= (DateTime)reader["ReportDate"];
                reports.ReportDescription= (string)reader["ReportDetails"];
                Reports.Add(reports);

            }
            foreach (var reports in Reports)
            {
                Console.WriteLine(reports.ToString());
                Console.WriteLine();

            }
            connect.Close();
        }
    }
}
