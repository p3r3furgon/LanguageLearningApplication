using Learning.Domain.Models.Questions;
using MediatR;

namespace Learning.Application.UseCases.QuestionsUseCases.Queries.GetTranslateQuestionById
{
    public record GetTranslateQuestionByIdQuery(int Id)
        : IRequest<GetTranslateQuestionByIdResponse>;

    public record GetTranslateQuestionByIdResponse(TranslateQuestion? TranslateQuestion);
}
