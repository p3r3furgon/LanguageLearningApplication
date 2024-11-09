using Learning.Application.Dtos.RequestDtos;
using Learning.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion
{
    public record AddMediaQuestionCommand(MediaQuestionRequestDto MediaQuestionDto)
        : IRequest<AddMediaQuestionResponse>;
    public record AddMediaQuestionResponse(string PresignedUrl, bool IsSuccess, string Message);
}
