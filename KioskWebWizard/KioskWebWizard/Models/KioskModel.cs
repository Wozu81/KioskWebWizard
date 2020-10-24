using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.Models
{
    public class KioskModel
    {
        public int ID { get; set; }
        [ForeignKey ("KioskTemplateID")]
        public KioskTemplatesModel KioskTemplate { get; set; }
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }
    }
}
