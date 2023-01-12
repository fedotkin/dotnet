using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;
using static Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview.Exercise1;

namespace Fedotkin.Dotnet.TreyNash.ChapterExercises.Tests;

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
    public void Run_1stParamIsNull_ThrowsException()
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => Chapter1.Run(null, textCompressionMock.Object));
        
        // Assert
        Assert.NotNull(exception);
        Assert.Equal("console", exception.ParamName);
    }

    [Fact]
    public void Run_2ndParamIsNull_ThrowsException()
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => Chapter1.Run(consoleServiceMock.Object, null));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("compression", exception.ParamName);
    }

    [Fact]
    public void Run_BadNumberEntering_AsksTaskNumberWithNoException()
    {
        // Arrange
        int askedCount = 0;
        List<string> consoleLog = new List<string>();
        consoleServiceMock.Setup(x => x.Write(It.IsAny<string>()))
            .Callback<string>(value => consoleLog.Add(value));
        consoleServiceMock.Setup(x => x.ReadLine())
            .Returns(() => askedCount == 0 ? "A" : "-1") // Bad task number for the first time, next, good number
            .Callback(() => askedCount++); // Return valid number during next entering
        int actualTaskNo = 0;
        consoleServiceMock.Setup(x => x.WriteLine(It.IsAny<string>(), It.IsAny<object>()))
            .Callback<string, object>((format, arg0) =>
            {
                actualTaskNo = (int)arg0;
                consoleLog.Add("default case");
            });

        // Act
        Chapter1.Run(consoleServiceMock.Object, textCompressionMock.Object);

        // Assert
        Assert.NotEmpty(consoleLog);
        Assert.Equal(2, consoleLog.Count);
        Assert.Equal(-1, actualTaskNo);
        Assert.Contains("default case", consoleLog);
        consoleServiceMock.Verify(x => x.Write(It.IsAny<string>()));
        consoleServiceMock.Verify(x => x.WriteLine(It.IsAny<string>(), It.IsAny<object>()));
        consoleServiceMock.Verify(x => x.ReadLine(), Times.Exactly(2));
        Assert.Equal(2, askedCount);
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

    [Fact]
    public void Task1_ParamIsNull_ThrowsException()
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => Chapter1.Task1(null));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("compression", exception.ParamName);
    }

    [Fact]
    public void Task1_MainPath_ReadsTextFile()
    {
        // Arrange
        string expectedBasePath = Environment.CurrentDirectory;
        string actualFilePath = string.Empty;
        textCompressionMock.Setup(x => x.ReadText(It.IsAny<string>()))
            .Callback<string>((path) => actualFilePath = path);

        // Act
        Chapter1.Task1(textCompressionMock.Object);

        Assert.StartsWith(expectedBasePath, actualFilePath);
        textCompressionMock.Verify(x => x.ReadText(It.IsAny<string>()));
    }

    [Fact]
    public void Task2_1stParamIsNull_ThrowsException()
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => Chapter1.Task2(null, textCompressionMock.Object));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("console", exception.ParamName);
    }

    [Fact]
    public void Task2_2ndParamIsNull_ThrowsException()
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentNullException>(
            () => Chapter1.Task2(consoleServiceMock.Object, null));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("compression", exception.ParamName);
    }

    [Fact]
    public void Task2_MainPath_CompressAndDecompressWithWritingToConsole()
    {
        // Arrange
        var consoleLog = new List<string>();
        consoleServiceMock.Setup(x => x.WriteLine(It.IsAny<string>()))
            .Callback<string>(value => consoleLog.Add(value));
        List<string> actualStartList = new List<string>();
        textCompressionMock.Setup(x => x.Compress(It.IsAny<List<string>>()))
            .Callback<List<string>>(startList => actualStartList.AddRange(startList))
            .Returns(new List<string> { "compressedList item" });
        textCompressionMock.Setup(x => x.Decompress(It.IsAny<List<string>>()))
            .Returns(new List<string> { "decompressedList item" });

        // Act
        Chapter1.Task2(consoleServiceMock.Object, textCompressionMock.Object);

        // Assert
        Assert.NotEmpty(consoleLog);
        Assert.Contains("Start list:", consoleLog);
        
        // Assert logging to console
        string line = actualStartList.First();
        Assert.Contains(line, consoleLog);
        line = actualStartList.Last();
        Assert.Contains(line, consoleLog);

        textCompressionMock.Verify(x => x.Compress(It.IsAny<List<string>>()));
        Assert.Contains("\nCompressed list:", consoleLog);
        Assert.Contains("compressedList item", consoleLog);

        textCompressionMock.Verify(x => x.Decompress(It.IsAny<List<string>>()));
        Assert.Contains("\nDecompressed list:", consoleLog);
        Assert.Contains("decompressedList item", consoleLog);

        consoleServiceMock.Verify(x => x.WriteLine(It.IsAny<string>()),
            Times.Exactly(actualStartList.Count+5)); // 1+actualStartList+1+compressedList(1)+1+decompressedList(1) = 1+actualStartList.Count+4
    }
}
