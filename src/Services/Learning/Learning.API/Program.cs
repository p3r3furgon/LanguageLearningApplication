using Learning.API.Extensions;
using Learning.Application.UseCases.ChaptersUseCases.Commands.AddChapter;
using Learning.Application.UseCases.QuestionsUseCases.Commands.AddMediaQuestion;
using Learning.DataAccess;
using Learning.Domain.Enums;
using Learning.Domain.Interfaces;
using Learning.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddControllers();
builder.Services.AddDbContext<LearningDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(LearningDbContext)));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddMediaQuestionCommandHandler>());
builder.Services.AddAutoMapper(typeof(AddChapterMapper));

builder.Services.AddScoped<IMinioService, MinioService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Learning API", Version = "v1" });
    c.MapEnum<MediaType>(); 
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
