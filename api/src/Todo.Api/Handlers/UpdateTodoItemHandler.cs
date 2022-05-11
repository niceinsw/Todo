using Todo.Api.Requests;

namespace Todo.Api.Handlers
{
    public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemRequest, TodoItem>
    {
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoItemHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoItem> Handle(UpdateTodoItemRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoRepository.Get(request.Id);

            if (todoItem == null)
                return null;

            if (todoItem.Completed.HasValue)
                return todoItem;

            todoItem.Completed = DateTime.UtcNow;

            await _todoRepository.Update(todoItem);

            return todoItem;
        }
    }
}
