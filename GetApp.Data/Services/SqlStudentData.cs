using System;
using System.Collections.Generic;
using System.Linq;
using GetApp.Data.Models;

namespace GetApp.Data.Services
{
    public class SqlStudentData : IStudentData
    {
        private readonly GetAppDbContext db;

        public SqlStudentData(GetAppDbContext db)
        {
            this.db = db;
        }

        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public Student Get(int id)
        {
            return db.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return from s in db.Students
                   orderby s.FirstName
                   select s;
        }

        public void Update(Student student)
        {
            var entry = db.Entry(student);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {

            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public List<int> GetAllStudentIndexes()
        {
            return db.Students.Select(s => s.IndexNumber).ToList();
        }
    }
}