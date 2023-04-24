using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class StudentFeedback
    {
        public int Id { get; set; }
        public string Feedback { get; set; }
        public Guid StudenId { get; set; }
        public string StudentName { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
      
        
    }
}