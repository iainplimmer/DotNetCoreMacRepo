using System;
using System.Collections.Generic;

namespace IainPlimmerApi.Models
{
    public sealed class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Author { get; set; }
        public IEnumerable<string> TagCloud { get; set; }
        public string Content { get; set; }
    }
}