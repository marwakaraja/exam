using School_management.Exception;
using School_management.Interfaces;
using System.IO;
using System.Net;

namespace School_management.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IHostEnvironment env;

        public FileRepository(IHostEnvironment env)
        {
            this.env = env;
        }

        public bool DeleteFile(string filename)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentPath, "Uploads", filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;

        }

        public bool DeleteImage(string filename)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentPath, "Images", filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }

        public byte[] GetFile(string filesName)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentPath, "Uploads", filesName);
            return  File.ReadAllBytes(path);

        }

        // Gets the contents of a file as a byte array.
        public byte[] GetImage(string filesName)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentPath, "Images", filesName);
            return File.ReadAllBytes(path);
        }


        // Uploads a video file to the server and returns the file name.

        public string SaveFile(IFormFile file)
        {
            var currentPath = this.env.ContentRootPath;
            var path = Path.Combine(currentPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            var ext = Path.GetExtension(file.FileName);
            string uniquestring = Guid.NewGuid().ToString();
            var newfilename = uniquestring + ext;
            var filewithpath = Path.Combine(path, newfilename);
            using (var stream = new FileStream(filewithpath, FileMode.Create))
            {
                file.CopyTo(stream);

            }
            return newfilename;
        }


        // Uploads an image file to the server and returns the file name.

        public string SaveImage(IFormFile file)
        {
            // Defines the allowed file extensions for image files.
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

            // Gets the extension of the uploaded file.
            string fileExtension = Path.GetExtension(file.FileName);

            // Checks if the file extension is allowed for images.
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new ApiException(
                    HttpStatusCode.BadRequest,
                    $"Invalid file type. Only JPG, PNG , WEBP and GIF files are allowed."
                );
            }

            // Uploads the file and returns the file name.
            var currentPath = this.env.ContentRootPath;
            var path = Path.Combine(currentPath, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            var ext = Path.GetExtension(file.FileName);
            string uniquestring = Guid.NewGuid().ToString();
            var newfilename = uniquestring + ext;
            var filewithpath = Path.Combine(path, newfilename);
            using (var stream = new FileStream(filewithpath, FileMode.Create))
            {
                file.CopyTo(stream);

            }
            return newfilename;
        }
    }
}
