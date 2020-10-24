using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Models
{
    public class TemplateTypeModel
    {
        public int ID { get; set; }
#nullable enable
        public KioskLoyaltyTemplateDataModel? KioskLoyaltyTemplateData { get; set; }
        public KioskMapTemplateDataModel? KioskMapTemplateData { get; set; }
#nullable disable
    }
}
