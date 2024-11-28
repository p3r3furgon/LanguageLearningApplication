using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.LearningUseCases.Queries.GetLanguageCourseContent
{
    public class GetLanguageCourseContentQueryHander
        : IRequestHandler<GetLanguageCourseContentQuery, GetLanguageCourseContentResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public GetLanguageCourseContentQueryHander(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetLanguageCourseContentResponse> Handle(GetLanguageCourseContentQuery request, CancellationToken cancellationToken)
        {
            var courseContent = await  _context.Chapters
                .Include(c => c.Domains)
                .ThenInclude(d => d.Tests)
                .ToListAsync();

            var groupedStructure = courseContent
            .ToDictionary(
                module => module.Id,
                module => module.Domains
                    .ToDictionary(
                        domain => domain.Id,
                        domain => domain.Tests
                        .Select(t => t.Id)
                        .ToList()
                    )
            );
            return new GetLanguageCourseContentResponse(groupedStructure);
        }
    }
}
