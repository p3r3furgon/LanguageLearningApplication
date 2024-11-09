using Learning.Domain.Enums;

namespace Learning.Domain.Models.Questions
{
    public class MediaQuestion : Question
    {
        public MediaType MediaType { get; set; }
        public string MediaFileName { get; set; } = string.Empty;
    }
}
