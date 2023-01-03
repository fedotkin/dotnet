using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;

/// <summary>
/// This is default Console Manager implementation which wraps <see cref="System.Console"/> and is actually used at runtime. Aka ConsoleManager class.
/// </summary>
/// <remarks>
/// ITNEXT docs: <see href="https://itnext.io/how-to-fully-cover-net-c-console-application-with-unit-tests-446927a4a793">How to Cover .NET C# Console Application With Unit Tests</see>
/// </remarks>
public class DefaultConsoleService : IConsoleService
{
    public void Clear()
    {
        Console.Clear();
    }

    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string value)
    {
        Console.Write(value);
    }

    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }

    public void WriteLine(string format, object arg0)
    {
        Console.WriteLine(format, arg0);
    }
}
