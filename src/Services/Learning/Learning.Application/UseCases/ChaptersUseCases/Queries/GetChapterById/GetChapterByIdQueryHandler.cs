using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapterById
{
    public class GetChapterByIdQueryHandler
        : IRequestHandler<GetChapterByIdQuery, GetChapterByIdResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public GetChapterByIdQueryHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetChapterByIdResponse> Handle(GetChapterByIdQuery request, CancellationToken cancellationToken)
        {
            var chapter = await _context.Chapters
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync();

            var chapterDto = _mapper.Map<ChapterResponseDto>(chapter);

            return new GetChapterByIdResponse(chapterDto);
        }
    }
}
