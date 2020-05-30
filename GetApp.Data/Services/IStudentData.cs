using System;
using System.Collections.Generic;
using GetApp.Data.Models;

namespace GetApp.Data.Services
{

    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        List<int> GetAllStudentIndexes();
    }
}
