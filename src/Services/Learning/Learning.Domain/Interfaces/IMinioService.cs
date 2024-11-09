﻿using Microsoft.AspNetCore.Http;

namespace Learning.Domain.Interfaces
{
    public interface IMinioService
    {
        Task<string> PutObject(string bucketName, IFormFile file);
        Task DeleteObject(string bucketName, string fileName);
    }
}