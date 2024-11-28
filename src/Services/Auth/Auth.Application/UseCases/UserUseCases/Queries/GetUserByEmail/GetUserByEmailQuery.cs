using FluentValidation;
using MediatR;
using Auth.Domain.Models;

namespace Auth.Application.UseCases.UserUseCases.Queries.GetUserByEmail
{
    public record GetUserByEmailQuery(string Email): IRequest<GetUserByEmailResponse>;
    public record GetUserByEmailResponse(User User);

    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(request => request.Email).NotEmpty().EmailAddress().WithMessage("Email signature is wrong");
        }
    }

}
