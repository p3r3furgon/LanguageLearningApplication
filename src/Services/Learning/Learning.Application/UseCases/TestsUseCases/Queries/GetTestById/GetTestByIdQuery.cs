using Learning.DataAccess;
using Learning.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learning.Application.UseCases.TestsUseCases.Queries.GetTestById
{
        public record GetTestByIdQuery(int Id)
            : IRequest<GetTestByIdResponse>;
        public record GetTestByIdResponse(Test? Test);
    
}
