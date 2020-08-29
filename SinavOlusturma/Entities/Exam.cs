using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Entities
{
    public class Exam : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public List<FormQuestion> questions { get; set; }
        public DateTime CreateDate { get; set; }
    }
}