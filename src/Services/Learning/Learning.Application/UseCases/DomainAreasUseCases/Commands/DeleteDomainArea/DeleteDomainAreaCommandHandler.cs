using Learning.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.DeleteDomainArea
{
    public class DeleteDomainAreaCommandHandler
        : IRequestHandler<DeleteDomainAreaCommand, DeleteDomainAreaResponse>
    {
        private readonly LearningDbContext _context;

        public DeleteDomainAreaCommandHandler(LearningDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteDomainAreaResponse> Handle(DeleteDomainAreaCommand request, CancellationToken cancellationToken)
        {
            var domainArea = await _context.Domains
                .Where(d => d.Id == request.Id)
                .FirstOrDefaultAsync();

            if (domainArea is null)
                return new DeleteDomainAreaResponse(false, "Domain area not found");

            _context.Domains.Remove(domainArea);
            await _context.SaveChangesAsync();

            return new DeleteDomainAreaResponse(true, "Domain area deleted successfully");
        }
    }
}
