﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk.Run
{
    public class KioskRun1ViewModelPart1
    {
        [StringLength(50)]
        public string LoyaltyName { get; set; }
        public string LoyaltyDescription { get; set; }
#nullable enable
        public string? LoyaltyCarouselData1 { get; set; }
        public string? LoyaltyCarouselData2 { get; set; }
        public string? LoyaltyCarouselData3 { get; set; }
        public string? LoyaltyCarouselData4 { get; set; }
        public string? LoyaltyCarouselData5 { get; set; }
#nullable disable
        public int OriginalKioskID { get; set; }
    }
}
