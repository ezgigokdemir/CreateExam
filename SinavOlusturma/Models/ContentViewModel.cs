using SinavOlusturma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinavOlusturma.Models
{
    public class ContentViewModel
    {
        public List<Exam> contentList { get; set; }

        public Exam exam { get; set; }
        public string Name { get; set; }
    }

    public class Content
    {
        public string title { get; set; }
        public string text { get; set; }
    }
}