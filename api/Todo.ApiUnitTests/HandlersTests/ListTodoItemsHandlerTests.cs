using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Api.Handlers;
using Todo.Api.Requests;
using Todo.Data;
using Xunit;

namespace Todo.ApiUnitTests.HandlersTests
{
    public class ListTodoItemsHandlerTests
    {
        private Mock<ITodoRepository> _todoRepository;
        ListTodoItemsHandler _listTodoItemsHandler;

        public ListTodoItemsHandlerTests()
        {
            _todoRepository = new Mock<ITodoRepository>();
            _listTodoItemsHandler = new ListTodoItemsHandler(_todoRepository.Object);
        }

        [Theory]
        [InlineData(true, 5)]
        [InlineData(false, 3)]
        public async Task ListTodoItemsHandler_Handle_ShouldReturnSortAndFilteredResults(bool includeCompleted, int resultCount)        
        {
            List<TodoItem> todoItems = includeCompleted == true
                ? GetTodoItems().OrderBy(x => x.Created).ToList()
                : GetTodoItems().OrderBy(x => x.Created).Where(x => x.Completed == null).ToList();
            
            Func<IQueryable<TodoItem>, IOrderedQueryable<TodoItem>> orderby = x => x.OrderBy(o => o.Created);

            var repository = new Mock<ITodoRepository>();
            repository.Setup(x => x.List(It.IsAny<Expression<Func<TodoItem, bool>>>(), It.IsAny<Func<IQueryable<TodoItem>, IOrderedQueryable<TodoItem>>>())).ReturnsAsync(todoItems);

            var handler = new ListTodoItemsHandler(repository.Object);

            var result = await handler.Handle(new ListTodoItemsRequest(true), new CancellationToken());

            result.Should().NotBeNull();
            result.Count().Should().Be(resultCount);
            result.FirstOrDefault().Text.Should().Be("ONE");
        }

        public List<TodoItem> GetTodoItems()
        {
            return new List<TodoItem>
            {
                new TodoItem {Id = new Guid(), Text = "Three", Created = DateTime.UtcNow.AddDays(5) },
                new TodoItem {Id = new Guid(), Text = "One", Created = DateTime.UtcNow.AddDays(1) },
                new TodoItem {Id = new Guid(), Text = "Two", Created = DateTime.UtcNow.AddDays(2), Completed = DateTime.UtcNow.AddDays(5) },                
                new TodoItem {Id = new Guid(), Text = "Four", Created = DateTime.UtcNow.AddDays(3), Completed = DateTime.UtcNow.AddDays(5) },
                new TodoItem {Id = new Guid(), Text = "Five", Created = DateTime.UtcNow.AddDays(4) }
            };
        }
    }
}

