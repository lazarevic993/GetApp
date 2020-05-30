using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetApp.Data.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        public Subject()
        {
        }
    }
}
