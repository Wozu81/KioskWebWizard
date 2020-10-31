﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Kiosk.Run
{
    public class KioskRun2ViewModelPart1
    {
        public int OriginalKioskNo { get; set; }
        [StringLength(50)]
        public string MapName { get; set; }
    }
}
