using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {
        int CreateExam(Exam examModel);

        void DeleteExam(int id);
    }
}