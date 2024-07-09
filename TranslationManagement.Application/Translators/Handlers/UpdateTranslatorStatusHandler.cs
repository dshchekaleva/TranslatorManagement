using MediatR;
using Microsoft.Extensions.Logging;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Domain.Enums;
using TranslationManagement.Application.Translators.UseCases;

namespace TranslationManagement.Application.Translators.Handlers
{
    public class UpdateTranslatorStatusHandler : IRequestHandler<UpdateTranslatorStatus, string>
    {
        private ITranslatorsRepository _repo;
        private readonly ILogger<UpdateTranslatorStatusHandler> _logger;

        public UpdateTranslatorStatusHandler(ITranslatorsRepository repo, ILogger<UpdateTranslatorStatusHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<string> Handle(UpdateTranslatorStatus request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("User status update request: " + request.NewStatus + " for user " + request.Translator.ToString());
            if (!Enum.TryParse(request.NewStatus, out TranslatorStatuses status))
            {
                throw new ArgumentException("unknown status");
            }

            var translator = await _repo.GetById<Translator>(request.Translator);
            translator.Status = status;
            await _repo.Update(translator);

            return "updated";
        }
    }
}
