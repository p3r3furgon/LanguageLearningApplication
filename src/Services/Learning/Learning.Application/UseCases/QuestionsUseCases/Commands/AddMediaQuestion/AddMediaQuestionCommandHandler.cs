using Learning.DataAccess;
using Learning.Domain.Interfaces;
using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion
{
    public class AddMediaQuestionCommandHandler
        : IRequestHandler<AddMediaQuestionCommand, AddMediaQuestionResponse>
    {
        private readonly IMinioService _minioService;
        private readonly LearningDbContext _context;
        public AddMediaQuestionCommandHandler(IMinioService minioService, LearningDbContext context)
        {
            _minioService = minioService;
            _context = context;
        }

        public async Task<AddMediaQuestionResponse> Handle(AddMediaQuestionCommand request, CancellationToken cancellationToken)
        {
            var mediaQuestion = new MediaQuestion()
            {
                Condition = request.MediaQuestionDto.Condition,
                Answer = request.MediaQuestionDto.Answer,
                MediaType = request.MediaQuestionDto.MediaType,
                MediaFileName = request.MediaQuestionDto.File.FileName,
                DomainId = request.MediaQuestionDto.DomainId
            };

            var presignedUrl = await _minioService.PutObject("images", request.MediaQuestionDto.File);
            await _context.MediaQuestions.AddAsync(mediaQuestion);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddMediaQuestionResponse(presignedUrl, true, "");
        }
    }
}
