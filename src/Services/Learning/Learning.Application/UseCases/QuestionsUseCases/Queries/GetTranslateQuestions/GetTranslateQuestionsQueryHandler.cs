using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetTranslateQuestions
{
    public class GetTranslateQuestionsQueryHandler
        : IRequestHandler<GetTranslateQuestionsQuery, GetTranslateQuestionsResponse>
    {
        private readonly LearningDbContext _context;

        public GetTranslateQuestionsQueryHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<GetTranslateQuestionsResponse> Handle(GetTranslateQuestionsQuery request, CancellationToken cancellationToken)
        {
            var translateQuestions = await _context.TranslateQuestions.ToListAsync(cancellationToken);

            return new GetTranslateQuestionsResponse(translateQuestions);
        }
    }
}
