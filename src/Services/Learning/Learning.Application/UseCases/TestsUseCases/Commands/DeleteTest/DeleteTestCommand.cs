using MediatR;

namespace Learning.Application.UseCases.TestsUseCases.Commands.DeleteTest
{
    public record DeleteTestCommand(int Id) : IRequest<DeleteTestResponse>;

    public record DeleteTestResponse(bool IsSuccess, string Message);
}
