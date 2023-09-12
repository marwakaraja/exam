using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School_management.Models;
using System.ComponentModel.DataAnnotations;

namespace schoolManagement.Models
{
    public class Grade
    {
        [Key]
        public int GradeId {get; set;}
        [Required]
        public string Name { get; set; } = string.Empty;
       
        public string Description { get; set; } =string.Empty!;
        
        public List<Video> Videos { get; set; } = new List<Video>();



    }
}
