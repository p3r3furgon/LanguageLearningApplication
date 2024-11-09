using AutoMapper;
using Learning.DataAccess;
using Learning.Domain.Models;
using MediatR;

namespace Learning.Application.UseCases.ChaptersUseCases.Commands.AddChapter
{
    public class AddChapterCommandHandler
        : IRequestHandler<AddChapterCommand, AddChapterResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public AddChapterCommandHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AddChapterResponse> Handle(AddChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = _mapper.Map<Chapter>(request);

            await _context.AddAsync(chapter);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddChapterResponse(true, "Chapter added successfully");
        }
    }
}
