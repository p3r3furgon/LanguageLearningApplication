using AutoMapper;
using Learning.DataAccess;
using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddBuildSentanceQuestion
{
    public class AddBuildSentanceQuestionCommandHandler
        : IRequestHandler<AddBuildSentanceQuestionCommand, AddBuildSentanceQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly LearningDbContext _context;
        public AddBuildSentanceQuestionCommandHandler(IMapper mapper, LearningDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AddBuildSentanceQuestionResponse> Handle(AddBuildSentanceQuestionCommand request, CancellationToken cancellationToken)
        {
            var buildSentanceQuestion = _mapper.Map<BuildSentanceQuestion>(request);

            await _context.BuildSentanceQuestions.AddAsync(buildSentanceQuestion);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddBuildSentanceQuestionResponse(true, "Question added successfully");
        }
    }
}
