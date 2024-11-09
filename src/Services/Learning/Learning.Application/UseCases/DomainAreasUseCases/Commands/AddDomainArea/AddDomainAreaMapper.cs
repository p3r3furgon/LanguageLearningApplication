using AutoMapper;
using Learning.Application.Dtos.RequestDtos;
using Learning.Domain.Models;

namespace Learning.Application.UseCases.DomainAreaUseCases.Commands.AddDomainArea
{
    public class AddDomainAreaMapper : Profile
    {
        public AddDomainAreaMapper()
        {
            CreateMap<AddDomainAreaCommand, DomainArea>()
                .IncludeMembers(src => src.DomainAreaDto);

            CreateMap<DomainAreaRequestDto, DomainArea>();
        }
    }
}
