using Assignment_App.Domain.Entities;
using Assignment_App.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Assignment_App.Application.Queries
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TodoTask>>
    {
        private readonly AppDbContext _context;

        public GetTasksQueryHandler(AppDbContext context) => _context = context;

        public async Task<List<TodoTask>> Handle(GetTasksQuery request, CancellationToken ct)
        {
            return await _context.TodoTasks.AsNoTracking().ToListAsync(ct);
        }
    }
}
