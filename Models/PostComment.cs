using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PostsBaord.Models
{
    public class PostComment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public string Writer { get; set; }
     
        public DateTime Date { get; set; }
        public Post Posts { get; set; } // One
    }
}
