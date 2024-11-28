using CommonFiles.Pagination;
using MediatR;
using Auth.Application.Dtos;

namespace Auth.Application.UseCases.UserUseCases.Queries.GetUsers
{
    public record GetUsersQuery(PaginationParams PaginationParams): IRequest<GetUsersResponse>;
    public record GetUsersResponse(PagedResponse<UserResponseDto> Users);
}
