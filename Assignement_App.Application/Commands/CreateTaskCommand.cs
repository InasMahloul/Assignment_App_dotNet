using MediatR;

namespace Assignment_App.Application.Commands
{
    public record CreateTaskCommand(string Title) : IRequest<Guid>;
}
