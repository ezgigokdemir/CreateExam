using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Entities
{
    public class FormQuestionOption : BaseEntity
    {
        public int Id { get; set; }

        public int FormQuestionId { get; set; }
        public string OptionText { get; set; }
        public int IsAnswer { get; set; }
        public int IsSelected { get; set; }
    }
}