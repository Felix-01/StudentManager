using StudentManager.DAL;
using StudentManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Controllers
{
    public class HomeController : Controller
    {
        CourseContext context = new CourseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseAndEnrolledStudents(FormCollection form)
        {
            int id = Convert.ToInt32(form["courseId"]);

            List<StudentCourses> studentCourses = new List<StudentCourses>();

            //Query to retrieve students registered for each course
            var studentList = (from c in context.Courses
                               from s in c.Students
                               where c.CourseCode == id
                               select new { StudentName = s.FirstName + " " + s.Surname, Course_Name = c.CourseName }).ToList();
                      
            foreach (var item in studentList)
            {
                StudentCourses scourses = new StudentCourses();
                scourses.StudentName = item.StudentName;
                scourses.CourseName = item.Course_Name;

                studentCourses.Add(scourses);
            }
            return View(studentCourses);
        }

        public ActionResult StudentAndCourseList()
        {
            List<StudentCourses> studentCourseList = new List<StudentCourses>();

            //Query to retrieve students and registered courses.
            var enrolment = (from s in context.Students
                             from c in s.Courses
                             select new { StudentName = s.FirstName + " " + s.Surname, Course_Name = c.CourseName }).ToList();

            foreach (var item in enrolment)
            {
                StudentCourses scourses = new StudentCourses();
                scourses.StudentName = item.StudentName;
                scourses.CourseName = item.Course_Name;

                studentCourseList.Add(scourses);
            }
            return View(studentCourseList);
        }

        public ActionResult RegisteredLessThanFive()
        {
            List<StudentCourses> studentCourseCount = new List<StudentCourses>();

            //Query to show students who didn't register max course
            var courseCount = (from s in context.Students
                               from c in s.Courses
                               where s.Courses.Count() < 5
                               select new { StudentName = s.FirstName + " " + s.Surname, Course_Name = c.CourseName }).ToList();

            foreach (var item in courseCount)
            {
                StudentCourses scourses = new StudentCourses();
                scourses.StudentName = item.StudentName;
                scourses.CourseName = item.Course_Name;

                studentCourseCount.Add(scourses);
            }
            return View(studentCourseCount);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Error()
        {            
            return View();
        }
        public ActionResult Error_CourseCount()
        {
            return View();
        }
    }
}