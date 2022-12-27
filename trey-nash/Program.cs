using Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts;
// TODO: Define root namespace explicitly in the project.
//namespace Fedotkin.Dotnet.TreyNash;

/// <summary>
/// Main entry point of the program.
/// </summary>
Console.Write("Enter chapter number (1-17): ");
int chapterNo = 0;
while (chapterNo == 0)
{
    try { chapterNo = Convert.ToInt32(Console.ReadLine()); }
    catch { chapterNo = 0; }
}
// Select book chapter and run the demo
switch (chapterNo)
{
    case 5:
        Chapter5.Run();
        break;
    default:
        Console.WriteLine("Chapter {0}: Sorry, there are no exercises and no implemented solutions to demonstrate!", chapterNo);
        break;
}
