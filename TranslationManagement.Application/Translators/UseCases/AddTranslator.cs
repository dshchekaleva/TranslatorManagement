using MediatR;

namespace TranslationManagement.Application.Translators.UseCases
{
    public class AddTranslator : IRequest<bool>
    {
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; } = string.Empty;
    }
}
