using Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts;

namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

static class Chapter1
{
    /// <summary>
    /// Runs the demo of <see cref="Exercise1"/>.
    /// </summary>
    public static void Run()
    {
        Console.Write("Enter task number of Exercise1 (1-2): ");
        int taskNo = 0;
        while (taskNo == 0)
        {
            try { taskNo = Convert.ToInt32(Console.ReadLine()); }
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
                Console.WriteLine("Task {0}: Sorry, there are no task!", taskNo);
                break;
        }
    }

    /// <summary>
    /// Start task 1 from Exercise1
    /// </summary>
    public static void Task1()
    {
        string filename = @"..\..\..\1-c#-preview\Exercise1_1.txt";
        Exercise1_1.Text_stream(filename);
    }

    /// <summary>
    /// Start task 2 from Exercise1
    /// </summary>
    public static void Task2()
    {
        List<string> start_list = new List<string>(); //List of source strings
        start_list.Add(@"
 _   _      _ _         _    _            _     _ _ 
| | | |    | | |       | |  | |          | |   | | |
| |_| | ___| | | ___   | |  | | ___  _ __| | __| | |
|  _  |/ _ \ | |/ _ \  | |/\| |/ _ \| '__| |/ _` | |
| | | |  __/ | | (_) | \  /\  / (_) | |  | | (_| |_|
\_| |_/\___|_|_|\___/   \/  \/ \___/|_|  |_|\__,_(_)");

        Console.WriteLine("Start list:");
        foreach (var item in start_list) Console.WriteLine(item);

        List<string> compressed_list = new List<string>(); //Create a new list for compressed strings
        compressed_list = Exercise1_2.Сompression(start_list);
        Console.WriteLine("\nCompressed list:");
        foreach (var item in compressed_list) Console.WriteLine(item);

        List<string> decompressed_list = new List<string>(); //Create a new list for unpacked strings
        decompressed_list = Exercise1_2.Decompression(compressed_list);
        Console.WriteLine("\nDecompressed list:");
        foreach (var item in decompressed_list) Console.WriteLine(item);
    }
}
