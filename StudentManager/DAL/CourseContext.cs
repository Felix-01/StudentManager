using StudentManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManager.DAL
{
    public class CourseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }

        //The idea here is to follow the naming used in the ER design
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(a => a.Courses)
                .WithMany(a => a.Students)
                .Map(m =>
                {
                    m.ToTable("StudentCourses");
                    m.MapLeftKey("StudentID");
                    m.MapRightKey("CourseCode");
                });
            base.OnModelCreating(modelBuilder);
        }
    }

}