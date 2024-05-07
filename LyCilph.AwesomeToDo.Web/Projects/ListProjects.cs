using FastEndpoints;
using LyCilph.AwesomeToDo.Core.Interfaces;
using LyCilph.AwesomeToDo.Core.ProjectAggregate;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class ListProjects : EndpointWithoutRequest<ListProjectsResponse>
{
    private readonly IRepository<Project> _repository;

    public ListProjects(IRepository<Project> repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/Projects");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var projectList = await _repository.ListAsync(ct);
        Response = new ListProjectsResponse
        {
            Projects = projectList.Select(p => new ProjectRecord(p.Id, p.Name)).ToList()
        };
    }
}
