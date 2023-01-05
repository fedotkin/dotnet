using Fedotkin.Dotnet.TreyNash.ConsoleServices;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Console;

namespace Fedotkin.Dotnet.TreyNash.Console;

///// <summary>
///// Main entry point of the program.
///// </summary>
//Console.Write("Enter chapter number (1-17): ");
//int chapterNo = 0;
//while (chapterNo == 0)
//{
//    try { chapterNo = Convert.ToInt32(Console.ReadLine()); }
//    catch { chapterNo = 0; }
//}
//// Select book chapter and run the demo
//switch (chapterNo)
//{
//    case 1:
//        Chapter1.Run();
//        break;
//    case 5:
//        Chapter5.Run();
//        break;
//    default:
//        Console.WriteLine("Chapter {0}: Sorry, there are no exercises and no implemented solutions to demonstrate!", chapterNo);
//        break;
//}

//public void Run()
//{
//    _console.Write("Enter chapter number (1-17): ");
//    int chapterNo = 0;
//    while (chapterNo == 0)
//    {
//        try { chapterNo = Convert.ToInt32(_console.ReadLine()); }
//        catch { chapterNo = 0; }
//    }
//    // Select book chapter and run the demo
//    switch (chapterNo)
//    {
//        case 1:
//            Chapter1.Run();
//            break;
//        case 5:
//            Chapter5.Run();
//            break;
//        default:
//            _console.WriteLine("Chapter {0}: Sorry, there are no exercises and no implemented solutions to demonstrate!", chapterNo);
//            break;
//    }
//}

internal class Program
{

    private static IConsoleProgram _program = null;

    static async Task Main(string[] args)
    {
        //_program.Run();
        using IHost host = InitializeHost(args);

        if (args.Length == 0 || args.Length > 0 && !args.Contains("--skipTest"))
            TestDIContainer(host);

        await host.RunAsync();
    }

    static IHost InitializeHost(string[] args)
    {
        IHostBuilder builder = Host.CreateDefaultBuilder(args);

        if (args.Length == 0 || args.Length > 0 && !args.Contains("--skipTest"))
            builder.ConfigureServices(RegisterDITestServices);

        builder.ConfigureServices(RegisterServices);
        
        return builder.Build();
    }

    static void RegisterServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<IConsoleProgram, DefaultConsoleProgram>();
    }

    static void RegisterDITestServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddTransient<ITransientOperation, DefaultOperation>()
            .AddScoped<IScopedOperation, DefaultOperation>()
            .AddSingleton<ISingletonOperation, DefaultOperation>()
            .AddTransient<OperationLogger>();
    }

    static void TestDIContainer(IHost host)
    {
        Write("Initializing and testing DI-container...\n-------");
        ExemplifyScoping(host.Services, "Scope 1");
        ExemplifyScoping(host.Services, "Scope 2");
        WriteLine("-------\nDone.\n");
    }

    static void ExemplifyScoping(IServiceProvider services, string scope)
    {
        using IServiceScope serviceScope = services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        WriteLine();
        OperationLogger logger = provider.GetRequiredService<OperationLogger>();
        logger.LogOperations($"{scope}: Call 1 .GetRequiredService<OperationLogger>()");

        WriteLine("...");
        logger = provider.GetRequiredService<OperationLogger>();
        logger.LogOperations($"{scope}: Call 2 .GetRequiredService<OperationLogger>()");
    }
}
