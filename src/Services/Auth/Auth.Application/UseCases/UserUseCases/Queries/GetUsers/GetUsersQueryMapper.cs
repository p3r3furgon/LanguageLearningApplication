using AutoMapper;
using Auth.Application.Dtos;
using Auth.Domain.Models;

namespace Auth.Application.UseCases.UserUseCases.Queries.GetUsers
{
    public class GetUsersQueryMapper : Profile
    {
        public GetUsersQueryMapper()
        {
            CreateMap<User, UserResponseDto>();
        }
    }
}
