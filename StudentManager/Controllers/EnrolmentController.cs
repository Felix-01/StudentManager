using StudentManager.CustomSecurity;
using StudentManager.DAL;
using StudentManager.DAL.Repository;
using StudentManager.Models;
using StudentManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentManager.Controllers
{
    public class EnrolmentController : Controller
    {
        // GET: Enrolment
        public ActionResult Index()
        {
            CoursesRepository courseRepo = new CoursesRepository();          

            return View(courseRepo.GetAllCourses());
        }
        [HttpPost]
        public ActionResult Index(List<StudentCourses> courses, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string Id = form["studentId"].ToString();
                int id = Convert.ToInt32(Id);

                Student student = new Student();
                CoursesRepository cRepo = new CoursesRepository();
                var currentUser = User as CustomPrincipal;                
                
                //Check to see if student already has up to five courses registered
                if(cRepo.CourseCount(id) >= 5)
                {
                    return RedirectToAction("Error_CourseCount", "Home");
                }

                //Validation to make sure only student(self) and admin can register course
               else if (currentUser.Email == student.Email || currentUser.RoleName == "Admin")
                {
                    foreach (var item in courses)
                    {
                        if (item.IsEnroled == true)
                        {
                            Course course = new Course();
                            course.CourseCode = item.CourseCode;
                            course.CourseName = item.CourseName;
                            course.TeacherName = item.TeacherName;
                            course.StartDate = item.StartDate;
                            course.EndDate = item.EndDate;

                            //Check to see if student has registered this course before
                            if (cRepo.DuplicateCourseRegistration(id, item.CourseCode) >= 1)
                            {
                                return RedirectToAction("Error_CourseCount", "Home");
                            }
                            else 
                            {
                                CourseContext context = new CourseContext();
                                var cos = context.Courses.FirstOrDefault(a => a.CourseCode == item.CourseCode);
                                context.Students.Include("Courses").FirstOrDefault(s => s.StudentID == id).Courses.Add(cos);

                                context.SaveChanges(); 
                            }
                        }
                    }                   
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            return RedirectToAction("Index","Students");
        }
    }
}