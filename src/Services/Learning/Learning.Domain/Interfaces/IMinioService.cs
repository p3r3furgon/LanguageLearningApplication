using Microsoft.AspNetCore.Http;

namespace Learning.Domain.Interfaces
{
    public interface IMinioService
    {
        Task<string> PutObject(string bucketName, IFormFile file);
        Task DeleteObject(string bucketName, string fileName);
        Task<string> GetPresigned(string bucketName, string fileName);
        Task CreateBucketIfNotExists(string bucketName);
    }
}
