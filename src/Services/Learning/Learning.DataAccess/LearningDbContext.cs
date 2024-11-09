using Learning.Domain.Models;
using Learning.Domain.Models.Questions;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataAccess
{
    public class LearningDbContext : DbContext
    {
        public DbSet<Chapter> Chapters { get; set; } = null!;
        public DbSet<DomainArea> Domains { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<TranslateQuestion> TranslateQuestions { get; set; } = null!;
        public DbSet<MediaQuestion> MediaQuestions { get; set; } = null!;
        public DbSet<BuildSentanceQuestion> BuildSentanceQuestions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public LearningDbContext(DbContextOptions<LearningDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LearningDbContext).Assembly);
            modelBuilder.Entity<Question>().UseTpcMappingStrategy();
        }
    }
}
