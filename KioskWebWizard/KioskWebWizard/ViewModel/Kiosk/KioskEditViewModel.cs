using KioskWebWizard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class KioskEditViewModel
    {
        public int ID { get; set; }
        [ForeignKey("KioskTemplateID")]
        public KioskTemplatesModel KioskTemplate { get; set; }
        public string Name { get; set; }
    }
}
