using KioskWebWizard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class KioskDetailViewModel2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TemplateName { get; set; }
        public ICollection<KioskMapTemplateDataModel> KioskMapTemplateData { get; set; }
    }
}
