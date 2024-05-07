using FastEndpoints;
using LyCilph.AwesomeToDo.Core.Interfaces;
using LyCilph.AwesomeToDo.Core.ProjectAggregate;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class CreateProject : EndpointWithMapping<CreateProjectRequest, CreateProjectResponse, Project>
{
    private readonly IRepository<Project> _repository;

    public CreateProject(IRepository<Project> repository)
    {
        _repository = repository;
    }

    public override Project MapToEntity(CreateProjectRequest r) => new(r.Name!);
    public override CreateProjectResponse MapFromEntity(Project e) => new(e.Id, e.Name!);

    public override void Configure()
    {
        Post(CreateProjectRequest.Route);
        AllowAnonymous();
        Summary(s => s.ExampleRequest = new CreateProjectRequest { Name = "Example Project" });
    }

    public override async Task HandleAsync(CreateProjectRequest request, CancellationToken ct)
    {
        var project = MapToEntity(request);
        var savedProject = await _repository.AddAsync(project, ct);
        Response = MapFromEntity(savedProject);
    }
}
