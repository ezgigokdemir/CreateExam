using SinavOlusturma.Data;
using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public class FormQuestionRepository : Repository<FormQuestion>, IFormQuestionRepository
    {
        private readonly IUnitofWork unitofWork;

        public FormQuestionRepository(ApplicationDbContext dbContext, IUnitofWork unitofWork) : base(dbContext)
        {
            this.unitofWork = unitofWork;
        }

        public int CreateQuestion(FormQuestion questionModel)
        {
            Insert(questionModel);
            unitofWork.SaveChanges();
            return questionModel.Id;
        }
    }
}