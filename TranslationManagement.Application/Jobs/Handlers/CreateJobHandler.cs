using AutoMapper;
using MediatR;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Jobs.Handlers
{
    public class CreateJobHandler : IRequestHandler<CreateJob, bool>
    {
        private readonly IJobService _service;
        private readonly IMapper _mapper;

        public CreateJobHandler(IJobService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateJob request, CancellationToken cancellationToken)
        {
            var job = _mapper.Map<TranslationJob>(request);

            return await _service.CreateJob(job);
        }
    }
}
