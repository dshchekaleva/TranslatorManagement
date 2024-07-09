using MediatR;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Translators.UseCases
{
    public class GetTranslatorsByName : IRequest<Translator[]>
    {
        public string Name { get; set; } = string.Empty;
    }
}
