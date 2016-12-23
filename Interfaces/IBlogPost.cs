using System.Collections.Generic;
using IainPlimmerApi.Models;
using System.Threading.Tasks;

namespace IainPlimmerApi.Interfaces
{
    public interface IBlogPostRespository
    {
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<int> GetBlogPostCount();
    }
}