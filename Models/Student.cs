using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course   { get; set; }
        public string Status { get; set; } = "Activated";
    }
}