using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetBuildSentanceQuestionById
{
    public class GetBuildSentanceQuestionByIdQueryHandler
        : IRequestHandler<GetBuildSentanceQuestionByIdQuery, GetBuildSentanceQuestionByIdResponse>
    {

        private readonly LearningDbContext _context;

        public GetBuildSentanceQuestionByIdQueryHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<GetBuildSentanceQuestionByIdResponse> Handle(GetBuildSentanceQuestionByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var buildSentanceQuestion = await _context.BuildSentanceQuestions
                .FirstOrDefaultAsync(q => q.Id == request.Id);

            return new GetBuildSentanceQuestionByIdResponse(buildSentanceQuestion);
        }
    }
}
