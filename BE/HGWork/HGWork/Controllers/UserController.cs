using HGWork.Model;
using HGWork.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HGWork.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuser/{id}")]
        public async Task<User> GetUser([FromQuery] int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpGet("getall")]
        public async Task<List<User>> GetAll()
        {
            return await _userService.GetAll();
        }


        [HttpPost]
        public async Task<int> Create([FromBody] User user)
        {
            return await _userService.Create(user);
        }
    }
}
