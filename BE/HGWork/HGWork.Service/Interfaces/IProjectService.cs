using HGWork.DTO;
using HGWork.Model;

namespace HGWork.Service.Interfaces
{
    public interface IProjectService
    {
        Task<ResponseBase<List<Project>>> GetAll();
        Task<ResponseBase<int>> Create(ProjectDto project);
    }
}
