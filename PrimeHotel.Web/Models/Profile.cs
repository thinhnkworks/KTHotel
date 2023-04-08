﻿using System;

namespace PrimeHotel.Web.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public string Salutation { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string TelNo { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
