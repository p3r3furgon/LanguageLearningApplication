using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.TestsUseCases.Commands.DeleteTest
{
    public class DeleteTestCommandHandler
        : IRequestHandler<DeleteTestCommand, DeleteTestResponse>
    {
        private readonly LearningDbContext _context;

        public DeleteTestCommandHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTestResponse> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _context.Tests
                .Where(t => t.Id == request.Id)
                .FirstOrDefaultAsync();

            if (test is null)
                return new DeleteTestResponse(false, "Test not found");

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return new DeleteTestResponse(true, "Test deleted successfully");
        }
    }
}
