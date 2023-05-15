using AutoMapper;
using Business;
using Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DTO;

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
        public UserController(ILogger<UserController> logger,IUserBusiness userBusiness, IMapper mapper)
        {
            this._logger = logger;
            this.userBusiness = userBusiness;
            this._mapper = mapper;
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
        [Route("SignIn")]
        public async Task<ActionResult<UserDTO>> SignIn([FromBody] UserLoginDTO userLoginDTO)
        {
            User user = _mapper.Map<UserLoginDTO, User>(userLoginDTO);
            //User user = _mapper.Map<UserDTO, User>(userDataDTO);
            user = await userBusiness.SignIn(user);
            //UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            _logger.LogInformation($"login: userName - {userDTO.UserEmail} at {DateTime.UtcNow.ToLongTimeString()}");
            return userDTO != null ? userDTO : NoContent();
        }

        [HttpPost]//Sign Up
        public async Task<ActionResult> Post([FromBody] UserDTO newUserDTO)
        {
            User newUser = _mapper.Map<UserDTO, User>(newUserDTO);
            newUser = await userBusiness.addNewUser(newUser);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(newUser);
            return userDTO != null?CreatedAtAction(nameof(Get), new { id = userDTO.UserId }, userDTO) : BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO updatedUserDTO)
        {
            User updatedUser = _mapper.Map<UserDTO, User>(updatedUserDTO);
            await userBusiness.updateUser(id, updatedUser);
 
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
