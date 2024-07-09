using MediatR;

namespace TranslationManagement.Application.Translators.UseCases
{
    public class UpdateTranslatorStatus : IRequest<string>
    {

       public int Translator { get; set; }
       public string NewStatus { get; set; } = string.Empty;
    }
}
