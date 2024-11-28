
using Learning.Domain.Models;
using MediatR;

namespace Learning.Application.UseCases.TestsUseCases.Queries.GetTestsByDomainAreaId
{
    public record GetTestsByDomainAreaIdQuery(int DomainAreaId) : IRequest<GetTestsByDomainAreaIdQueryResponse>;

    public record GetTestsByDomainAreaIdQueryResponse(List<Test> TestsDto);
}
