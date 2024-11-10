using System.Text.Json.Serialization;

namespace Learning.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfQuestions { get; set; }
        public int AllowedMistakes { get; set; }

        //Relation with Domain
        public int DomainId { get; set; }

        [JsonIgnore]
        public DomainArea Domain { get; set; } = null!;
    }
}
