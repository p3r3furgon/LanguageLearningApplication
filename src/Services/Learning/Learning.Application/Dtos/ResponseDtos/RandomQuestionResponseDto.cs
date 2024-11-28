using Learning.Domain.Models.Questions;

namespace Learning.Application.Dtos.ResponseDtos
{
    public class RandomQuestionResponseDto
    {
        public string QuestionType { get; set; } = string.Empty;
        public Question Question { get; set; } = null!;
    }
}
