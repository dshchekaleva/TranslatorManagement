using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationManagement.Application.Translators.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Translators.Handlers
{
    public class GetTranslatorsByNameHandler : IRequestHandler<GetTranslatorsByName, Translator[]>
    {
        private readonly ITranslatorsRepository _repo;

        public GetTranslatorsByNameHandler(ITranslatorsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Translator[]> Handle(GetTranslatorsByName request, CancellationToken cancellationToken)
        {
            return await _repo.Get<Translator>(x => x.Name == request.Name);
        }
    }
}
