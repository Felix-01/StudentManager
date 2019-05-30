using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public enum Gender
    {
        Male = 1,
        Female,
        Other
    }
    public class Student
    {
        public int StudentID { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Address1 { get; set; }

        [Required]
        public string Address2 { get; set; }

        [Required]
        public string Address3 { get; set; }

        public ICollection<Course>Courses { get; set; }
    }
}