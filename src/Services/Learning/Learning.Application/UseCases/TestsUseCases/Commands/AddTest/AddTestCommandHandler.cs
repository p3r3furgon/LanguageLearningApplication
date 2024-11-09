using AutoMapper;
using Learning.DataAccess;
using Learning.Domain.Models;
using MediatR;

namespace Learning.Application.UseCases.TestsUseCases.Commands.AddTest
{
    public class AddTestCommandHandler
        : IRequestHandler<AddTestCommand, AddTestResponse>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;

        public AddTestCommandHandler(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddTestResponse> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            var test = _mapper.Map<Test>(request);

            await _context.AddAsync(test);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddTestResponse(true, "Test added successfully");
        }
    }
}
