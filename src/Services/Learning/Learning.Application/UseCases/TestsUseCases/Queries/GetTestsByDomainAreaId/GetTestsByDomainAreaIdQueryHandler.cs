using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.TestsUseCases.Queries.GetTestsByDomainAreaId
{
    public class GetTestsQueryHandler
        : IRequestHandler<GetTestsByDomainAreaIdQuery, GetTestsByDomainAreaIdQueryResponse>
    {
        private readonly LearningDbContext _context;

        public GetTestsQueryHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<GetTestsByDomainAreaIdQueryResponse> Handle(GetTestsByDomainAreaIdQuery request, CancellationToken cancellationToken)
        {
            var tests = await _context.Tests
                .Where(t => t.DomainId == request.DomainAreaId)
                .ToListAsync(cancellationToken);
            return new GetTestsByDomainAreaIdQueryResponse(tests);
        }
    }
}
