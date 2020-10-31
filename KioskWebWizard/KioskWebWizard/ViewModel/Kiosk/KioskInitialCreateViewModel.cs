using KioskWebWizard.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class KioskInitialCreateViewModel
    {
        public int KioskTemplateID { get; set; }
        [ForeignKey("KioskTemplateID")]
        public KioskTemplatesModel KioskTemplate { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }
    }
}
