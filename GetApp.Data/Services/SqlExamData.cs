using System;
using System.Collections.Generic;
using System.Linq;
using GetApp.Data.Models;
using System.Data.Entity;

namespace GetApp.Data.Services
{
    public class SqlExamData : IExamData
    {
        private readonly GetAppDbContext db;

        public SqlExamData(GetAppDbContext db)
        {
            this.db = db;
        }

        public void Add(Exam exam)
        {
            db.Exams.Add(exam);
            
            db.SaveChanges();
        }

        public List<int> GetAllStudentIndexes()
        {
            return db.Students.Select(s => s.IndexNumber).ToList();
        }

        public Exam Get(int id)
        {
            return db.Exams.Include(e => e.StudentExames).FirstOrDefault(e => e.ExamId == id);
        }

        public IEnumerable<Exam> GetAll()
        {
            return db.Exams;
        }

        public void Update(Exam exam)
        {
            var entry = db.Entry(exam);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
        }

        public List<int> GetAllSubjetId()
        {
            return db.Subjects.Select(s => s.SubjectId).ToList();
        }
    }
}
