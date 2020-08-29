using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Models
{
    public class ExamModel
    {
        public Exam exam { get; set; }
        public List<FormQuestion> questions { get; set; }
        public FormQuestionOption option { get; set; }
    }
}