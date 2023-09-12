using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School_management.DTO;
using School_management.Interfaces;
using School_management.Models;
using School_management.Repositories;
using schoolManagement.Models;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPost postRepository;
        private readonly IFileRepository fileRepository;

        public PostsController( IPost postRepository , IFileRepository fileRepository)
        {
            this.postRepository = postRepository;
            this.fileRepository = fileRepository;
        }

        [HttpGet]
        public IList<Post> GetPosts()
        {
            return  postRepository.GetPosts().ToList();
        }

        // GET: api/Grade/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(Guid id)
        {
            var PostInfo = postRepository.GetPost(id);

            if (PostInfo == null)
            {
                return NotFound();
            }

            return Ok(PostInfo);
        }


        [HttpPut("{id}")]
        public IActionResult PutPostInfo(Guid id, Postobj postobj)
        {

            var ModifiedPost = new Post
            {
               PostName = postobj.PostName,
              
            };
          var result=  postRepository.UpdatePost(id, ModifiedPost);

            return Ok(result);

        }


        [HttpPost]
        public ActionResult<Post> CreatePost([FromForm]Postobj postobj)
        {

            var filename = fileRepository.SaveImage(postobj.ImageFile);
            var NewPost = new Post
            {
                PostName = postobj.PostName,
                ImageName=filename,
                DatePost = DateTime.UtcNow,

            };

            postRepository.InsertPost(NewPost);

            return Ok(NewPost);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePostInfo(Guid id)
        {
            var postInfo = postRepository.DeletePost(id);
            if (postInfo == null)
            {
                return NotFound();
            }

            
            var filename = postInfo.ImageName;
            fileRepository.DeleteFile(filename);
           
                return Ok("Deleted Successfully");

            
        }

    }
}
