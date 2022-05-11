using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Todo.Api.Requests;

namespace Todo.Data;

public class TodoRepository: ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Create(TodoItem newItem)
    {
        await _context.TodoItems.AddAsync(newItem);
        await _context.SaveChangesAsync();
        return newItem.Id;
    }

    public async Task<TodoItem> Get(Guid id)
    {
        return await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TodoItem>> List(Expression<Func<TodoItem, bool>> filter = null, 
        Func<IQueryable<TodoItem>, IOrderedQueryable<TodoItem>> orderBy = null)
    {
        IQueryable<TodoItem> query = _context.TodoItems.AsQueryable();

        if (filter != null)
            query = query.Where(filter);

        return orderBy != null
            ? orderBy.Invoke(query)
            : await query.ToListAsync();
    }

    public async Task<TodoItem> Update(TodoItem newItem)
    {
        var todoItem = _context.TodoItems.Attach(newItem);
        todoItem.State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return newItem;
    }
}