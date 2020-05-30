using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using GetApp.Data.Models;

namespace GetApp.Data.Models
{
    [Table("StudentExams")]
    public class StudentExam
    {
        public int StudentId { get; set; }
        
        public int ExamId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Exam Exam { get; set; }

        public StudentExam()
        {
        }
    }
}
