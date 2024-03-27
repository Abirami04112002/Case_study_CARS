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
    internal class EvidencesRepository
    {
        public List<Evidence> Evidences = new List<Evidence>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public EvidencesRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void getEvidences()
        {
            cmd.CommandText = "Select * from Evidence";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Evidence evidence = new Evidence();
                evidence.EvidenceID = (int)reader["EvidenceID"];
                evidence.Description = (string)reader["Description_evidence"];
                evidence.Location_Found = (string)reader["Location_Found"];
                evidence.IncidentID = (int)reader["IncidentID"];
                Evidences.Add(evidence);

            }
            foreach (var evidence1 in Evidences)
            {
                Console.WriteLine(evidence1.ToString());
                Console.WriteLine();
            }
            connect.Close();
        }
    }
}
