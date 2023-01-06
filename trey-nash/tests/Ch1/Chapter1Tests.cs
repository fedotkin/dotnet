using Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.ChapterExercises.Tests.Ch1;

public class Chapter1Tests
{
    private readonly Mock<IConsoleService> consoleServiceMock;
    private readonly Mock<ITextCompression> textCompressionMock;

    public Chapter1Tests()
    {
        consoleServiceMock = new Mock<IConsoleService>();
        textCompressionMock = new Mock<ITextCompression>();
    }

    [Fact]
    public void Run_WrongTaskNumber_PrintsSorryString()
    {
        // Arrange
        string taskNo = "7"; // Non-existing, not implemented task number
        List<string> consoleLog = new List<string>();
        consoleServiceMock.Setup(x => x.Write(It.IsAny<string>()))
            .Callback<string>(value => consoleLog.Add(value));
        consoleServiceMock.Setup(x => x.ReadLine())
            .Returns(taskNo); // Non-existing, not implemented task number
        int actualTaskNo = 0;
        consoleServiceMock.Setup(x => x.WriteLine(It.IsAny<string>(), It.IsAny<object>()))
            .Callback<string, object>((format, arg0) =>
            {
                actualTaskNo = (int)arg0;
                string line = string.Format(format, arg0);
                consoleLog.Add(line);
            });

        // Act
        Chapter1.Run(consoleServiceMock.Object, textCompressionMock.Object);

        // Assert
        Assert.NotEmpty(consoleLog);
        Assert.Equal(2, consoleLog.Count);
        Assert.Equal(taskNo, actualTaskNo.ToString());
        Assert.Contains(consoleLog, line => line.Contains($"Task {taskNo}"));
        Assert.Contains(consoleLog, line => line.Contains("Sorry, there are no task!"));
    }
}
