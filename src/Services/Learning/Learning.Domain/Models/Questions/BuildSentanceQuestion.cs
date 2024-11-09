namespace Learning.Domain.Models.Questions
{
    public class BuildSentanceQuestion : Question
    {
        public List<string> Words { get; set; } = new List<string>();
    }
}
