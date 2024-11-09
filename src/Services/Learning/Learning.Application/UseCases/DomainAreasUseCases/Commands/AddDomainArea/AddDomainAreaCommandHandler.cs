using AutoMapper;
using Learning.DataAccess;
using Learning.Domain.Models;
using MediatR;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.AddDomainArea
{
    public class AddDomainAreaCommandHandler
        : IRequestHandler<AddDomainAreaCommand, AddDomainAreaResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public AddDomainAreaCommandHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddDomainAreaResponse> Handle(AddDomainAreaCommand request, CancellationToken cancellationToken)
        {
            var domainArea = _mapper.Map<DomainArea>(request);

            await _context.AddAsync(domainArea);
            await _context.SaveChangesAsync();

            return new AddDomainAreaResponse(true, "Domain area added successfully");
        }
    }
}
