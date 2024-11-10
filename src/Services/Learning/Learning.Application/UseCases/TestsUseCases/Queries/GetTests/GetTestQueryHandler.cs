using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.TestsUseCases.Queries.GetTests
{
    public class GetTestsQueryHandler
        : IRequestHandler<GetTestsQuery, GetTestsResponse>
    {
        private readonly LearningDbContext _context;

        public GetTestsQueryHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<GetTestsResponse> Handle(GetTestsQuery request, CancellationToken cancellationToken)
        {
            var tests = await _context.Tests.ToListAsync(cancellationToken);

            return new GetTestsResponse(tests);
        }
    }
}
