using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Models.ViewModels
{
    public class StudentCourses
    {
        [Display(Name="Course Code")]
        public int CourseCode { get; set; }

        [Display(Name = "Course Title")]
        public string CourseName { get; set; }

        [Display(Name = "Lecturer")]
        public string TeacherName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name ="Student Name")]
        public string StudentName { get; set; }

        [Display(Name ="Enrol")]
        public bool IsEnroled { get; set; }
    }
}