using ChapterExercises._5_interfaces_and_contracts;
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter chapter number (1-17): ");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 5:
                    Chapter5.Run();
                    break;
                default:
                    Console.WriteLine("Chapter {0}: sorry, no content", num);
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Error");
        }
    }
}

