using schoolManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace School_management.DTO
{
    public class Gradeobj
    {
        [Required]

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty!;

        public List<Video> Videos { get; set; } = new List<Video>();

    }
}
