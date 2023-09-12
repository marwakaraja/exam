using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_management.DTO;
using School_management.Interfaces;
using School_management.Repositories;
using schoolManagement.Models;

namespace School_management.Controllers
{
    [Route("api/Grade/{gradeId}/Video")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IGradeRepository gradeRepository;
        private readonly IFileRepository fileRepository;

        public VideosController(IGradeRepository gradeRepository, IFileRepository fileRepository)
        {
            this.gradeRepository = gradeRepository;
            this.fileRepository = fileRepository;
        }




        [HttpGet]
        public IList<Video> GetVideos(int gradeId)
        {
           
            
            return gradeRepository.GetVideos(gradeId);


        }

        [HttpGet("{Id}")]
        public IActionResult GetVideoById(int gradeId, int VideoId)
        {
            return Ok(gradeRepository.GetVideo(gradeId, VideoId));
        }

        [HttpPost]
        public IActionResult Post(int gradeId, [FromForm] VideoObj video)
        {

            var filename = fileRepository.SaveFile(video.VideoFile);

            var Newvideo = new Video
            {
                VideoTitle = video.VideoTitle,
                VideoUrl = filename,
                GradeId = gradeId
                
            };
            var result = gradeRepository.InsertVideo(Newvideo);
            if (result != null)

                return Ok("Added Successfully");

            return BadRequest(result);
        }

        [HttpPut("{videoid}")]

        public IActionResult Put(int gradeId, int videoId, VideoObj video)
        {
            
       
        var result = gradeRepository.UpdateVideo(gradeId, videoId, video);
            

            return Ok("Updated Successfully");


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int gradeId, int Videoid)
        {

            
            var video = gradeRepository.DeleteVideo(gradeId, Videoid);
            if (video == null) { return NotFound("video not found !"); }
            var filename = video.VideoUrl;
              fileRepository.DeleteFile(filename);
            
                return Ok("Deleted Successfully");

            
        }
    }
}
