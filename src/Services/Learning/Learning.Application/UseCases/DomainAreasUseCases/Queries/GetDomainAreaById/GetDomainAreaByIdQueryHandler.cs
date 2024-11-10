using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.DomainAreasUseCases.Queries.GetDomainAreaById
{
    public class GetDomainAreaByIdQueryHandler
        : IRequestHandler<GetDomainAreaByIdQuery, GetDomainAreaByIdResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public GetDomainAreaByIdQueryHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDomainAreaByIdResponse> Handle(GetDomainAreaByIdQuery request, CancellationToken cancellationToken)
        {
            var domainArea = await _context.Domains
                .Include(d => d.Tests) 
                .Include(d => d.Questions)
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            var domainAreaDto = _mapper.Map<DomainAreaResponseDto>(domainArea);
            return new GetDomainAreaByIdResponse(domainAreaDto);
        }
    }
}
