using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Todo.Api.Controllers;
using Todo.Api.Requests;
using Xunit;

namespace Todo.ApiUnitTests.ControllersTests
{
    public class TodoControllerTests
    {
        private Mock<IMediator> _mediator;
        private TodoController _todoController;

        public TodoControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _todoController = new TodoController(_mediator.Object);            
        }

        [Fact]
        public async Task Todo_List_ShouldReturnTodoItemsList()
        {
            //Arrange            
            var todoItems = new List<TodoItem> {
                    new TodoItem()
                    {
                        Id = new Guid(),
                        Text = "Samle Text",
                        Created = DateTime.UtcNow
                    }
                };

            _mediator.Setup(x => x.Send(It.IsAny<ListTodoItemsRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(todoItems);

            //Act
            var result = await _todoController.List(true) as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeEquivalentTo(todoItems);
        }

        [Fact]
        public async Task Todo_Update_ShouldReturnNotFoundResult()
        {
            _mediator.Setup(x => x.Send(It.IsAny<UpdateTodoItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TodoItem)null);

            var result = await _todoController.Update(new UpdateTodoItemRequest { Id = new Guid()}) as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Todo_Update_ShouldReturnOkResult()
        {
            TodoItem todo = new TodoItem
            {
                Id = new Guid(),
                Text = "Samle Text",
                Created = DateTime.UtcNow
            };

            _mediator.Setup(x => x.Send(It.IsAny<UpdateTodoItemRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(todo);

            var result = await _todoController.Update(new UpdateTodoItemRequest { Id = new Guid() }) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
