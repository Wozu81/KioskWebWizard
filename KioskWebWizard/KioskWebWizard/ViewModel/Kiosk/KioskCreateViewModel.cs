﻿using KioskWebWizard.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk
{
    public class KioskCreateViewModel
    {
        public int KioskTemplateID { get; set; }
        [ForeignKey("KioskTemplateID")]
        public KioskTemplatesModel KioskTemplate { get; set; }
        public string Name { get; set; }
#nullable enable
        public int? KioskLoyaltyTemplateDataID { get; set; }
        public int? KioskMapTemplateDataID { get; set; }
        [ForeignKey("KioskLoyaltyTemplateDataID")]

        public KioskLoyaltyTemplateDataModel? KioskLoyaltyTemplateData { get; set; }
        [ForeignKey("KioskMapTemplateDataID")]
        public KioskMapTemplateDataModel? KioskMapTemplateData { get; set; }
#nullable disable
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }
    }
}
