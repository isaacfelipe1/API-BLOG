using HanamiAPI.Data;
using HanamiAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanamiAPI.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly AppDbContext _context;

        public PostsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Posts>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Posts>> GetAllPostsByUserId(int userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Posts?> GetPostById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<Posts> CreatePost(Posts post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Posts> UpdatePost(Posts post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
