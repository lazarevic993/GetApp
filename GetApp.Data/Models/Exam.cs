using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using GetApp.Data.Models;

namespace GetApp.Data.Models
{
    [Table("Exams")]
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required, Range(5, 10)]
        public int Grade { get; set; }

        [Required]
        public DateTime PassedExamDate { get; set; }

        [Required]
        public int IndexNumber { get; set; }

        public virtual IList<StudentExam> StudentExames { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public Exam()
        {
        }
    }
}
