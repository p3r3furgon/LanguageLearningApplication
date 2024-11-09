using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.DeleteBuildSentanceQuestion
{
    public class DeleteMediaQuestionCommandHandler 
        : IRequestHandler<DeleteBuildSentanceQuestionCommand, DeleteBuildSentanceQuestionResponse>
    {
        private readonly LearningDbContext _context;

        public DeleteMediaQuestionCommandHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteBuildSentanceQuestionResponse> Handle(DeleteBuildSentanceQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.BuildSentanceQuestions
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync();

            if (question is null)
                return new DeleteBuildSentanceQuestionResponse(false, "Question not found");

            _context.BuildSentanceQuestions.Remove(question);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteBuildSentanceQuestionResponse(true, "Question deleted successfully");
        }
    }
}
