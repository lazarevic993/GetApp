using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using GetApp.Data.Models;

namespace GetApp.Data.Services
{
    public class GetAppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentExam>().HasKey(se => new { se.StudentId, se.ExamId });
        }

        public GetAppDbContext()
        {

        }
    }
}
