using SinavOlusturma.Data;
using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Repositories
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        private readonly IUnitofWork unitofWork;

        public ExamRepository(ApplicationDbContext dbContext, IUnitofWork unitofWork) : base(dbContext)
        {
            this.unitofWork = unitofWork;
        }

        public int CreateExam(Exam examModel)
        {
            Insert(examModel);
            unitofWork.SaveChanges();
            return examModel.Id;
        }

        public void DeleteExam(int id)
        {
            var exam = Find(id);
            exam.RecordStatus = SinavOlusturma.Entities.RecordStatus.D;
            Update(exam);

            //foreach (var que in exam.questions)
            //{
            //    var question = Find(que.Id);
            //    question.RecordStatus = SinavOlusturma.Entities.RecordStatus.D;
            //    Update(question);

            //    foreach (var opt in que.options)
            //    {
            //        var option = Find(opt.Id);
            //        option.RecordStatus = SinavOlusturma.Entities.RecordStatus.D;
            //        Update(option);
            //    }
            //}

            unitofWork.SaveChanges();
        }
    }
}