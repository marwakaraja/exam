
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using School_management.DTO;

using schoolManagement.Interfaces;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
       

        public AccountsController(IAuthRepository authRepository)
           
        {

            this.authRepository = authRepository;
            
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(AccountLogin model)
        {
            if(ModelState.IsValid) 
            { 
                var result=await authRepository.LoginUserAsync(model);
                if(result.IsSuccess) 
                    return Ok(result);  
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");

        }


        
        [HttpPost("Register")]
            public async  Task<IActionResult> RegisterAsync([FromForm] AccountRegiste new_account)
            {
            if(ModelState.IsValid)
            {  var result = await authRepository.RegistUserAsync(new_account);
                    return Ok(result);
               
            }

            return BadRequest("some properties is not valid");
           
            }

        [HttpGet]
        public async Task<IList<IdentityUser>> GetUsers()
        {
            
            return await authRepository.GetUsersAsync();
        }







    }
    }







