using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_management.Interfaces;
using School_management.Repositories;
using schoolManagement.Models;
using System.IO;
using System.Runtime.CompilerServices;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
       

       

        [HttpGet("videos")]
        public async Task<IActionResult> GetVideo(string videoName)
        {

            var currentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentPath, "Uploads", videoName);
            if (!System.IO.File.Exists(path))
            {
                return null;

            }
          var file= await System.IO.File.ReadAllBytesAsync(path);
            var stream = new MemoryStream(file);
            return File(stream, "video/mp4");
           
        }


        [HttpGet("Images")]
        public async Task<IActionResult> GetImages(string imageName)
        {



            var currentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentPath, "Images", imageName);
            if (!System.IO.File.Exists(path))
            {
                return null;

            }
            var file = await System.IO.File.ReadAllBytesAsync(path);
            var stream = new MemoryStream(file);
            return File(stream, "image/jpeg");

        }


    }



}

