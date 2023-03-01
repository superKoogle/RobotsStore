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

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = UserBusiness.GetUserById(id);
            return user != null ? user : NoContent();
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("SignIn")]
        public ActionResult<User> SignIn([FromBody] User userData)
        {
            User user = UserBusiness.SignIn(userData);
            return user != null ? user : NoContent();
        }


        [HttpPost]
        public CreatedAtActionResult Post([FromBody] User newUser)
        {
            User user = UserBusiness.addNewUser(newUser);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User updatedUser)
        {
            UserBusiness.updateUser(id, updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("password")]
        public int passwordStrength([FromBody] Pwd pwd)
        {
            return UserBusiness.goodPassword(pwd.Password);
        }
    }
}
