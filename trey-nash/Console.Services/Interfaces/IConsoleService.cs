
namespace Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

/// <summary>
/// This interface defines what we are expecting from any Console Manager. Aka IConsoleManager interface.
/// <para>Concrete classes must implement calls of the <see cref="Console"/> class static methods.</para>
/// </summary>
/// <remarks>
/// ITNEXT docs: <see href="https://itnext.io/how-to-fully-cover-net-c-console-application-with-unit-tests-446927a4a793">How to Cover .NET C# Console Application With Unit Tests</see>
/// </remarks>
public interface IConsoleService
{
    void Write(string value);
    void WriteLine(string value);
    void WriteLine(string format, object arg0);
    ConsoleKeyInfo ReadKey();
    string ReadLine();
    void Clear();
}
