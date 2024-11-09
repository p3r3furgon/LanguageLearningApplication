using Learning.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Learning.Application.Dtos.RequestDtos
{
    public class MediaQuestionRequestDto
    {
        public string Condition { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string? Explanation { get; set; }
        public MediaType MediaType { get; set; }
        public IFormFile File { get; set; } = null!;

        //Relation with Domain
        public int DomainId { get; set; }
    }
}
