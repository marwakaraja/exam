
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_management.DTO;
using School_management.Exception;
using schoolManagement.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly IConfiguration configuration;

    public AuthRepository(UserManager<IdentityUser> userManager,   IConfiguration configuration)
    {
        this.userManager = userManager;
        this.configuration = configuration;
    }



    

       public async Task<School_management.Shared.UserManagerRespone> RegistUserAsync(AccountRegiste model)
    {
        if(model == null)
        {
            throw new NullReferenceException("Register Model is null");
        }
        if (model.Password != model.ConfirmPassword)
            return new School_management.Shared.UserManagerRespone
            {
                Message = "Cofirm password didn't match the password",
                IsSuccess = false
            };
        var identityUser = new IdentityUser
        {
            Email = model.Email,
            UserName = model.Email
        };
        var result= await userManager.CreateAsync(identityUser, model.Password);
        if(result.Succeeded) 
        
            return new School_management.Shared.UserManagerRespone
            {
                Message = "User create successfully",
                IsSuccess = true,
            };





        
        return new School_management.Shared.UserManagerRespone
        {
            Message = "User didn't create",
            IsSuccess = false,
            Errors = result.Errors.Select(e => e.Description)
        };


    }



   public async Task<School_management.Shared.UserManagerRespone> LoginUserAsync(AccountLogin model)
   {
        var user = await userManager.FindByEmailAsync(model.Email);
        if(user == null)
        {
            return new School_management.Shared.UserManagerRespone
            {
                Message = "there is no user with that Email address",
                IsSuccess = false
            };
        }

        var result=await userManager.CheckPasswordAsync(user, model.Password);
        if (!result)
            return new School_management.Shared.UserManagerRespone
            {
                Message = "invalid password",
                IsSuccess = false,

            };
        var claims = new[]
           {
                new Claim ("Email",model.Email),
                new Claim (ClaimTypes.NameIdentifier,user.Id)

            };
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:Secret"]));
        var signingcreditionals = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var mytoken = new JwtSecurityToken(
            configuration["Authentication:Issuer"],
            configuration["Authentication:Audience"],
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingcreditionals
            );
        var serializertoken = new JwtSecurityTokenHandler().WriteToken(mytoken);
        return new School_management.Shared.UserManagerRespone
        {
            Message = serializertoken,
            IsSuccess = true,
            ExpireDate = mytoken.ValidTo
        };

    }


    public async Task<List<IdentityUser>> GetUsersAsync()
    {
        return await userManager.Users.ToListAsync();
    }

}


