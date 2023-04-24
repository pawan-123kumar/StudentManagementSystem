namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentManagementSystem.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentManagementSystem.Models.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(new Models.User { UserName = "admin",Password="admin123@",Role="Teacher" },
                new Models.User { UserName="Aman",Password="aman3221@",Role="Student"},
                new Models.User { UserName="pawan",Password="Pawan123@",Role="Teacher"},
                new Models.User { UserName="Rishav",Password="rishav@12345",Role="Student"});

            context.Teachers.AddOrUpdate(new Models.Teacher { TeacherName = "Avnish", Age = 28 }, new Models.Teacher { TeacherName = "Akash", Age = 30 },
                new Models.Teacher { TeacherName="Jay",Age=27});
        }
    }
}
