using Contracts.Abstract;
using Moq;
using RestfulService.Controllers;
using Xunit;

namespace UnitTests
{
    public class MessageControllerTests
    {
        public MessageControllerTests()
        {
            _mockReader = new Mock<IStoreReader>();
            _mockWriter = new Mock<IStoreWriter>();
        }

        private readonly Mock<IStoreReader> _mockReader;
        private readonly Mock<IStoreWriter> _mockWriter;

        private MessageController CreateController()
        {
            return new MessageController(_mockReader.Object, _mockWriter.Object);
        }

        [Fact]
        public void GetReturnsHelloWorldMessage()
        {
            // Arrange
            var controller = CreateController();
            var expected = "Hello World";
            _mockReader.Setup(reader => reader.Read()).Returns(expected);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PostSavesMessageInWriter()
        {
            var controller = CreateController();
            controller.Post("Test");

            _mockWriter.Verify(x => x.Write(It.IsAny<string>()), Times.Once());
        }
    }
}