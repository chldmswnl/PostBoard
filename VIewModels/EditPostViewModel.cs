using PostsBaord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsBaord.VIewModels
{
    public class EditPostViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<PostCategory> Categories { get; set; }
    }
}
