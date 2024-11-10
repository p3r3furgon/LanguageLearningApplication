using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.Domain.Models;

namespace Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapters
{
    public class GetChaptersMapper : Profile
    {
        public GetChaptersMapper()
        {
            CreateMap<Chapter, ChapterResponseDto>()
                .ForMember(dest => dest.NumberOfDomainAreas, opt => opt.MapFrom(src => src.Domains.Count));
        }
    }
}
