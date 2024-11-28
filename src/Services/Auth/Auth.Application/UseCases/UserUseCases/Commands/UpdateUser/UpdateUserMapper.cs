using AutoMapper;
using Auth.Application.Dtos;
using Auth.Domain.Models;

namespace Auth.Application.UseCases.UserUseCases.Commands.UpdateUser
{
    public class UpdateUserMapper : Profile
    {
        public UpdateUserMapper()
        {
            CreateMap<UpdateUserCommand, User>()
                .IncludeMembers(src => src.UserDto);

            CreateMap<UserRequestDto, User>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateOnly.Parse(src.BirthDate)));
        }
    }
}
