using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using GetApp.Data.Models;

namespace GetApp.Data.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Range(1,500)]
        [Index(IsUnique = true)]
        public int IndexNumber { get; set; }

        [Required, StringLength(255)]
        public string FirstName { get; set; }

        [Required, StringLength(255)]
        public string LastName { get; set; }

        [Required, StringLength(255)]
        public string City { get; set; }

        public virtual IList<StudentExam> StudentExams { get; set; }

        public Student()
        {
        }
    }
}
