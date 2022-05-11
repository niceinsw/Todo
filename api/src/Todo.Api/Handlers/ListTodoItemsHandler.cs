using System.Linq.Expressions;
using Todo.Api.Requests;

namespace Todo.Api.Handlers;

public class ListTodoItemsHandler : IRequestHandler<ListTodoItemsRequest, IEnumerable<TodoItem>>
{
    private readonly ITodoRepository _todoRepository;

    public ListTodoItemsHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoItem>> Handle(ListTodoItemsRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<TodoItem, bool>> filter = request.IncludeCompleted
            ? null
            : item => !item.Completed.HasValue;

        var results = await _todoRepository.List(filter, y => y.OrderBy(o => o.Created));

        return results;
    }
}