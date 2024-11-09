﻿using Learning.DataAccess;
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
            var presignedUrl = await _minioService.PutObject("images", request.File);

            var mediaQuestion = new MediaQuestion()
            {
                Condition = request.Condition,
                Answer = request.Answer,
                MediaType = request.MediaType,
                FileOptions = new FileStorageOptions()
                {
                    Name = request.File.FileName,
                    PresignedUrl = presignedUrl,
                    ExpiriedAt = DateTime.UtcNow + TimeSpan.FromDays(7)
                },
                DomainId = request.DomainId
            };

            await _context.MediaQuestions.AddAsync(mediaQuestion);
            await _context.SaveChangesAsync();
            return new AddMediaQuestionResponse(presignedUrl, true, "");
        }
    }
}