using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;
using static Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview.Exercise1;

namespace Fedotkin.Dotnet.TreyNash.ChapterExercises.Tests;

public class TextCompressionTests
{
    private readonly Mock<IConsoleService> consoleMock;
    private readonly TextCompression sut; // system under test

    public TextCompressionTests()
    {
        consoleMock = new Mock<IConsoleService>();
        sut = new TextCompression(consoleMock.Object);
    }

    [Fact]
    public void ReadText_WrongFileName_ThrowsFileNotFound()
    {
        // Arrange
        string path = Environment.CurrentDirectory + "\\test.txt";

        // Act
        var exception = Assert.Throws<FileNotFoundException>(
            () => sut.ReadText(path));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal($"Could not find file '{path}'.", exception.Message);
    }

    [Fact]
    public void ReadText_FileExists_WritesAllLinesToConsole()
    {
        // Arrange
        string fileBody = "1\r\n22\r\n333";
        byte[] buffer = fileBody.Select(ch => (byte)ch).ToArray();
        string path = $"{Environment.CurrentDirectory}\\{nameof(ReadText_FileExists_WritesAllLinesToConsole)}.txt";
        using (var stream = File.Create(path))
        {
            stream.Write(buffer);
        }

        List<string> consoleLog = new List<string>();
        consoleMock.Setup(x => x.WriteLine(It.IsAny<string>()))
            .Callback<string>(consoleLog.Add);

        // Act
        sut.ReadText(path);

        // Assert
        Assert.Equal(3, consoleLog.Count);
        var lines = fileBody.Split("\r\n");
        Assert.All(lines, line => Assert.Contains(line, consoleLog));
    }
}
