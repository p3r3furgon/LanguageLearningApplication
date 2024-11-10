using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.DataAccess;
using Learning.Domain.Enums;
using Learning.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestions
{
    public class GetMediaQuestionsQueryHandler
        : IRequestHandler<GetMediaQuestionsQuery, GetMediaQuestionsResponse>
    {
        public LearningDbContext _context;
        public IMinioService _minioService;
        public IMapper _mapper;

        public GetMediaQuestionsQueryHandler(LearningDbContext context, IMinioService minioService, IMapper mapper)
        {
            _context = context;
            _minioService = minioService;
            _mapper = mapper;
        }

        public async Task<GetMediaQuestionsResponse> Handle(GetMediaQuestionsQuery request, CancellationToken cancellationToken)
        {
            var mediaQuestions = await _context.MediaQuestions.ToListAsync(cancellationToken);

            var mediaQuestionsDto = _mapper.Map<List<MediaQuestionResponseDto>>(mediaQuestions);

            foreach(var questionDto in mediaQuestionsDto)
            {
                switch(questionDto.MediaType)
                {
                    case MediaType.Image:
                        questionDto.PresignedUrl =
                            await _minioService.GetPresigned("images", questionDto.MediaFileName);
                        break;
                    case MediaType.Audio:
                        questionDto.PresignedUrl =
                            await _minioService.GetPresigned("audios", questionDto.MediaFileName);
                        break;

                }
            }
            return new GetMediaQuestionsResponse(mediaQuestionsDto);
        }
    }
}
