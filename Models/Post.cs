using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PostsBaord.Models
{
    public class Post
    {
        public int ID { get; set; } 
        public int Num { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
  
        public DateTime Date { get; set; }
       
        public DateTime UpdatedDate { get; set; }
        public string Writer { get; set; }

        public int CategoryID { get; set; }
       

        [JsonIgnore]
        public PostCategory Category { get; set; }
        [JsonIgnore]
        public ICollection<PostComment> PostComment { get; set; } // Many
       

    }

 
}
