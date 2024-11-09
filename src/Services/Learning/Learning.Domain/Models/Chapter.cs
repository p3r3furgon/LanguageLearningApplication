namespace Learning.Domain.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        //Relation with Domain
        public ICollection<DomainArea> Domains { get; set; } = new List<DomainArea>();
    }
}
