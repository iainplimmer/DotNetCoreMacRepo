using System.Collections.Generic;
using IainPlimmerApi.Models;

namespace IainPlimmerApi.Interfaces
{
    public interface IBlogPostRespository
    {
        IEnumerable<BlogPost> GetBlogPosts();
    }
}