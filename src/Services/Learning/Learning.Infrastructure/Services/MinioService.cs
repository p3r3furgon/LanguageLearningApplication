using Learning.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;

namespace Learning.Infrastructure.Services
{
    public class MinioService : IMinioService
    {
        private readonly IMinioClient _minioClient;

        public MinioService()
        {
            _minioClient = new MinioClient()
                .WithEndpoint("localhost:9000")
                .WithCredentials("minio", "minio123")
                .Build();
        }

        public async Task<string> PutObject(string bucketName, IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(file.FileName)
                    .WithStreamData(fileStream)
                    .WithObjectSize(fileStream.Length);
                
                await _minioClient.PutObjectAsync(putObjectArgs);
            }

            var fileName = file.FileName;
            
            var getPresignedArgs = new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithExpiry(60*60*24*7);

            var presignedUrl = await _minioClient.PresignedGetObjectAsync(getPresignedArgs);

            return presignedUrl;
        }

        public async Task DeleteObject(string bucketName, string fileName)
        {
            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName);

            await _minioClient.RemoveObjectAsync(removeObjectArgs);
        }
    }
}
