using Microsoft.AspNetCore.Components.Forms;

namespace School_management.Shared
{
    public class UserManagerRespone
    {

        public string Message { get; set; }=string.Empty;
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; } 
        public DateTime? ExpireDate { get; set; }
    }
}
