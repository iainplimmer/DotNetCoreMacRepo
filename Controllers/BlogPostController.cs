using System;
//using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IainPlimmerApi.Repositories;
using IainPlimmerApi.Interfaces;
using IainPlimmerApi.Models;

namespace IainPlimmerApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostController : Controller
    {
        IBlogPostRespository _repo;
        public BlogPostController(IBlogPostRespository repo)
        {
            this._repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            //var i = new BlogPostRepository();
            var iain = _repo.GetBlogPosts();
            
            return iain;
        }
    }
}
