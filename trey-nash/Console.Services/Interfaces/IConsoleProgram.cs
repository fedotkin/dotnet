namespace Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

/// <summary>
/// This interface defines what we are expecting from any Program Manager. Aka IProgramManager interface.
/// </summary>
/// <remarks>
/// ITNEXT docs: <see href="https://itnext.io/how-to-fully-cover-net-c-console-application-with-unit-tests-446927a4a793">How to Cover .NET C# Console Application With Unit Tests</see>
/// </remarks>
public interface IConsoleProgram
{
    void Run();
    void Run(Action<IConsoleService> action);
}
