using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk.Run
{
    public class KioskRun13CreateUserViewModel
    {
        public int OriginalKioskID { get; set; }
#nullable enable
        [Required]
        
        public string? Street { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Tylko wartości większe od zera!")]
        public int? BuildingNumber { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Tylko wartości większe od zera!")]
        public int? ApartmentNumber { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
#nullable disable
    }
}
