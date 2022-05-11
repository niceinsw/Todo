using System.Linq.Expressions;
using Todo.Api.Requests;

namespace Todo.Data;

public interface ITodoRepository
{
    Task<TodoItem> Get(Guid id);

    Task<IEnumerable<TodoItem>> List(
        Expression<Func<TodoItem, bool>> filter = null,
        Func<IQueryable<TodoItem>, IOrderedQueryable<TodoItem>> orderBy = null);

    Task<Guid> Create(TodoItem newItem);

    Task<TodoItem> Update(TodoItem updateItem);
}