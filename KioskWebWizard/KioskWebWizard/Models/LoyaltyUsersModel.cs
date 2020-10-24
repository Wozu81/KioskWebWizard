using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Models
{
    public class LoyaltyUsersModel
    {
        public int ID { get; set; }
        public int LoyaltyID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; } 
        public string Country { get; set; }
    }
}
