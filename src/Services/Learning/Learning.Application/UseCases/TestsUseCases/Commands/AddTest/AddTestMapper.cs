using AutoMapper;
using Learning.Application.Dtos.RequestDtos;
using Learning.Domain.Models;

namespace Learning.Application.UseCases.TestsUseCases.Commands.AddTest
{
    public class AddTestMapper : Profile
    {
        public AddTestMapper()
        {
            CreateMap<AddTestCommand, Test>()
                .IncludeMembers(src => src.TestDto);

            CreateMap<TestRequestDto, Test>();
        }
    }
}
