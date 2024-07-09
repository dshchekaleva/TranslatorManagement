using MediatR;

namespace TranslationManagement.Application.Jobs.UseCases
{
    public class CreateJob : IRequest<bool>
    {
        public string CustomerName { get; set; } = string.Empty;
        public string OriginalContent { get; set; } = string.Empty;
    }
}
