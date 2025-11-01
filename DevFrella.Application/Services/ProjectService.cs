using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructere.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(project.Id);
        }

        public ResultViewModel Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }
            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "")
        {
            var projects = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted && (search == "" || p.Title.Contains(search) || p.Description.Contains(search)))
                .ToList();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Sucess(model);
        }

        public ResultViewModel<ProjectViewModel> GetbyId(int id)
        {
            var project = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

            var model = ProjectViewModel.FromEntity(project);
            
            if(project is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }
            
            return ResultViewModel<ProjectViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(project.Id);
        }

        public ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.ProjectComment.Add(comment);
            _context.SaveChanges();

            return ResultViewModel.Sucess();
        }

        public ResultViewModel Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }

            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(project.Id);
        }

        public ResultViewModel Update(UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == model.IdProject);

            if (project == null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }
            project.Update(model.Title, model.Description, model.TotalCost);

            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Sucess();
        }
    }
}
