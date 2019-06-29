using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UAWebApplication.Models;
using UAWebApplication.Utilities;

namespace UAWebApplication.Pages
{
    public class SignUpModel : PageModel
    {
        private UADataContext _context;

        public SignUpModel(UADataContext context)
        {
            _context = context;
        }

        [Required]
        [Display(Name ="Name")]
        [BindProperty]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [BindProperty]
        public string Password { get; set; }

        //[Compare("Password")]
        //[Display(Name = "Confirm Password")]
        //[BindProperty]
        //public string ConfirmPassword { get; set; }

        //[Required]
        //[Display(Name = "Gender")]
        //public bool Gender { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) { 
                var user = new User
                {
                    Name = Name,
                    Email = Email,
                    Password = Password,
                };
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                var a = EmailSender.Send(Email, "Successfully registered", "आपका खाता खुल चूका हैं|");
                if(a)
                return RedirectToPage("/Index",new { Name });
            }
            return Page();
        }

    }
}