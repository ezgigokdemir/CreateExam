using SinavOlusturma.Data;
using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public class FormQuestionOptionRepository : Repository<FormQuestionOption>, IFormQuestionOptionRepository
    {
        private readonly IUnitofWork unitofWork;

        public FormQuestionOptionRepository(ApplicationDbContext dbContext, IUnitofWork unitofWork) : base(dbContext)
        {
            this.unitofWork = unitofWork;
        }

        public int CreateOption(FormQuestionOption optionModel)
        {
            Insert(optionModel);
            unitofWork.SaveChanges();
            return optionModel.Id;
        }
    }
}