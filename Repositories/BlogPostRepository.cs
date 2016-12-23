using System.Collections.Generic;
using interfaces = IainPlimmerApi.Interfaces;
using IainPlimmerApi.Models;
using System.Threading.Tasks;

namespace IainPlimmerApi.Repositories
{
    public class BlogPostRepository : interfaces.IBlogPostRespository
    {
        /* Returns a list of artitary blog posts */
        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            await Task.Delay(500);

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
        public async Task<int> GetBlogPostCount()
        {
            var posts = await this.GetBlogPosts() as List<BlogPost>;
            return posts.Count;
        }
    }
}