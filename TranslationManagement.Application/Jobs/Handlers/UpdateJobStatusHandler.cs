using MediatR;
using Microsoft.Extensions.Logging;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Enums;

namespace TranslationManagement.Application.Jobs.Handlers
{
    public class UpdateJobStatusHandler : IRequestHandler<UpdateJobStatus, string>
    {
        private IJobsRepository _repo;
        private readonly ILogger<UpdateJobStatusHandler> _logger;

        public UpdateJobStatusHandler(IJobsRepository repo, ILogger<UpdateJobStatusHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<string> Handle(UpdateJobStatus request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Job status update request received: " + request.NewStatus + " for job " + request.JobId.ToString() + " by translator " + request.TranslatorId);
            if (!Enum.TryParse(request.NewStatus, out JobStatuses status))
            {
                return "invalid status";
            }
            var job = await _repo.GetById<TranslationJob>(request.JobId);

            bool isInvalidStatusChange = (job.Status == JobStatuses.New && status == JobStatuses.Completed) ||
                                         job.Status == JobStatuses.Completed || status == JobStatuses.New;
            if (isInvalidStatusChange)
            {
                return "invalid status change";
            }

            job.Status = status;
            await _repo.Update(job);

            return "updated";
        }
    }
}
