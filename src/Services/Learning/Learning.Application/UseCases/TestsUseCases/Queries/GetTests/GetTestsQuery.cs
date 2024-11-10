
using Learning.Domain.Models;
using MediatR;

namespace Learning.Application.UseCases.TestsUseCases.Queries.GetTests
{
    public record GetTestsQuery : IRequest<GetTestsResponse>;

    public record GetTestsResponse(List<Test> TestsDto);
}
