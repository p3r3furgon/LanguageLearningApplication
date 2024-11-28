using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreas
{
    public class GetDomainAreasQueryHandler
        : IRequestHandler<GetDomainAreasQuery, GetDomainAreasResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public GetDomainAreasQueryHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDomainAreasResponse> Handle(GetDomainAreasQuery request, CancellationToken cancellationToken)
        {
            var domainAreas = await _context.Domains
                .Include(d => d.Tests)
                .Include(d => d.Questions)
                .OrderBy(d => d.Chapter.SerialNumber)
                .ThenBy(d => d.SerialNumber)
                .ToListAsync(cancellationToken);

            var domainAreasDto = _mapper.Map<List<DomainAreaResponseDto>>(domainAreas);
            return new GetDomainAreasResponse(domainAreasDto);
        }
    }
}
