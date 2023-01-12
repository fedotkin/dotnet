namespace Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

/// <summary>
/// This interface defines what we are expecting from any Program Manager. Aka IProgramManager interface.
/// </summary>
/// <remarks>
/// ITNEXT docs: <see href="https://itnext.io/how-to-fully-cover-net-c-console-application-with-unit-tests-446927a4a793">How to Cover .NET C# Console Application With Unit Tests</see>
/// </remarks>
public interface IConsoleProgram
{
    /// <summary>
    /// Gets services of current DI-container.
    /// </summary>
    /// <remarks>
    /// Use it for DI in static methods via a service injection as parameter.
    /// </remarks>
    IServiceProvider Services { get; }

    /// <summary>
    /// Runs the program.
    /// </summary>
    void Run();
    
    void Run(Action action);
    void Run(Action<IConsoleService> action);
}
