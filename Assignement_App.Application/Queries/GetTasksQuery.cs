using Assignment_App.Domain.Entities;
using MediatR;

namespace Assignment_App.Application.Queries
{
    public record GetTasksQuery : IRequest<List<TodoTask>>;
}
