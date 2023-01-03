
namespace Fedotkin.Dotnet.TreyNash.Services;

public interface IConsoleService
{
    void Write(string value);
    void WriteLine(string value);
    ConsoleKeyInfo ReadKey();
    string ReadLine();
    void Clear();
}
