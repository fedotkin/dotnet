using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;

/// <summary>
/// This is the default Program Manager implementation which is actually used at runtime.
/// It also depends on the <see cref="IConsoleService"/>.
/// Aka ProgramManager class.
/// </summary>
/// <remarks>
/// ITNEXT docs: <see href="https://itnext.io/how-to-fully-cover-net-c-console-application-with-unit-tests-446927a4a793">How to Cover .NET C# Console Application With Unit Tests</see>
/// </remarks>
public class DefaultConsoleProgram : IConsoleProgram
{
    private readonly IConsoleService _console;

    public DefaultConsoleProgram(IConsoleService consoleService)
    {
        _console = consoleService;
    }

    public virtual void Run() { }

    public virtual void Run(Action<IConsoleService> action)
    {
        action?.Invoke(_console);
    }
}
