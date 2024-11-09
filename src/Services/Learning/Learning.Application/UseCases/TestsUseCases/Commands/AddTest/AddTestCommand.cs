using Learning.Application.Dtos.RequestDtos;
using MediatR;

namespace Learning.Application.UseCases.TestsUseCases.Commands.AddTest
{
    public record AddTestCommand(TestRequestDto TestDto)
        : IRequest<AddTestResponse>;

    public record AddTestResponse(bool IsSuccess, string Message);
}
