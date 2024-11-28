using Newtonsoft.Json;

namespace Learning.Domain.Models.Questions
{
    public abstract class Question
    {
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string? Explanation { get; set; }

        //Relation with Domain
        public int DomainId { get; set; }

        [JsonIgnore]
        public DomainArea Domain { get; set; } = null!;
    }
}
