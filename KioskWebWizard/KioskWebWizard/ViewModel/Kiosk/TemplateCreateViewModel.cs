using KioskWebWizard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class TemplateCreateViewModel
    {
        [Required]
        public string TemplateName { get; set; }
        public int KioskLoyaltyTemplateDataID { get; set; }
        public int KioskMapTemplateDataID { get; set; }
#nullable enable
        [ForeignKey("KioskLoyaltyTemplateDataID")]
        public KioskLoyaltyTemplateDataModel? KioskLoyaltyTemplateData { get; set; }
        [ForeignKey("KioskMapTemplateDataID")]
        public KioskMapTemplateDataModel? KioskMapTemplateData { get; set; }
#nullable disable
    }
}
