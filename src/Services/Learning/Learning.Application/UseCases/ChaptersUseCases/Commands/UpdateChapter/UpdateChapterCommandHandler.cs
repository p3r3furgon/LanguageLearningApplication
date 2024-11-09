using AutoMapper;
using Learning.DataAccess;
using Learning.Domain.Models;
using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.UpdateChapter
{
    public class UpdateChapterCommandHandler
        : IRequestHandler<UpdateChapterCommand, UpdateChapterResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public UpdateChapterCommandHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateChapterResponse> Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = _context.Chapters
                .Where(c => c.Id == request.Id)
                .FirstOrDefault();

            if(chapter is null)
                return new UpdateChapterResponse(false, "chapter not found");

            chapter = _mapper.Map(request, chapter);

            _context.Update(chapter);
            await _context.SaveChangesAsync();

            return new UpdateChapterResponse(true, "");
        }
    }
}
