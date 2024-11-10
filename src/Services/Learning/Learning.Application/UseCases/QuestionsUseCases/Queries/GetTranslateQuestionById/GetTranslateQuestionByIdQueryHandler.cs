using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetTranslateQuestionById
{
    public class GetTranslateQuestionByIdQueryHandler
        : IRequestHandler<GetTranslateQuestionByIdQuery, GetTranslateQuestionByIdResponse>
    {
        private readonly LearningDbContext _context;

        public GetTranslateQuestionByIdQueryHandler(LearningDbContext context)
        {
            _context = context;
        }
        public async Task<GetTranslateQuestionByIdResponse> Handle(GetTranslateQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var translateQuestion = await _context.TranslateQuestions
                .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

            return new GetTranslateQuestionByIdResponse(translateQuestion);
        }
    }
}
