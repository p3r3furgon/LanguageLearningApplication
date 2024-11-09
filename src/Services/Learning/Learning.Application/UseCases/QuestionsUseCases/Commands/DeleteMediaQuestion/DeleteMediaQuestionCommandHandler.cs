using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteMediaQuestion
{
    public class DeleteMediaQuestionCommandHandler
        : IRequestHandler<DeleteMediaQuestionCommand, DeleteMediaQuestionResponse>
    {
        private readonly LearningDbContext _context;

        public DeleteMediaQuestionCommandHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteMediaQuestionResponse> Handle(DeleteMediaQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.MediaQuestions
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync();

            if (question is null)
                return new DeleteMediaQuestionResponse(false, "Question not found");

            _context.MediaQuestions.Remove(question);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteMediaQuestionResponse(true, "Question deleted successfully");
        }
    }
}
