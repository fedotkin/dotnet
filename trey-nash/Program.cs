using Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts;
class Program
{
    /// <summary>
    /// Book chapter selection
    /// </summary>
    static void Main()
    {
        Console.Write("Enter chapter number (1-17): ");
        int chapterNo = 0;
        while (chapterNo == 0)
        {
            try { chapterNo = Convert.ToInt32(Console.ReadLine()); }
            catch { chapterNo = 0; }
        }
        switch (chapterNo)
        {
            case 5:
                Chapter5.Run();
                break;
            default:
                Console.WriteLine("Chapter {0}: sorry, no content", chapterNo);
                break;
        }
    }
}
