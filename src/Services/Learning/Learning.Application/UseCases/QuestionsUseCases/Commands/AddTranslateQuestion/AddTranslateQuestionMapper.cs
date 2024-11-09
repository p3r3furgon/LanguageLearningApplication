using AutoMapper;
using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddTranslateQuestion;
using Learning.Domain.Models.Questions;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.AddTranslateQuestion
{
    public class AddTranslateQuestionMapper : Profile
    {
        public AddTranslateQuestionMapper()
        {
            CreateMap<AddTranslateQuestionCommand, TranslateQuestion>()
                .IncludeMembers(src => src.TranslateQuestionDto);

            CreateMap<TranslateQuestionRequestDto, TranslateQuestion>();
        }
    }
}
