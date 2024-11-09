namespace Learning.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
    }
}
