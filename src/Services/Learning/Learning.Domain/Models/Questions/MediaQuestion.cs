using Learning.Domain.Enums;

namespace Learning.Domain.Models.Questions
{
    public class MediaQuestion : Question
    {
        public MediaType MediaType { get; set; }
        public FileStorageOptions FileOptions { get; set; } = null!;
    }

    public class FileStorageOptions
    {
        public string Name { get; set; } = string.Empty;
        public string PresignedUrl { get; set; } = string.Empty;
        public DateTime ExpiriedAt { get; set; }
    }

}
