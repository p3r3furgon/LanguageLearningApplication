using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteTranslateQuestion
{
    public class DeleteTranslateQuestionCommandHandler
        : IRequestHandler<DeleteTranslateQuestionCommand, DeleteTranslateQuestionResponse>
    {
        private readonly LearningDbContext _context;

        public DeleteTranslateQuestionCommandHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTranslateQuestionResponse> Handle(DeleteTranslateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.TranslateQuestions
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync();

            if (question is null)
                return new DeleteTranslateQuestionResponse(false, "Question not found");

            _context.TranslateQuestions.Remove(question);
            await _context.SaveChangesAsync();

            return new DeleteTranslateQuestionResponse(true, "Question deleted successfully");
        }
    }
}
