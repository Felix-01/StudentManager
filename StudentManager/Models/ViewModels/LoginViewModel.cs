using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please choose a User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Choose a Password")]
        public string Password { get; set; }
    }
}