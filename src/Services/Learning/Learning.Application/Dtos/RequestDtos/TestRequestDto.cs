namespace Learning.Application.Dtos.RequestDtos
{
    public class TestRequestDto
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfQuestions { get; set; }
        public int AllowedMistakes { get; set; }

        //Relation with Domain
        public int DomainId { get; set; }
    }
}
