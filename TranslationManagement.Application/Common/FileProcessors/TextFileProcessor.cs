using Microsoft.AspNetCore.Http;

namespace TranslationManagement.Application.Common.FileProcessors
{
    public class TextFileProcessor : IFileProcessor
    {
        public (string content, string? customer) ProcessFile(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            string content = reader.ReadToEnd();
            return (content, null);
        }

        public bool CanProcess(string fileName)
        {
            return fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase);
        }
    }
}
