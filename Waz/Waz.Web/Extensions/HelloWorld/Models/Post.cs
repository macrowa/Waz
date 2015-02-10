using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class Post
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<string> Comments { get; set; }
    }
}