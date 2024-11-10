using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetBuildSentanceQuestions
{
    public class GetBuildSentanceQuestionsQueryHandler
        : IRequestHandler<GetBuildSentanceQuestionsQuery, GetBuildSentanceQuestionsResponse>
    {
        private readonly LearningDbContext _context;

        public GetBuildSentanceQuestionsQueryHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<GetBuildSentanceQuestionsResponse> Handle(GetBuildSentanceQuestionsQuery request, CancellationToken cancellationToken)
        {
            var buildSentanceQuiestions = await _context.BuildSentanceQuestions.ToListAsync(cancellationToken);

            return new GetBuildSentanceQuestionsResponse(buildSentanceQuiestions);
        }
    }
}
