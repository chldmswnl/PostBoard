﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsBaord.InputModel
{
    public class EditPostInputModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Writer { get; set; }

        public int CategoryID { get; set; }
    }
}
