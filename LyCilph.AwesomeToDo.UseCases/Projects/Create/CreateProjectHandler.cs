using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using LyCilph.SharedKernel;
using Microsoft.Extensions.Logging;

namespace LyCilph.AwesomeToDo.UseCases.Projects.Create;

public class CreateProjectHandler : ICommandHandler<CreateProjectCommand, int>
{
    private readonly IRepository<Project> _repository;
    private readonly ILogger<CreateProjectHandler> _logger;

    public CreateProjectHandler(IRepository<Project> repository, ILogger<CreateProjectHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating project {name}", request.Name);

        var proj = new Project(request.Name);
        var createdItem = await _repository.AddAsync(proj, cancellationToken);
        return proj.Id;
    }
}
