using FastEndpoints;
using LyCilph.AwesomeToDo.Core.Interfaces;
using LyCilph.AwesomeToDo.Core.ProjectAggregate;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class GetProjectById : EndpointWithMapping<GetProjectByIdRequest, GetProjectByIdResponse, Project>
{
    private readonly IRepository<Project> _repository;

    public GetProjectById(IRepository<Project> repository)
    {
        _repository = repository;
    }

    public override GetProjectByIdResponse MapFromEntity(Project e) => 
        new GetProjectByIdResponse(e.Id, e.Name, e.Items.Select(i => new ToDoItemRecord(i.Id, i.Title, i.Description, i.IsDone)).ToList());

    public override void Configure()
    {
        Get(GetProjectByIdRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProjectByIdRequest request, CancellationToken ct)
    {
        var proj = await _repository.FirstOrDefault(p => p.Id == request.ProjectId);
        if (proj == null)
        { 
            await SendNotFoundAsync(ct);
            return;
        }

        Response = MapFromEntity(proj);
    }
}
