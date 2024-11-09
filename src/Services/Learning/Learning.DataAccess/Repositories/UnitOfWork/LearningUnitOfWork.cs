using CommonFiles.Interfaces;

namespace Learning.DataAccess.Repositories.UnitOfWork
{
    public class LearningUnitOfWork : IUnitOfWork
    {
        private readonly LearningDbContext _learningDbContext;

        public LearningUnitOfWork(LearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task Save()
        {
            await _learningDbContext.SaveChangesAsync();
        }
    }
}
