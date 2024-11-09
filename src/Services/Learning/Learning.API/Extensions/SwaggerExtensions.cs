using Learning.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Learning.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void MapEnum<TEnum>(this SwaggerGenOptions options) where TEnum : Enum
        {
            options.MapType<TEnum>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = Enum.GetNames(typeof(TEnum))
                            .Select(name => (IOpenApiAny)new OpenApiString(name))
                            .ToList()
            });
        }
    }
}
