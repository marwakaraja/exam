using System.ComponentModel.DataAnnotations;

namespace schoolManagement.Models
{
    public class Video
    {

        [Key]
        public int VideoId { get; set; }
        [Required]
        public string VideoTitle { get; set; } = string.Empty;
        [Required]
        public string VideoUrl { get; set; } =string.Empty;
        public int GradeId { get; set; }
       
    }
}
