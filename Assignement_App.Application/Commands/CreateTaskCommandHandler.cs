using Assignment_App.Domain.Entities;
using Assignment_App.Infrastructure.Persistence;
using MediatR;
using System;

namespace Assignment_App.Application.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly AppDbContext _context;

        public CreateTaskCommandHandler(AppDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken ct)
        {
            var task = new TodoTask { Id = Guid.NewGuid(), Title = request.Title, IsDone = false };
            _context.TodoTasks.Add(task);
            await _context.SaveChangesAsync(ct);
            return task.Id;
        }
    }
}
