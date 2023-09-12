using Microsoft.AspNetCore.Identity;
using School_management.DTO;
using School_management.Models;
using School_management.Shared;
using schoolManagement.Models;

namespace schoolManagement.Interfaces
{
    public interface IAuthRepository
    {
        Task<School_management.Shared.UserManagerRespone> RegistUserAsync(AccountRegiste model);
        Task<School_management.Shared.UserManagerRespone> LoginUserAsync(AccountLogin model);
        Task<List<IdentityUser>> GetUsersAsync();

    }
}