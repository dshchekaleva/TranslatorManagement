using Microsoft.AspNetCore.Http;

namespace TranslationManagement.Application.Common
{
    public interface IFileProcessor
    {
        (string content, string? customer) ProcessFile(IFormFile file);
        bool CanProcess(string fileName);
    }
}
