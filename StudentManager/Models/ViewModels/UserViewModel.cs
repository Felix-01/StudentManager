using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Models.ViewModels
{
    public enum Role
    {
        Admin = 1,
        Student
    }
    public class UserViewModel
    {

        [Required]
        [Display(Name="User Name")]
        public string Username { get; set; }

        [Required]
        [Display(Name="Full Name")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name="Confirm Email")]
        [Compare("Email")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [Display(Name = "Role")]
        public Role RoleName { get; set; }
    }    
}