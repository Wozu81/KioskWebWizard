using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk.Run
{
    public class KioskRun12CreateUserViewModel
    {
        public int OriginalKioskID { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public bool AllowAddress { get; set; }
    }
}
