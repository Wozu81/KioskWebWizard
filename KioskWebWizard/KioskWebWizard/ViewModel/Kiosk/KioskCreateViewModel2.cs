using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class KioskCreateViewModel2
    {
        [StringLength(50)]
        public string MapName { get; set; }
        public int KioskID { get; set; }
    }
}
