﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KioskWebWizard.ViewModel.Account
{
    public class LoginViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
