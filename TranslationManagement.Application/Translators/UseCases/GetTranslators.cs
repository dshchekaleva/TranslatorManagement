using MediatR;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Translators.UseCases
{
    public class GetTranslators : IRequest<Translator[]>
    {
    }
}
