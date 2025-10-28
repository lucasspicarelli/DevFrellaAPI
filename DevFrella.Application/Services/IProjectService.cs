using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services
{
    public interface IProjectService
    {
        ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "");
        ResultViewModel<ProjectViewModel> GetbyId(int  id);
        ResultViewModel<int> Insert(CreateProjectInputModel model);
        ResultViewModel Update(UpdateProjectInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel Start(int id);
        ResultViewModel Complete(int id);
        ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model);
    }

    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;        

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Complete(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "")
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<ProjectViewModel> GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel<int> Insert(CreateProjectInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Start(int id)
        {
            throw new NotImplementedException();
        }

        public ResultViewModel Update(UpdateProjectInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
