using Fedotkin.Dotnet.TreyNash.ConsoleServices;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

public static class Chapter1
{
    /// <summary>
    /// Runs the demo of <see cref="TextCompression"/>.
    /// </summary>
    public static void Run(IConsoleService console)
    {
        console.Write($"{nameof(Chapter1)} demo.\nEnter task number of {nameof(TextCompression)} (1-2): ");
        int taskNo = 0;
        while (taskNo == 0)
        {
            try { taskNo = Convert.ToInt32(console.ReadLine()); }
            catch { taskNo = 0; }
        }
        // Select task number
        switch (taskNo)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            default:
                console.WriteLine("Task {0}: Sorry, there are no task!", taskNo);
                break;
        }
    }

    /// <summary>
    /// Starts <see cref="Task1"/> method from the <see cref="Exercise1"/> class.
    /// </summary>
    public static void Task1()
    {
        string fileName = "Exercise1.txt";
        TextCompression.TextReads(fileName);
    }

    /// <summary>
    /// Starts <see cref="Task2"/> method from the <see cref="Exercise1"/> class.
    /// </summary>
    public static void Task2()
    {
        List<string> startList = new List<string>(); // List of source strings
        startList.Add(@"
 _   _      _ _         _    _            _     _ _ 
| | | |    | | |       | |  | |          | |   | | |
| |_| | ___| | | ___   | |  | | ___  _ __| | __| | |
|  _  |/ _ \ | |/ _ \  | |/\| |/ _ \| '__| |/ _` | |
| | | |  __/ | | (_) | \  /\  / (_) | |  | | (_| |_|
\_| |_/\___|_|_|\___/   \/  \/ \___/|_|  |_|\__,_(_)");

        Console.WriteLine("Start list:");
        foreach (var item in startList)
        {
            Console.WriteLine(item);
        }

        List<string> compressedList = new List<string>(); // Create a new list for compressed strings
        compressedList = TextCompression.Сompress(startList);
        Console.WriteLine("\nCompressed list:");
        foreach (var item in compressedList)
        {
            Console.WriteLine(item);
        }

        List<string> decompressedList = new List<string>(); // Create a new list for unpacked strings
        decompressedList = TextCompression.Decompress(compressedList);
        Console.WriteLine("\nDecompressed list:");
        foreach (var item in decompressedList)
        {
            Console.WriteLine(item);
        }
    }
}
