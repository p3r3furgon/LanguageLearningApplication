using Learning.Domain.Enums;

namespace Learning.Application.Dtos.ResponseDtos
{
    public class MediaQuestionResponseDto
    {
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string? Explanation { get; set; }
        public MediaType MediaType { get; set; } 
        public string PresignedUrl { get; set; } = string.Empty;
        public string MediaFileName { get; set; } = string.Empty;

        //Relation with Domain
        public int DomainId { get; set; }
    }
}
