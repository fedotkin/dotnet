﻿using Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;
using Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts;
using Fedotkin.Dotnet.TreyNash.ConsoleServices;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using static System.Console;

namespace Fedotkin.Dotnet.TreyNash.Console;

internal class Program : DefaultConsoleProgram
{
    private readonly IConsoleService _console;
    private readonly ITextCompression _compression;

    public Program(IConsoleService consoleService, ITextCompression textCompression)
        : base(consoleService)
    {
        _console = consoleService;
        _compression = textCompression;
    }

    /// <summary>
    /// Main method of the application.
    /// </summary>
    public override void Run()
    {
        while (true)
        {
            _console.Write("\nEnter chapter number (1-17): ");
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
                    Chapter1.Run(_console, _compression);
                    break;
                case 5:
                    Chapter5.Run();
                    break;
                default:
                    _console.WriteLine("Chapter {0}: Sorry, there are no exercises and no implemented solutions to demonstrate!", chapterNo);
                    break;
            }

            Write("\nEnter Ctrl+Q to Quit, Ctrl+E to Exit, Ctrl+L to Clear the window\nOr any key to show the next chapter demo... ");
            ConsoleKeyInfo info = ReadKey();
            if (info.Modifiers == ConsoleModifiers.Control)
            {
                if (info.Key == ConsoleKey.Q)
                {
                    WriteLine("Soft quitting...");
                    Environment.ExitCode = 0;
                    break; // while (true)
                }
                else if (info.Key == ConsoleKey.E)
                {
                    WriteLine("Force exitting...");
                    Environment.Exit(1);
                }
                else if (info.Key == ConsoleKey.L)
                {
                    Clear();
                }
            }
        }
    }

    /// <summary>
    /// Main entry point of the program.
    /// </summary>
    /// <param name="args">Console app arguments</param>
    /// <returns>The asynch <see cref="Task"/> object to run by the console host.</returns>
    static async Task Main(string[] args)
    {
        using IHost host = InitializeHost(args);

        if (args.Length == 0 || args.Length > 0 && !args.Contains("--skipTest"))
            TestDIContainer(host);

        WriteLine("Starting the Program...");

        var program = host.Services.GetService<IConsoleProgram>();
        program.Run();
        
        WriteLine($"\nProgram has exited with code '{Environment.ExitCode}'\n");

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
        services.TryAddSingleton<IConsoleProgram, Program>();
        services.AddTransient<IConsoleService, DefaultConsoleService>()
            .AddTransient<ITextCompression, TextCompression>();
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
