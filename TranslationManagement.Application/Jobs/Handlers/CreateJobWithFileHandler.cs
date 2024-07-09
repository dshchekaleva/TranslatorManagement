using MediatR;
using TranslationManagement.Application.Common;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Domain.Entities;

namespace TranslationManagement.Application.Jobs.Handlers
{
    public class CreateJobWithFileHandler : IRequestHandler<CreateJobWithFile, bool>
    {
        private readonly IJobService _service;
        private readonly FileProcessorFactory _fileProcessorFactory;

        public CreateJobWithFileHandler(IJobService service, FileProcessorFactory fileProcessorFactory)
        {
            _service = service;
            _fileProcessorFactory = fileProcessorFactory;
        }

        public async Task<bool> Handle(CreateJobWithFile request, CancellationToken cancellationToken)
        {
            var processor = _fileProcessorFactory.GetFileProcessor(request.File.FileName);
            var (content, processedCustomer) = processor.ProcessFile(request.File);
            var customer = processedCustomer ?? request.Customer;

            var job = new TranslationJob()
            {
                OriginalContent = content,
                TranslatedContent = "",
                CustomerName = customer,
            };

            return await _service.CreateJob(job);
        }
    }
}
