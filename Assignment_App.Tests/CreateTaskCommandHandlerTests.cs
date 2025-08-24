using System;
using System.Threading;
using System.Threading.Tasks;
using Assignment_App.Application.Commands;
using Assignment_App.Domain.Entities;
using Assignment_App.Infrastructure.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class CreateTaskCommandHandlerTests
{
    private readonly AppDbContext _dbContext;

    public CreateTaskCommandHandlerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Each test has its own database.
            .Options;

        _dbContext = new AppDbContext(options);
    }

    [Fact]
    public async Task Handle_Should_Create_Task_And_Return_Id()
    {
        // Arrange
        var handler = new CreateTaskCommandHandler(_dbContext);
        var command = new CreateTaskCommand("Test Task");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeEmpty(); // Check that the ID is correctly generated.

        var taskInDb = await _dbContext.TodoTasks.FirstOrDefaultAsync(t => t.Id == result);
        taskInDb.Should().NotBeNull();
        taskInDb!.Title.Should().Be("Test Task");
        taskInDb.IsDone.Should().BeFalse();
    }
}
