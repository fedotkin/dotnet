namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

/// <summary>
/// C# preview
/// </summary>
static class Exercise1_1
{
    /// <summary>
    /// Stream from text file
    /// </summary>
    /// <param name="filename"></param>
    public static void Text_stream(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        while (!reader.EndOfStream) Console.WriteLine(reader.ReadLine());
        reader.Close();
    }
}
