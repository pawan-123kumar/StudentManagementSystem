namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pawan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feedback = c.String(),
                        StudenId = c.Guid(nullable: false),
                        StudentName = c.String(),
                        TeacherId = c.Guid(nullable: false),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Guid(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Course = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Guid(nullable: false),
                        TeacherName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.StudentFeedbacks");
        }
    }
}
