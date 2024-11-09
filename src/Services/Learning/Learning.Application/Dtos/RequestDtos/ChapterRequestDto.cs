namespace Learning.Application.Dtos.RequestDtos
{
    public class ChapterRequestDto
    {
        public int SerialNumber { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
