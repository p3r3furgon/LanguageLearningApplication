using Learning.Application.Dtos.ResponseDtos;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetMediaQuestionById
{
    public record GetMediaQuestionByIdQuery(int Id)
        : IRequest<GetMediaQuestionByIdResponse>;
    
    public record GetMediaQuestionByIdResponse(MediaQuestionResponseDto MediaQuestionDto);
}
