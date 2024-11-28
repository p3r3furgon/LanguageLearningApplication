using AutoMapper;
using CommonFiles.Interfaces;
using MediatR;
using Auth.Application.Exceptions;
using Auth.Domain.Interfaces.Authentification;
using Auth.Domain.Interfaces.Repositories;
using Auth.Domain.Models;
using CommonFiles.Messaging.CommonModels;
using MassTransit;

namespace Auth.Application.UseCases.AuthUseCases.Commands.UserRegister
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserRegisterResponse>
    {
        
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserRegisterCommandHandler(IUsersRepository usersRepository, IPasswordHasher passwordHasher,
            IMapper mapper, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<UserRegisterResponse> Handle(UserRegisterCommand request, 
            CancellationToken cancellationToken)
        {
            UserRegisterCommandValidator validator = new();
            var results = validator.Validate(request);
            if (!results.IsValid)
            {
                throw new BadRequestException(results.Errors);
            }

            var user = await _usersRepository.GetByEmail(request.UserDto.Email);
            if (user != null)
                throw new BadRequestException("User with such email already exist");

            user = _mapper.Map<User>(request);
            user.PasswordHash = _passwordHasher.Generate(request.UserDto.Password);

            await _usersRepository.Create(user);
            await _unitOfWork.Save(cancellationToken);

            await ProduceUserCreatedMessage(user);

            return new UserRegisterResponse(user.Id);
        }

        public async Task ProduceUserCreatedMessage(User user)
        {
            var userCreated = _mapper.Map<UserCreatedEvent>(user);

            await _publishEndpoint.Publish(userCreated, cfg => cfg.SetRoutingKey("user_created"));
        }
    }
}
