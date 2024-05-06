using FastEndpoints;
using LyCilph.AwesomeToDo.UseCases.Projects.Create;
using MediatR;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class Create : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post(CreateProjectRequest.Route);
        AllowAnonymous();
        Summary(s => s.ExampleRequest = new CreateProjectRequest { Name = "Example Project" });
    }

    public override async Task HandleAsync(CreateProjectRequest request, CancellationToken ct)
    {
        var result = await _mediator.Send(new CreateProjectCommand(request.Name!));
        Response = new CreateProjectResponse(result, request.Name!);
        return;
    }
}