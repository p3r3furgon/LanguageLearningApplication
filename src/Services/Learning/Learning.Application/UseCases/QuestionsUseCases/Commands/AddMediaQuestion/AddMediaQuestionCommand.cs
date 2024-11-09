using Learning.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion
{
    public record AddMediaQuestionCommand(string Condition, string Answer, MediaType MediaType, IFormFile File, int DomainId)
        : IRequest<AddMediaQuestionResponse>;
    public record AddMediaQuestionResponse(string PresignedUrl, bool IsSuccess, string Message);
}
