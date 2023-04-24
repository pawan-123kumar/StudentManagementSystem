using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; } = Guid.NewGuid();
        public string TeacherName { get; set; }
        public int Age { get; set; }
        /*public string Feedback { get; set; }*/

    }
}