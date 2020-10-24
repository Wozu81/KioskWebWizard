using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class KioskDeleteViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Nazwa Kiosku")]
        public string Name { get; set; }
    }
}
