using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestions;
using Learning.DataAccess;
using Learning.Domain.Enums;
using Learning.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestionById
{
    public class GetMediaQuestionByIdQueryHandler
        : IRequestHandler<GetMediaQuestionByIdQuery, GetMediaQuestionByIdResponse>
    {
        public LearningDbContext _context;
        public IMinioService _minioService;
        public IMapper _mapper;

        public GetMediaQuestionByIdQueryHandler(LearningDbContext context, IMinioService minioService, IMapper mapper)
        {
            _context = context;
            _minioService = minioService;
            _mapper = mapper;
        }

        public async Task<GetMediaQuestionByIdResponse> Handle(GetMediaQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            var mediaQuestion = await _context.MediaQuestions
                .FirstOrDefaultAsync(q => q.Id == request.Id,cancellationToken);

            var mediaQuestionDto = _mapper.Map<MediaQuestionResponseDto>(mediaQuestion);

            switch (mediaQuestionDto.MediaType)
            {
                case MediaType.Image:
                    mediaQuestionDto.PresignedUrl =
                        await _minioService.GetPresigned("images", mediaQuestionDto.MediaFileName);
                    break;
                case MediaType.Audio:
                    mediaQuestionDto.PresignedUrl =
                        await _minioService.GetPresigned("audios", mediaQuestionDto.MediaFileName);
                    break;

            }
            
            return new GetMediaQuestionByIdResponse(mediaQuestionDto);
        }
    }
}
