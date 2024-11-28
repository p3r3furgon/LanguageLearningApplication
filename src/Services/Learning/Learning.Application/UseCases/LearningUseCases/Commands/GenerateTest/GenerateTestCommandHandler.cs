using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using MassTransit.Initializers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.LearningUseCases.Commands.GenerateTest
{
    public class GenerateTestCommandHandler
        : IRequestHandler<GenerateTestCommand, GenerateTestResponse>
    {
        private readonly LearningDbContext _context;
        private readonly Random _random;

        public GenerateTestCommandHandler(LearningDbContext context, Random random)
        {
            _context = context;
            _random = random;
        }

        public async Task<GenerateTestResponse> Handle(GenerateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _context.Tests.FirstOrDefaultAsync(t => t.Id == request.TestId);

            if (test is null)
            {
                throw new Exception("Test not found");
            }

            var questions = await _context.Domains
                .Include(d => d.Questions)
                .FirstOrDefaultAsync(d => d.Id == test.DomainId)
                .Select(d => d.Questions);

            var questionsList = questions
                .OrderBy(_ => _random.Next())
                .Take(test.NumberOfQuestions)
                .Select(t => new RandomQuestionResponseDto { QuestionType = t.GetType().Name, Question = t})
                .ToList();
                
      
            return new GenerateTestResponse(questionsList);
        }
    }
}
