using MediatR;
using Auth.Application.Exceptions;
using Auth.Application.UseCases.UserUseCases.Queries.GetUserById;
using Auth.Domain.Interfaces.Repositories;

namespace Auth.Application.UseCases.UserUseCases.Queries.GetUser
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserByIdQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetById(request.Id);
            if (user == null)
                throw new UserNotFoundException(request.Id);
            return new GetUserByIdResponse(user);
        }
    }
}

