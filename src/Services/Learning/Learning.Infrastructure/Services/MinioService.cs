using Learning.Domain.Interfaces;
using Learning.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;

namespace Learning.Infrastructure.Services
{
    public class MinioService : IMinioService
    {
        private readonly IMinioClient _minioClient;
        MinioSettings _options;

        public MinioService(IOptions<MinioSettings> options)
        {
            _options = options.Value;
            _minioClient = new MinioClient()
                .WithEndpoint(_options.Host)
                .WithCredentials(_options.UserName, _options.Password)
                .Build();
        }

        public async Task<string> PutObject(string bucketName, IFormFile file)
        {
            await CreateBucketIfNotExists(bucketName);
            using (var fileStream = file.OpenReadStream())
            {
                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(bucketName)
                    .WithObject(file.FileName)
                    .WithStreamData(fileStream)
                    .WithObjectSize(fileStream.Length);
                
                await _minioClient.PutObjectAsync(putObjectArgs);
            }

            var presignedUrl = await GetPresigned(bucketName, file.FileName);
            Console.WriteLine($"Uploaded {file.FileName} to bucket {bucketName}");

            return presignedUrl;
        }

        public async Task DeleteObject(string bucketName, string fileName)
        {
            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName);

            await _minioClient.RemoveObjectAsync(removeObjectArgs);
        }

        public async Task<string> GetPresigned(string bucketName, string fileName)
        {
            var getPresignedArgs = new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithExpiry(60 * 60 * 5);

            return await _minioClient.PresignedGetObjectAsync(getPresignedArgs);
        }

        public async Task CreateBucketIfNotExists(string bucketName)
        {
            var bucketExists = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
            if (!bucketExists)
            {
                Console.WriteLine("creating");
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            }
        }
    }
}
