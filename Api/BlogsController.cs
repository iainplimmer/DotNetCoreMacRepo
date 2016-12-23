using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IainPlimmerApi.Interfaces;
using IainPlimmerApi.Models;

namespace IainPlimmerApi.Controllers
{
    /// <summary>
    /// API end point that is used to manage the retreival of blog posts from the mocked database
    /// </summary>
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        IBlogPostRespository _repo;
        public BlogsController(IBlogPostRespository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Returns all blog posts from the mocked database
        /// </summary>
        [Route("GetBlogPosts")]
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
            var posts = await _repo.GetBlogPosts() as List<BlogPost>;            
            if (posts != null && posts.Count > 0)
            {
                return Ok(posts);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Returns a count of the blog posts from the mocked database
        /// </summary>
        [Route("GetBlogCount")]
        [HttpGet]
        public async Task<IActionResult> GetBlogCount()
        {
            return Ok(await _repo.GetBlogPostCount());
        }
    }
}
