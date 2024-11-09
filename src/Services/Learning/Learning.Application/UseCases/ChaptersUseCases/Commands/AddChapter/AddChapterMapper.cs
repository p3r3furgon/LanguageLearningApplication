using AutoMapper;
using Learning.Application.Dtos.RequestDtos;
using Learning.Domain.Models;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.AddChapter
{
    public class AddChapterMapper : Profile
    {
        public AddChapterMapper()
        {
            CreateMap<AddChapterCommand, Chapter>()
                .IncludeMembers(src => src.ChapterDto);

            CreateMap<ChapterRequestDto, Chapter>();
        }
    }
}
