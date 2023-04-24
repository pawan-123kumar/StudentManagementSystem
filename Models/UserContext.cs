using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class UserContext:DbContext
    {
        public UserContext() : base("name=MyConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentFeedback> feedbacks { get; set; }
  
      
        public DbSet<Teacher> Teachers { get; set; }
    }
}