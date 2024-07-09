using MediatR;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Jobs.UseCases
{
    public class GetJobs : IRequest<TranslationJob[]>
    {
    }
}
