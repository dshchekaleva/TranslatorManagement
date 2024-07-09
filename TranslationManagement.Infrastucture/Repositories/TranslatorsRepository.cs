using TranslationManagement.Application.Jobs;
using TranslationManagement.Application.Translators;

namespace TranslationManagement.Infrastructure.Repositories
{
    public class TranslatorsRepository : BaseRepository, ITranslatorsRepository
    {
        public TranslatorsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
