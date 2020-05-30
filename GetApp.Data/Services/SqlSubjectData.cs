using System;
using System.Collections.Generic;
using System.Linq;
using GetApp.Data.Models;

namespace GetApp.Data.Services
{
    public class SqlSubjectData : ISubjectData
    {
        private readonly GetAppDbContext db;

        public SqlSubjectData(GetAppDbContext db)
        {
            this.db = db;
        }

        public void Add(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
        }

        public Subject Get(int id)
        {
            return db.Subjects.FirstOrDefault(s => s.SubjectId == id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return from s in db.Subjects
                   orderby s.SubjectId
                   select s;
        }

        public void Update(Subject subject)
        {
            var entry = db.Entry(subject);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
        }
    }
}