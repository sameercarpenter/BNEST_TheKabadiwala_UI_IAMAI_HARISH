using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UAWebApplication.ViewModels
{
    public class SignUpModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "")]
        public string Password { get; set; }

        [Display(Name = "")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "")]
        public bool Gender { get; set; }
    }
}
