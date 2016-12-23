using System.Collections.Generic;
using IainPlimmerApi.Interfaces;
using IainPlimmerApi.Models;

namespace IainPlimmerApi.Repositories
{
    public class BlogPostRepository : IBlogPostRespository
    {
        /* Returns a list of artitary blog posts */
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            var posts = new List<BlogPost>();
            posts.Add(new BlogPost {
                BlogPostId = 1,
                Title = "This is the title",
                Content = "This is some content....." 
            });
             posts.Add(new BlogPost {
                BlogPostId = 2,
                Title = "This is the title",
                Content = "This is some content....." 
            });
             posts.Add(new BlogPost {
                BlogPostId = 3,
                Title = "This is the title",
                Content = "This is some content....." 
            });
             posts.Add(new BlogPost {
                BlogPostId = 4,
                Title = "This is the title",
                Content = "This is some content....." 
            });
            return posts;
        }

        /* Returns the number of blog posts made. */
        public int GetBlogPostCount()
        {
            var posts = this.GetBlogPosts() as List<BlogPost>;
            return posts.Count;
        }
    }
}