using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_management.DTO
{
    public class VideoObj
    {
        [Required]

        public string VideoTitle { get; set; } = string.Empty;
        [Required]

        
        [NotMapped]
        public IFormFile VideoFile { get; set; }    
       
    }
}
