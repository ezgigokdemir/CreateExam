using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Entities
{
    public class FormAnswer
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int FormQuestionId { get; set; }
        public int FormQuestionOptionId { get; set; }
        public string OptionText { get; set; }
    }
}