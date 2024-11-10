namespace Learning.Application.Dtos.ResponseDtos
{
    public class DomainAreaResponseDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ChapterId { get; set; }
        public int NumberOfTests { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
