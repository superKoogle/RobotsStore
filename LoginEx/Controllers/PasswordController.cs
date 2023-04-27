using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        IPasswordBusiness passwordBusiness;

        public PasswordController(IPasswordBusiness passwordBusiness)
        {
            this.passwordBusiness = passwordBusiness;
        }
        // POST api/<PasswordController>
        [HttpPost]
       
        public async Task<int> passwordStrength([FromBody] string pwd)
        {
            return await passwordBusiness.goodPassword(pwd);
        }
      

    }
}
