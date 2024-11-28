using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.ChaptersUseCases.Queries.GetChapters
{
    public class GetChaptersQueryHandler
        : IRequestHandler<GetChaptersQuery, GetChaptersResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public GetChaptersQueryHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetChaptersResponse> Handle(GetChaptersQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _context.Chapters
                .OrderBy(c => c.SerialNumber)
                .ToListAsync(cancellationToken);
            var chaptersDto = _mapper.Map<List<ChapterResponseDto>>(chapters);

            return new GetChaptersResponse(chaptersDto);
        }
    }
}
