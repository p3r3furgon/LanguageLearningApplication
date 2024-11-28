using Learning.Domain.Models.Questions;
using Newtonsoft.Json;

namespace Learning.Domain.Models
{
    public class DomainArea
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //Relation with Chapter
        public int ChapterId { get; set; }

        [JsonIgnore]
        public Chapter Chapter { get; set; } = null!;

        //Relation with Test
        public ICollection<Test> Tests { get; set; } = new List<Test>();

        //Relation with Question
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
