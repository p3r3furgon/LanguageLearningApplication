using MediatR;
using Auth.Domain.Models;

namespace Auth.Application.UseCases.UserUseCases.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id): IRequest<GetUserByIdResponse>;
    public record GetUserByIdResponse(User User);
}
