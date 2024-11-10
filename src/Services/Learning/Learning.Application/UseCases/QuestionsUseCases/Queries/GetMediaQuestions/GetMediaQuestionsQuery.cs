using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestions
{
    public record GetMediaQuestionsQuery : IRequest<GetMediaQuestionsResponse>;

    public record GetMediaQuestionsResponse(List<MediaQuestionResponseDto> MediaQuestionsDto);
}
