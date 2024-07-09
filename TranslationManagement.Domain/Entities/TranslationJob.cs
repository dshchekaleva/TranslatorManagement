using TranslationManagement.Domain.Enums;

namespace TranslationManagement.Domain.Entities
{
    public class TranslationJob : IId<int>
    {
        const double PricePerCharacter = 0.01;
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public JobStatuses Status { get; set; }
        public string OriginalContent { get; set; } = string.Empty;
        public string TranslatedContent { get; set; } = string.Empty;
        public double Price { get; set; }

        public void SetPrice()
        {
            Price = OriginalContent.Length * PricePerCharacter;
        }
    }
}
