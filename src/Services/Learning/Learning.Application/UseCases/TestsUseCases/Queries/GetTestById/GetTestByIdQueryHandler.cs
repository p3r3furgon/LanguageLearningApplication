using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.TestsUseCases.Queries.GetTestById
{
    public class GetTestByIdQueryHandler
        : IRequestHandler<GetTestByIdQuery, GetTestByIdResponse>
    {
        private readonly LearningDbContext _context;

        public GetTestByIdQueryHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<GetTestByIdResponse> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            var test = await _context.Tests
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            return new GetTestByIdResponse(test);
        }
    }
}
