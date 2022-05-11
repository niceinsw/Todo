namespace Todo.Api.Requests;

public class CreateTodoItemRequest : IRequest<Guid>
{
    public string Text { get; set; }
}