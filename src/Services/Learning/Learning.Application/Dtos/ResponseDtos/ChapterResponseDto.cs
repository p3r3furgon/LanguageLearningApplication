using Learning.Domain.Models;

namespace Learning.Application.Dtos.ResponseDtos
{
    public class ChapterResponseDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int NumberOfDomainAreas { get; set; }
    }
}
