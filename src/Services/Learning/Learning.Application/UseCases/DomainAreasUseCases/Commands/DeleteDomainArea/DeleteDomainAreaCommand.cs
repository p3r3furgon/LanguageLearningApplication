using MediatR;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.DeleteDomainArea
{
    public record DeleteDomainAreaCommand(int Id) : IRequest<DeleteDomainAreaResponse>;
    public record DeleteDomainAreaResponse(bool IsSuccess, string Message);
}
