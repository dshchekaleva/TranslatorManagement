namespace TranslationManagement.Api.DTOs.Requests
{
    public record AddTranslatorRequest
    {
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; } = string.Empty;
    }
}
