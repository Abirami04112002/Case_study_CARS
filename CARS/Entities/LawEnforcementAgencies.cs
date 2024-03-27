﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CARS.Entities
{
    public class LawEnforcementAgencies
    {
        public LawEnforcementAgencies()
        {
        }

        public int AgencyID { get; set; }
        public String AgencyName { get; set; }
        public string Jurisdiction { get; set; }
        public Officers officers { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public int officerid { get; set; }

        public LawEnforcementAgencies(int agencyID, string agencyName, string jurisdiction, Officers officers, string address, string phone_Number)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            this.officers = officers;
            Address = address;
            Phone_Number = phone_Number;
        }
        public override string ToString()
        {
            return $"AgencyId::{AgencyID}\tAgencyName::{AgencyName}\tJurisdiction::{Jurisdiction}\tOfficersId::{officerid}\tAddress::{Address}\tContactNumber::{Phone_Number}";
        }
    }
}
