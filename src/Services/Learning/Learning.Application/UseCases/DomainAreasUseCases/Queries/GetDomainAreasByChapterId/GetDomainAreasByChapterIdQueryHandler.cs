using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreasByChapterId
{
    public class GetDomainAreasByChapterIdQueryHandler
        : IRequestHandler<GetDomainAreasByChapterIdQuery, GetDomainAreasByChapterIdResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public GetDomainAreasByChapterIdQueryHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDomainAreasByChapterIdResponse> Handle(GetDomainAreasByChapterIdQuery request, CancellationToken cancellationToken)
        {
            var domainAreas = await _context.Domains
                .Include(d => d.Tests)
                .Include(d => d.Questions)
                .Where(d => d.ChapterId == request.ChapterId)
                .OrderBy(d => d.SerialNumber)
                .ToListAsync(cancellationToken);

            var domainAreasDto = _mapper.Map<List<DomainAreaResponseDto>>(domainAreas);
            return new GetDomainAreasByChapterIdResponse(domainAreasDto);
        }
    }
}
