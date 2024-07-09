using MediatR;

namespace TranslationManagement.Application.Jobs.UseCases
{
    public class UpdateJobStatus : IRequest<string>
    {
        public int JobId { get; set; }
        public int TranslatorId { get; set; }
        public string NewStatus { get; set; } = string.Empty;
    }
}
