using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostsBaord.Data;
using PostsBaord.InputModel;
using PostsBaord.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;


// SPA (React) 
// Modern way
// Mobile에서도 사용가능

namespace PostsBaord.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly MainDbContext context;

        public PostApiController(MainDbContext context)
        {
            this.context = context;
        }
        // GET /api/posts
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return context.Posts.ToList();
          
        }

        // GET /api/posts/:id
        [HttpGet("{id}")]
        public Post GetPostByID(int id)
        {
            return context.Posts.SingleOrDefault(p => p.ID == id);
        }

        // POST /api/posts/add
        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddPost([FromBody] AddPostInputModel inputModel)
        {
           
            context.Posts.Add(new Post
            {
                Title = inputModel.Title,
                Writer = inputModel.Writer,
                Content = inputModel.Content,
                ViewCount = 0,
                LikeCount = 0,
                Date = DateTime.UtcNow,
                CategoryID = 1,
               

            }); 
            await context.SaveChangesAsync();

            
            
            return Ok();
        }

        //POST /api/posts/edit
        [HttpPost("edit")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> EditPost([FromBody] EditPostInputModel inputModel)
        {
       
            var post = context.Posts.SingleOrDefault(n => n.ID == inputModel.ID);

            post.Title = inputModel.Title;
            post.Writer = inputModel.Writer;
            post.CategoryID = inputModel.CategoryID;
            post.Content = inputModel.Content;
            post.UpdatedDate = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return Ok();

        }

        //Get /api/posts/getComment
        /*[HttpGet("getComment/{id}")]
        public IEnumerable<PostComment> GetPostComments(int postID)
        {
            return context.PostComment.Where(p=> p.PostID==postID);

        }*/

        //Post /api/posts/addComment
        [HttpPost("addComment")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AddComment([FromBody] AddCommentInputModel inputModel)
        {
            context.PostComment.Add(new PostComment
            {
              
                Writer = "None",
                Content = inputModel.Content,
                LikeCount = 0,
                Date = DateTime.UtcNow,

            });
            await context.SaveChangesAsync();

            
            
            return Ok();
        }

         // DELETE /api/posts/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostByID(int id)
        {
            var foundPost=context.Posts.SingleOrDefault(p => p.ID == id);
            if(foundPost==null)
            {
                return BadRequest();
            }
            context.Posts.Remove(foundPost);
            await context.SaveChangesAsync();

            return Ok();
        }
        
    }
}
