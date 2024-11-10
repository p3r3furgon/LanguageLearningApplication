using AutoMapper;
using Learning.Application.Dtos.ResponseDtos;
using Learning.Domain.Models.Questions;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestions
{
    public class GetMediaQuestionsMapper : Profile
    {
        public GetMediaQuestionsMapper()
        {
            CreateMap<MediaQuestion, MediaQuestionResponseDto>();
                
        }
    }
}
