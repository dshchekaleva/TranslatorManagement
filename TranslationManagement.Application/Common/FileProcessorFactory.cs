namespace TranslationManagement.Application.Common
{
    public class FileProcessorFactory
    {
        private readonly IEnumerable<IFileProcessor> _fileProcessors;

        public FileProcessorFactory(IEnumerable<IFileProcessor> fileProcessors)
        {
            _fileProcessors = fileProcessors;
        }

        public IFileProcessor GetFileProcessor(string fileName)
        {
            var processor = _fileProcessors.FirstOrDefault(p => p.CanProcess(fileName));
            return processor ?? throw new NotSupportedException($"File type {fileName} is not supported");
        }
    }
}
