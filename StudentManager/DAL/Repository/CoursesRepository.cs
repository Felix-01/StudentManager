using StudentManager.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.DAL.Repository
{
    /// <summary>
    /// This class is designed to provide the functions that will enforce the 
    /// business logic as stated in the requirement.
    /// </summary>
    public class CoursesRepository
    {
        public List<StudentCourses> GetAllCourses()
        {
            List<StudentCourses> courseList = new List<StudentCourses>();
            CourseContext context = new CourseContext();
            var query = context.Courses;
            if (query != null)
            {
                foreach (var item in query)
                {
                    StudentCourses course = new StudentCourses();

                    course.CourseCode = item.CourseCode;
                    course.CourseName = item.CourseName;
                    course.StartDate = item.StartDate;
                    course.EndDate = item.EndDate;
                    course.TeacherName = item.TeacherName;
                    course.IsEnroled = false;

                    courseList.Add(course);
                }
            }
            return courseList;
        }
        public int CourseCount(int id)
        {
            CourseContext context = new CourseContext();

            int count = 0;
            //Check number of courses already registered
            var regCourses = from s in context.Students
                             from c in s.Courses
                             where s.StudentID == id
                             select new { courseCount = s.Courses.Count() };

            foreach (var item in regCourses)
            {
                count = item.courseCount;
            }
            return count;
        }
        public int DuplicateCourseRegistration(int id, int courseCode)
        {
            CourseContext context = new CourseContext();

            int count = 0;
            //Check for duplication of registered courses
            var courses = from s in context.Courses
                          from c in s.Students
                          where c.StudentID == id 
                          select s.CourseCode;           

            if(courses.Contains(courseCode))
            {
                    count = count + 1;
            }                        
            
            return count;
        }
    }
}