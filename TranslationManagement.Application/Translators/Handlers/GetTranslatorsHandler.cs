using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Application.Translators.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Translators.Handlers
{
    public class GetTranslatorsHandler : IRequestHandler<GetTranslators, Translator[]>
    {
        private readonly ITranslatorsRepository _repo;

        public GetTranslatorsHandler(ITranslatorsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Translator[]> Handle(GetTranslators request, CancellationToken cancellationToken)
        {
            return await _repo.Get<Translator>();
        }
    }
}
