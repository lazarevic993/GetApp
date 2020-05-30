using System;
using System.Collections.Generic;
using GetApp.Data.Models;

namespace GetApp.Data.Services
{
    public interface ISubjectData
    {
        IEnumerable<Subject> GetAll();
        Subject Get(int id);
        void Add(Subject subject);
        void Update(Subject subject);
        void Delete(int id);
    }
}
