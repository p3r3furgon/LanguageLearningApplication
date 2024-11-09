using Learning.Domain.Models.Questions;
using Learning.Domain.Models;

namespace Learning.Application.Dtos.RequestDtos
{
    public class DomainAreaRequestDto
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //Relation with Chapter
        public int ChapterId { get; set; }
    }
}
