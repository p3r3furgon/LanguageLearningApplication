using MediatR;

namespace Auth.Application.UseCases.UserUseCases.Commands.RevokeAdminRole
{
    public record RevokeAdminRoleCommand(Guid Id) : IRequest<RevokeAdminRoleResponse>;
    public record RevokeAdminRoleResponse(Guid Id);
    
}
