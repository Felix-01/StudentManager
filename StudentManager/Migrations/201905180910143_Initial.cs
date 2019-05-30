namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseCode = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        TeacherName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseCode);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        Address3 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        RoleName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        Course_CourseCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.Course_CourseCode })
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseCode, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.Course_CourseCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Course_CourseCode", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseCode" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentID" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Users");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
