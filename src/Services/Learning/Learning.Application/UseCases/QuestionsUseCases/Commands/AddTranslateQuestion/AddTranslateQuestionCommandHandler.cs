using AutoMapper;
using Learning.DataAccess;
using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddTranslateQuestion
{
    public class AddTranslateQuestionCommandHandler
        : IRequestHandler<AddTranslateQuestionCommand, AddTranslateQuestionResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public AddTranslateQuestionCommandHandler(IMapper mapper, LearningDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AddTranslateQuestionResponse> Handle(AddTranslateQuestionCommand request, CancellationToken cancellationToken)
        {
            var translateQuestion = _mapper.Map<TranslateQuestion>(request);

            await _context.TranslateQuestions.AddAsync(translateQuestion);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddTranslateQuestionResponse(true, "Question successfully added");
        }
    }
}
