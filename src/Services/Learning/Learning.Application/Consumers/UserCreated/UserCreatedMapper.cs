using AutoMapper;
using CommonFiles.Messaging.CommonModels;
using Learning.Domain.Models;

namespace Learning.Application.Consumers.UserCreated
{
    public class UserCreatedMapper : Profile
    {
        public UserCreatedMapper()
        {
            CreateMap<UserCreatedEvent, User>();
        }
    }
}
