using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Models
{
    public class KioskTemplatesModel
    {
        public int ID { get; set; }
        [Required]
        public string TemplateName { get; set; }
        public ICollection<KioskModel> Kiosks { get; set; }
    }
}
