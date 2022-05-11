namespace Todo.Api.Requests;

public class ListTodoItemsRequest : IRequest<IEnumerable<TodoItem>>
{
    public bool IncludeCompleted { get; set; }

    public ListTodoItemsRequest(bool IncludeCompleted)
    {
        this.IncludeCompleted = IncludeCompleted;
    }

}