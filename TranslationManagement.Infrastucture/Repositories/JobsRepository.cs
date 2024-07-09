using TranslationManagement.Application.Jobs;

namespace TranslationManagement.Infrastructure.Repositories
{
    public class JobsRepository : BaseRepository, IJobsRepository
    {
        public JobsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
