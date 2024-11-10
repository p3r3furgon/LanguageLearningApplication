using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.Domain.Models;

public class GetChaptersMapper : Profile
{
    public GetChaptersMapper()
    {
        CreateMap<DomainArea, DomainAreaResponseDto>()
            .ForMember(dest => dest.NumberOfTests, opt => opt.MapFrom(src => src.Tests.Count))
            .ForMember(dest => dest.NumberOfQuestions, opt => opt.MapFrom(src => src.Questions.Count));
    }
}
