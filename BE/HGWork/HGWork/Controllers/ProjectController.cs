using HGWork.DTO;
using HGWork.Model;
using HGWork.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HGWork.Controllers
{
    [ApiController]
    [Route("project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("/getall")]
        public async Task<ResponseBase<List<Project>>> Get()
        {
            var res = await _projectService.GetAll();
            return res;
        }

        [HttpPost("/create")]
        public async Task<ResponseBase<int>> Create([FromBody] ProjectDto project)
        {
            var res = await _projectService.Create(project);
            return res;
        }
    }
}
