using HanamiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HanamiAPI.Repositories
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Posts>> GetAllPosts();
        Task<IEnumerable<Posts>> GetAllPostsByUserId(int userId);
        Task<Posts?> GetPostById(int id); 
        Task<Posts> CreatePost(Posts post);
        Task<Posts> UpdatePost(Posts post);
        Task<bool> DeletePost(int id);
    }
}
