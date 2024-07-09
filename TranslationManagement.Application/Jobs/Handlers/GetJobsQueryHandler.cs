using MediatR;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Jobs.Handlers
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobs, TranslationJob[]>
    {
        private readonly IJobsRepository _repo;

        public GetJobsQueryHandler(IJobsRepository repo)
        { 
            _repo = repo;
        }

        public async Task<TranslationJob[]> Handle(GetJobs request, CancellationToken cancellationToken)
        {
            return await _repo.Get<TranslationJob>();
        }
    }
}
