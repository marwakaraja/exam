using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_management.Models
{
    public class Post
    {
        public Guid PostId { get; set; }
        [Required]
        public string PostName { get; set; }
        = string.Empty;

        public string ImageName { get; set; }
        = string.Empty;


        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public DateTime DatePost { get; set; }  
    }
}
