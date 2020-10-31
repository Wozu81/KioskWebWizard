﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Models
{
    public class LoyaltyUsersModel
    {       
        public int ID { get; set; }
        public int OriginalKioskID { get; set; }
#nullable enable
        public int? LoyaltyID { get; set; }
#nullable disable
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public bool AllowAddress { get; set; }
#nullable enable
        public string? Street { get; set; }
        public int? BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; } 
        public string? Country { get; set; }
#nullable disable
        public bool Rodo { get; set; }
    }
}
