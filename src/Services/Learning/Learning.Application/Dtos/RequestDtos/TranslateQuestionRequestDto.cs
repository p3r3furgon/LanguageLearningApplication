namespace Learning.Application.Dtos.RequestDtos
{
    public class TranslateQuestionRequestDto
    {
        public string Condition { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string? Explanation { get; set; }
        public string TextToTranslate { get; set; } = string.Empty;

        //Relation with Domain
        public int DomainId { get; set; }
    }
}
