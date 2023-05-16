using HGWork.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HGWork.Controllers
{
    [ApiController]
    [Route("/")]
    public class HeathCheckController : Controller
    {
        private readonly IProjectService _projectService;
        public HeathCheckController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<string> Index()
        {
            var res = await _projectService.GetById(1);
            return "Service is working!";
        }
    }
}
