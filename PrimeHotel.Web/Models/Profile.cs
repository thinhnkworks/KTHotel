﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHotel.Web.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string TelNo { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}