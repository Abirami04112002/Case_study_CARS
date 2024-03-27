﻿using CARS.Entities;
using CARS.PropertyUtil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.PackageDao
{
    internal class SuspectsRepository
    {
        List<Suspects> Suspects = new List<Suspects>();
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public SuspectsRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public List<Suspects> getSuspects()
        {
            cmd.CommandText = "Select * from Suspects";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Suspects suspects = new Suspects();
                suspects.SuspectID = (int)reader["SuspectID"];
                suspects.FirstName = (string)reader["FirstName"];
                suspects.LastName = (string)reader["LastName"];
                suspects.DateOfBirth = (DateTime)reader["DateOfBirth"];
                suspects.Gender = (string)reader["Gender"];
                suspects.address = (string)reader["Suspect_address"];
                suspects.Phone_number = (string)reader["mobile_number"];

                Suspects.Add(suspects);

            }
            //foreach (var suspects1 in Suspects)
            //{
            //    Console.WriteLine(suspects1);
            //    Console.WriteLine();
            //}
            connect.Close();
            return Suspects;
        }
    }
}
