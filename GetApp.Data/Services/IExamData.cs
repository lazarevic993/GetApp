using System;
using System.Collections.Generic;
using GetApp.Data.Models;

namespace GetApp.Data.Services
{
    public interface IExamData
    {
        IEnumerable<Exam> GetAll();
        Exam Get(int id);
        void Add(Exam exam);
        void Update(Exam exam);
        void Delete(int id);
        List<int> GetAllStudentIndexes();
        List<int> GetAllSubjetId();
    }
}
