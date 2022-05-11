namespace Todo.Api.Requests;

public class UpdateTodoItemRequest : IRequest<TodoItem>
{
    public Guid Id { get; set; }
}
