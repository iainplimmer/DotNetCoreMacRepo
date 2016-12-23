using System.Collections.Generic;
using interfaces = IainPlimmerApi.Interfaces;
using IainPlimmerApi.Models;
using System.Threading.Tasks;
using System;
using IainPlimmerApi.Extensions;

namespace IainPlimmerApi.Repositories
{
    public class BlogPostRepository : interfaces.IBlogPostRespository
    {
        /* Returns a list of artitary blog posts */
        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            // lets MOCK the await here, the results should come from dapper or EF ideally.
            await Task.Delay(500);

            var posts = new List<BlogPost>();
            posts.Add(new BlogPost {
                BlogPostId = 1,
                Title = "Function.prototype.bind()",
                Content = "This is some content.....",
                CreatedDate = "1 September 2016".ToDate(),
                Author = "Iain Plimmer",
                TagCloud = new List<string> { "javascript", "functions", "prototype" }
            });
            posts.Add(new BlogPost {
                BlogPostId = 2,
                Title = "Angular 1.x Directives",
                Content = "This is some content.....",
                CreatedDate = "2 October 2016".ToDate(),
                Author = "Iain Plimmer",
                TagCloud = new List<string> { "javascript", "angular", "directives" }
            });
             posts.Add(new BlogPost {
                BlogPostId = 3,
                Title = "Transitioning to Full Stack from ASP.NET",
                Content = "This is some content.....",
                CreatedDate = "19 October 2016".ToDate(),
                Author = "Iain Plimmer",
                TagCloud = new List<string> { "javascript", "asp.net", "full stack" } 
            });
             posts.Add(new BlogPost {
                BlogPostId = 4,
                Title = "Javascript Promises - Part 2",
                Content = "This is some content.....",
                CreatedDate = "19 december 2016".ToDate(),
                Author = "Iain Plimmer",
                 TagCloud = new List<string> { "javascript", "promises", "async" }
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