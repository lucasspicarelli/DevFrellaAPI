using DevFreela.Application.Models;
using DevFreela.Infrastructere.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.CompleteProject
{
    // Corrigido: ResultViewModel não deve ser herdado, apenas usado como retorno.
    // Corrigido: IRequestHandler deve ser parametrizado com (CompleteProjectCommand, ResultViewModel)
    public class CompleteProjectHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public CompleteProjectHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        // Corrigido: assinatura correta do método Handle
        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (project == null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");
            }

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChangesAsync();

            return ResultViewModel<int>.Sucess(project.Id);
        }
    }
}
