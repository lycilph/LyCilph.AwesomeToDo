using FastEndpoints;
using FluentValidation;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class GetProjectByIdValidator : Validator<GetProjectByIdRequest>
{
    public GetProjectByIdValidator()
    {
        RuleFor(x => x.ProjectId)
            .GreaterThanOrEqualTo(0);
    }
}
