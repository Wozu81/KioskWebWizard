using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Models
{
    public class KioskMapTemplateDataModel
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string MapName { get; set; }
    }
}
