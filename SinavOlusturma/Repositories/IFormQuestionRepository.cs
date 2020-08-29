using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public interface IFormQuestionRepository : IRepository<FormQuestion>
    {
        int CreateQuestion(FormQuestion questionModel);
    }
}