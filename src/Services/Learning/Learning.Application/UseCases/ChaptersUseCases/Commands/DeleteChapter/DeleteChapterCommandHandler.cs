using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.DeleteChapter
{
    public class DeleteChapterCommandHandler
        : IRequestHandler<DeleteChapterCommand, DeleteChapterResponse>
    {
        private readonly LearningDbContext _context;

        public DeleteChapterCommandHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteChapterResponse> Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = _context.Chapters
               .Where(c => c.Id == request.Id)
               .FirstOrDefault();

            if (chapter is null)
                return new DeleteChapterResponse(false, "chapter not found");

            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteChapterResponse(true, "Chapter deleted successfully");
        }
    }
}
