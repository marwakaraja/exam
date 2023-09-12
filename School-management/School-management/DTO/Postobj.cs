using System.ComponentModel.DataAnnotations.Schema;

namespace School_management.DTO
{
    public class Postobj
    {

        public string PostName { get; set; }
       = string.Empty;

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
