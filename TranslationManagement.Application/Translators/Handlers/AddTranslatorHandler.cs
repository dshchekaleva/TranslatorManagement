using AutoMapper;
using MediatR;
using TranslationManagement.Application.Translators.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Translators.Handlers
{
    public class AddTranslatorHandler : IRequestHandler<AddTranslator, bool>
    {
        private readonly ITranslatorsRepository _repo;
        private readonly IMapper _mapper;

        public AddTranslatorHandler(ITranslatorsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddTranslator request, CancellationToken cancellationToken)
        {
            var translator = _mapper.Map<Translator>(request);
            return await _repo.Add(translator);
        }
    }
}
