using HanamiAPI.Models;
using HanamiAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HanamiAPI.Dtos;

namespace HanamiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly UserManager<PessoaComAcesso> _userManager;
        private readonly IPostsRepository _postsRepository;

        public PostsController(UserManager<PessoaComAcesso> userManager, IPostsRepository postsRepository)
        {
            _userManager = userManager;
            _postsRepository = postsRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Posts post)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            post.UserId = user.Id;
            post.CreatedAt = DateTime.UtcNow; 
            var createdPost = await _postsRepository.CreatePost(post);
            return Ok(new PostDto
            {
                Id = createdPost.Id,
                Title = createdPost.Title,
                Content = createdPost.Content,
                CreatedAt = createdPost.CreatedAt
            });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postsRepository.GetAllPosts();
            var postsDto = posts.Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            }).ToList();

            return Ok(postsDto);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPosts()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var posts = await _postsRepository.GetAllPostsByUserId(user.Id);
            var postsDto = posts.Select(post => new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            }).ToList();

            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postsRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            var postDto = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            };

            return Ok(postDto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Posts updatedPost)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var post = await _postsRepository.GetPostById(id);
            if (post == null || post.UserId != user.Id)
            {
                return NotFound();
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;

            var result = await _postsRepository.UpdatePost(post);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var post = await _postsRepository.GetPostById(id);
            if (post == null || post.UserId != user.Id)
            {
                return NotFound();
            }

            var result = await _postsRepository.DeletePost(id);
            if (!result)
            {
                return BadRequest("Não foi possível excluir a postagem.");
            }

            return NoContent();
        }
    }
}