using External.ThirdParty.Services;
using Microsoft.Extensions.Logging;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Enums;

namespace TranslationManagement.Application.Jobs
{
    public interface IJobService
    {
        Task<bool> CreateJob(TranslationJob job);
    }
    public class JobService : IJobService
    {
        private IJobsRepository _repo;
        private readonly ILogger<JobService> _logger;

        public JobService(IJobsRepository repo, ILogger<JobService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> CreateJob(TranslationJob job)
        {
            job.Status = JobStatuses.New;
            job.SetPrice();
            bool success = await _repo.Add(job);
            if (success)
            {
                var notificationSvc = new UnreliableNotificationService();
                while (!notificationSvc.SendNotification("Job created: " + job.Id).Result)
                {
                }

                _logger.LogInformation("New job notification sent");
            }

            return success;
        }
    }
}
