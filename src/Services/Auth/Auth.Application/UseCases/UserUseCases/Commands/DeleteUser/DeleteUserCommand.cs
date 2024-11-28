using MediatR;

namespace Auth.Application.UseCases.UserUseCases.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest<DeleteUserResponse>;

    public record DeleteUserResponse(Guid Id);
}
