namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedJunctionTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentCourses", name: "Student_StudentID", newName: "StudentID");
            RenameColumn(table: "dbo.StudentCourses", name: "Course_CourseCode", newName: "CourseCode");
            RenameIndex(table: "dbo.StudentCourses", name: "IX_Student_StudentID", newName: "IX_StudentID");
            RenameIndex(table: "dbo.StudentCourses", name: "IX_Course_CourseCode", newName: "IX_CourseCode");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentCourses", name: "IX_CourseCode", newName: "IX_Course_CourseCode");
            RenameIndex(table: "dbo.StudentCourses", name: "IX_StudentID", newName: "IX_Student_StudentID");
            RenameColumn(table: "dbo.StudentCourses", name: "CourseCode", newName: "Course_CourseCode");
            RenameColumn(table: "dbo.StudentCourses", name: "StudentID", newName: "Student_StudentID");
        }
    }
}
