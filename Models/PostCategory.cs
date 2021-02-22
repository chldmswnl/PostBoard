using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsBaord.Models
{
    public class PostCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
