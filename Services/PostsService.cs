using HanamiAPI.Models;
using HanamiAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HanamiAPI.Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<IEnumerable<Posts>> GetAllPostsByUserId(int userId)
        {
            return await _postsRepository.GetAllPostsByUserId(userId);
        }

        public async Task<Posts> GetPostById(int id)
        {
            return await _postsRepository.GetPostById(id);
        }

        public async Task<Posts> CreatePost(Posts post)
        {
            return await _postsRepository.CreatePost(post);
        }

        public async Task<Posts> UpdatePost(Posts post)
        {
            return await _postsRepository.UpdatePost(post);
        }

        public async Task<bool> DeletePost(int id)
        {
            return await _postsRepository.DeletePost(id);
        }
    }
}
