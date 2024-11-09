using AutoMapper;
using Learning.Domain.Models;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.UpdateChapter
{
    public class UpdateChapterMapper : Profile
    {
        public UpdateChapterMapper()
        {
            CreateMap<UpdateChapterCommand, Chapter>()
                .IncludeMembers(src => src.ChapterDto);
        }
    }
}
