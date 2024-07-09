using Moq;
using TranslationManagement.Application.Common;

namespace TranslationManagement.Application.Tests
{
    public class FileProcessorFactoryTests
    {
        [Fact]
        public void GetFileProcessor_ReturnsProcessor_WhenFileTypeIsSupported()
        {
            // Arrange
            var txtProcessorMock = new Mock<IFileProcessor>();
            txtProcessorMock.Setup(p => p.CanProcess(It.IsAny<string>())).Returns<string>(fileName => fileName.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase));

            var xmlProcessorMock = new Mock<IFileProcessor>();
            xmlProcessorMock.Setup(p => p.CanProcess(It.IsAny<string>())).Returns<string>(fileName => fileName.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase));

            var processors = new List<IFileProcessor> { txtProcessorMock.Object, xmlProcessorMock.Object };
            var factory = new FileProcessorFactory(processors);

            // Act
            var txtProcessor = factory.GetFileProcessor("file.txt");
            var xmlProcessor = factory.GetFileProcessor("file.xml");

            // Assert
            Assert.Equal(txtProcessorMock.Object, txtProcessor);
            Assert.Equal(xmlProcessorMock.Object, xmlProcessor);
        }

        [Fact]
        public void GetFileProcessor_ThrowsNotSupportedException_WhenFileTypeIsNotSupported()
        {
            // Arrange
            var txtProcessorMock = new Mock<IFileProcessor>();
            txtProcessorMock.Setup(p => p.CanProcess(It.IsAny<string>())).Returns<string>(fileName => fileName.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase));

            var processors = new List<IFileProcessor> { txtProcessorMock.Object };
            var factory = new FileProcessorFactory(processors);

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => factory.GetFileProcessor("file.xx"));
        }
    }
}