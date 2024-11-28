namespace Learning.Domain.Models.Questions
{
    public class BuildSentanceQuestion : Question
    {
        public string TextToTranslate { get; set; } = string.Empty;
        public List<string> Words { get; set; } = new List<string>();
    }
}
