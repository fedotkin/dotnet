using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;

namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

public static class Chapter1
{
    /// <summary>
    /// Runs the demo of <see cref="TextCompression"/>.
    /// </summary>
    public static void Run(IConsoleService console, ITextCompression compression)
    {
        if (console == null) throw new ArgumentNullException(nameof(console));
        if (compression == null) throw new ArgumentNullException(nameof(compression));

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
                Task1(compression);
                break;
            case 2:
                Task2(console, compression);
                break;
            default:
                console.WriteLine("Task {0}: Sorry, there are no task!", taskNo);
                break;
        }
    }

    /// <summary>
    /// Starts <see cref="Task1"/> method from the <see cref="Exercise1"/> class.
    /// </summary>
    public static void Task1(ITextCompression compression)
    {
        if (compression == null) throw new ArgumentNullException(nameof(compression));

        string workingDirectory = Environment.CurrentDirectory;
        string fileName = workingDirectory + "\\1-c#-preview\\Exercise1.txt";
        compression.TextReads(fileName);
    }

    /// <summary>
    /// Starts <see cref="Task2"/> method from the <see cref="Exercise1"/> class.
    /// </summary>
    public static void Task2(IConsoleService console, ITextCompression compression)
    {
        if (console == null) throw new ArgumentNullException(nameof(console));
        if (compression == null) throw new ArgumentNullException(nameof(compression));

        // List of source strings
        List<string> startList = new List<string>
        {
            @" _   _      _ _         _    _            _     _ _ ",
            @"| | | |    | | |       | |  | |          | |   | | |",
            @"| |_| | ___| | | ___   | |  | | ___  _ __| | __| | |",
            @"|  _  |/ _ \ | |/ _ \  | |/\| |/ _ \| '__| |/ _` | |",
            @"| | | |  __/ | | (_) | \  /\  / (_) | |  | | (_| |_|",
            @"\_| |_/\___|_|_|\___/   \/  \/ \___/|_|  |_|\__,_(_)"
        };

        console.WriteLine("Start list:");
        foreach (var item in startList)
        {
            console.WriteLine(item);
        }

        // Create a new list for compressed strings
        List<string> compressedList = new List<string>();
        compressedList = compression.Compress(startList);
        console.WriteLine("\nCompressed list:");
        foreach (var item in compressedList)
        {
            console.WriteLine(item);
        }

        // Create a new list for unpacked strings
        List<string> decompressedList = new List<string>();
        decompressedList = compression.Decompress(compressedList);
        console.WriteLine("\nDecompressed list:");
        foreach (var item in decompressedList)
        {
            console.WriteLine(item);
        }
    }
}
