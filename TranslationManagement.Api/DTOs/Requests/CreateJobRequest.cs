namespace TranslationManagement.Api.DTOs.Requests
{
    public record CreateJobRequest
    {
        public string CustomerName { get; set; }
        public string OriginalContent { get; set; }
    }
}
