using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using LyCilph.SharedKernel;

namespace LyCilph.AwesomeToDo.UseCases.Projects.Create;

public class CreateProjectHandler : ICommandHandler<CreateProjectCommand, int>
{
    private readonly IRepository<Project> _repository;

    public CreateProjectHandler(IRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var proj = new Project(request.Name);
        var createdItem = await _repository.AddAsync(proj, cancellationToken);
        return proj.Id;
    }
}
