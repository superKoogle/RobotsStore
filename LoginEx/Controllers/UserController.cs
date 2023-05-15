using AutoMapper;
using Business;
using Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogger<UserController> _logger;
        IUserBusiness userBusiness;
        IMapper _mapper;
        public UserController(IUserBusiness userBusiness, IMapper mapper, ILogger<UserController> logger)
        {
            _logger = logger;
            this.userBusiness = userBusiness;
            _mapper = mapper;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await userBusiness.GetUserById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO != null ? userDTO : NoContent();
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("SignIn")]//no dto yet
        public async Task<ActionResult<UserDTO>> SignIn([FromBody] UserLoginDTO userLoginData)
        {

            User userData = _mapper.Map<UserLoginDTO, User>(userLoginData);
            User user = await userBusiness.SignIn(userData);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            _logger.LogInformation($"\nLogin: userName - {userDTO.UserEmail} at {DateTime.UtcNow.ToLongTimeString()}\n");
            return userDTO != null ? userDTO : NoContent();
        }


        [HttpPost]//SignUp
        public async Task<ActionResult?> Post([FromBody] UserDTO newUserDto)
        {
            User newUser = _mapper.Map<UserDTO, User>(newUserDto);
            User user = await userBusiness.addNewUser(newUser);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO!=null?CreatedAtAction(nameof(Get), new { id = userDTO.UserId }, userDTO): BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO updatedUserDto)
        {
            User updatedUser = _mapper.Map<UserDTO, User>(updatedUserDto);
            await userBusiness.updateUser(id, updatedUser);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       
    }
}
