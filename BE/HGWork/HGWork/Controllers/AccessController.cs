using HGWork.DTO;
using HGWork.Model;
using HGWork.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HGWork.Controllers
{
    [ApiController]
    [Route("access")]
    public class AccessController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccessController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("login")]
        public async Task<ResponseBase<int>> Login()
        {
            return await _userService.GetAll();
        }
       
    }
}
