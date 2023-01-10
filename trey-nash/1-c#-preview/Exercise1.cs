namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

/// <summary>
/// C# preview
/// </summary>
public class Exercise1
{
    public interface ITextCompression
    {
        string AddToString(int num, char sym);
        List<string> Decompress(List<string> inputList);
        void TextReads(string fileName);
        List<string> Compress(List<string> inputList);
    }

    public class TextCompression : ITextCompression
    {
        /// <summary>
        /// Reads from the text file.
        /// </summary>
        public void TextReads(string fileName)
        {
            using var reader = File.OpenText(fileName);
            string? item;
            do
            {
                item = reader.ReadLine();
                Console.WriteLine(item);
            } while (item != null);
        }

        /// <summary>
        /// Text compression method in the list
        /// </summary>
        public List<string> Compress(List<string> inputList)
        {
            List<string> tempList = new List<string>();

            foreach (string line in inputList) // Compress each line in the list
            {
                int position = 0;       // Symbol position in a string
                char symbol;            // Symbol in a string
                string tempString = ""; // Temporary string to write

                while (position < line.Length)
                {
                    symbol = line[position];

                    // A. If the symbol is the last in the string
                    if (position == line.Length - 1)
                    {
                        // A.1. If symbol is '\' (Compression Rule 8)
                        if (symbol == '\\') tempString += @"\\";

                        // A.2. If symbol is not a number (Compression Rule 5)
                        else if (!Char.IsNumber(symbol)) tempString += symbol;

                        // A.3. If symbol is a number (Compression Rule 6)
                        else tempString += $"\\{symbol}";

                        break;
                    }

                    // B. If single symbol
                    else if (line[position + 1] != symbol)
                    {
                        // B.1. If symbol is '\' (Compression Rule 8)
                        if (symbol == '\\') tempString += @"\\";

                        // B.2. If symbol is not a number (Compression Rule 5)
                        else if (!Char.IsNumber(symbol)) tempString += symbol;

                        // B.3. If symbol is a number (Compression Rule 6)
                        else tempString += $"\\{symbol}";

                        position++;
                    }

                    // C. Identical symbols 
                    else
                    {
                        int length = 0; // Number of identical symbols
                        for (int j = 1; j < line.Length - position; j++) // Count the number of identical symbols
                        {
                            if (line[position + j] == symbol) length = j + 1;
                            else break;
                        }

                        // C.1. If symbol is not a number
                        if (!Char.IsNumber(symbol))
                        {
                            if (length == 2) tempString += $"{symbol}{symbol}"; // If two symbols (Compression Rule 5)
                            else tempString += $"{length}{symbol}"; // If more than two symbols (Compression Rule 4)
                        }

                        // C.2. If symbol is a number
                        else tempString += $"{length}\\{symbol}"; // (Compression Rule 7)

                        position += length;
                    }
                }
                tempList.Add(tempString);
            }
            return tempList;
        }

        public string AddToString(int lengthToString, char symbolToString) // TODO: Delete the method
        {
            return "";
        }

        /// <summary>
        /// Method for unpacking text in a list
        /// </summary>
        public List<string> Decompress(List<string> inputList)
        {
            List<string> tempList = new List<string>();

            foreach (string line in inputList) // Decompress each line in the list
            {
                int length = 0;         // Number of symbols
                int position = 0;       // Symbol position in a string
                char symbol;            // Symbol in a string
                string tempString = ""; // Temporary string to write

                while (position < line.Length)
                {
                    symbol = line[position];

                    // A. If symbol is '\'
                    if (symbol == '\\')
                    {
                        // A.1. If the second symbol is '\'
                        if (line[position + 1] == '\\') tempString += '\\';

                        // A.2. Second symbol is not '\'
                        else tempString += line[position + 1];

                        length = 2;
                        position += length;
                    }

                    // B. If the symbol is not '\' and a number
                    else if (symbol != '\\' && !Char.IsNumber(symbol))
                    {
                        // B.1. If the symbol is the last in the string
                        if (position == line.Length - 1)
                        {
                            tempString += symbol;
                            break;
                        }

                        // B.2. If the second symbol is the same
                        else if (line[position + 1] == symbol)
                        {
                            tempString += $"{symbol}{symbol}";
                            length = 2;
                        }

                        // B.3. The second symbol is not the same
                        else
                        {
                            tempString += symbol;
                            length = 1;
                        }

                        position += length;
                    }

                    // C. If symbol is a number
                    if (Char.IsNumber(symbol))
                    {
                        // C.1. If the second symbol is '\'
                        if (line[position + 1] == '\\')
                            for (int j = 0; j < symbol - '0'; j++)
                            {
                                tempString += line[position + 2];
                                length = 3;
                            }

                        // C.2. If the second symbol is not '\' and a number
                        else if (line[position + 1] == '\\' && !Char.IsNumber(line[position + 1]))
                            for (int j = 0; j < symbol - '0'; j++)
                            {
                                tempString += line[position + 1];
                                length = 2;
                            }

                        // C.3. The second and following symbols are a number (the number of digits is 2 or more)
                        else
                        {
                            length = 0;
                            while (length < line.Length && Char.IsNumber(line[position + length]))
                            {
                                length++;
                            }
                            int numberOfDigits = Convert.ToInt32(line.Substring(position, length));
                            for (int j = 0; j < numberOfDigits; j++)
                            {
                                tempString += line[position + length];
                            }
                            length++;
                        }

                        position += length;
                    }
                }
                tempList.Add(tempString);
            }
            return tempList;
        }
    }
}
