namespace CommonFiles.Messaging.CommonModels
{
    public class UserCreatedEvent
    {
        public Guid Id;
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}
