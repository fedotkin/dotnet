using Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;
using Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.Console;

/// <summary>
/// This is the default Program Manager implementation which is actually used at runtime.
/// It also depends on the <see cref="IConsoleService"/>.
/// Aka ProgramManager class.
/// </summary>
/// <remarks>
/// ITNEXT docs: <see href="https://itnext.io/how-to-fully-cover-net-c-console-application-with-unit-tests-446927a4a793">How to Cover .NET C# Console Application With Unit Tests</see>
/// </remarks>
public class ConsoleProgram : IConsoleProgram
{
    private readonly IConsoleService _console;

    public ConsoleProgram(IConsoleService consoleService)
    {
        _console = consoleService;
    }

    public void Run()
    {
        _console.Write("Enter chapter number (1-17): ");
        int chapterNo = 0;
        while (chapterNo == 0)
        {
            try { chapterNo = Convert.ToInt32(_console.ReadLine()); }
            catch { chapterNo = 0; }
        }
        // Select book chapter and run the demo
        switch (chapterNo)
        {
            case 1:
                Chapter1.Run();
                break;
            case 5:
                Chapter5.Run();
                break;
            default:
                _console.WriteLine("Chapter {0}: Sorry, there are no exercises and no implemented solutions to demonstrate!", chapterNo);
                break;
        }
    }
}
