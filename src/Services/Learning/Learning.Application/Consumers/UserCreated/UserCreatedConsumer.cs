using AutoMapper;
using CommonFiles.Messaging.CommonModels;
using Learning.DataAccess;
using Learning.Domain.Models;
using MassTransit;

namespace Learning.Application.Consumers.UserCreated
{
    public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
    {
        private readonly LearningDbContext _context;
        private readonly IMapper _mapper;
        public UserCreatedConsumer(LearningDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var user = _mapper.Map<User>(context.Message);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
