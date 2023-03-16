using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBusiness userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await userBusiness.GetUserById(id);
            return user != null ? user : NoContent();
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("SignIn")]
        public async Task<ActionResult<User>> SignIn([FromBody] User userData)
        {
            User user = await userBusiness.SignIn(userData);
            return user != null ? user : NoContent();
        }


        [HttpPost]//SignUp
        public async Task<ActionResult?> Post([FromBody] User newUser)
        {
            User user = await userBusiness.addNewUser(newUser);
            return user!=null?CreatedAtAction(nameof(Get), new { id = user.UserId }, user):BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User updatedUser)
        {
            await userBusiness.updateUser(id, updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       
    }
}
