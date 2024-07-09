using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace TranslationManagement.Application.Common.FileProcessors
{
    public class XmlFileProcessor : IFileProcessor
    {
        public (string content, string? customer) ProcessFile(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var xdoc = XDocument.Parse(reader.ReadToEnd());
            string content = xdoc.Root.Element("Content").Value;
            string customer = xdoc.Root.Element("Customer").Value.Trim();
            return (content, customer);
        }

        public bool CanProcess(string fileName)
        {
            return fileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase);
        }
    }
}
