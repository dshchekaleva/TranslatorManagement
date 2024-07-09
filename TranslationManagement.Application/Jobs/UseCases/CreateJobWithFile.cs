using MediatR;
using Microsoft.AspNetCore.Http;

namespace TranslationManagement.Application.Jobs.UseCases
{
    public class CreateJobWithFile : IRequest<bool>
    {
        public string Customer { get; set; } = string.Empty;
        public IFormFile File { get; set; }
    }
}
