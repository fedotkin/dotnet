namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview
{
    public interface ITextCompression
    {
        string AddToString(int num, char sym);
        List<string> Decompress(List<string> inputList);
        void TextReads(string fileName);
        List<string> Сompress(List<string> inputList);
    }
}
