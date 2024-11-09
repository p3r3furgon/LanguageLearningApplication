using AutoMapper;
using Learning.Application.Dtos.RequestDtos;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddBuildSentanceQuestion;
using Learning.Domain.Models.Questions;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.AddBuildSentanceQuestion
{
    public class AddDomainAreaMapper : Profile
    {
        public AddDomainAreaMapper()
        {
            CreateMap<AddBuildSentanceQuestionCommand, BuildSentanceQuestion>()
                .IncludeMembers(src => src.BuildSentanceQuestionDto);

            CreateMap<BuildSentanceQuestionRequestDto, BuildSentanceQuestion>();
        }
    }
}
