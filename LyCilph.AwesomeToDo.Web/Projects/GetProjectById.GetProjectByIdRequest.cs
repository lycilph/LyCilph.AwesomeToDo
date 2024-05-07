namespace LyCilph.AwesomeToDo.Web.Projects;

public class GetProjectByIdRequest
{
    public const string Route = "/Projects/{ProjectId}";

    public int ProjectId { get; set; }
}
