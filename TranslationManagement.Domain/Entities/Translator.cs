using TranslationManagement.Domain.Enums;

namespace TranslationManagement.Domain.Entities
{
    public class Translator : IId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HourlyRate { get; set; } = string.Empty;
        public TranslatorStatuses Status { get; set; }
        public string CreditCardNumber { get; set; } = string.Empty;
    }
}
