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
        /// <param name="inputList">
        /// 
        /// </param>
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
                    symbol = line[position]; // Consider the symbol (which is selected from the original string)
                    if (position == line.Length - 1) // If the symbol is the last in the string
                    {
                        if (symbol == '\\') tempString += @"\\"; // If symbol is '\' (Rule 8)
                        else if (!Char.IsNumber(symbol)) tempString += symbol; // If symbol is not a number (Rule 5)
                        else if (Char.IsNumber(symbol)) tempString += $"\\{symbol}"; // If symbol is a number (Rule 6)
                        break;
                    }
                    else if (line[position + 1] != symbol) // If single symbol
                    {
                        if (symbol == '\\') tempString += @"\\"; // If symbol is '\' (Rule 8)
                        else if (!Char.IsNumber(symbol)) tempString += symbol; // If symbol is not a number (Rule 5)
                        else if (Char.IsNumber(symbol)) tempString += $"\\{symbol}"; // If symbol is a number (Rule 6)
                        position++;
                    }
                    else // Identical symbols 
                    {
                        int length = 0; // Number of identical symbols
                        for (int j = 1; j < line.Length - position; j++) // Count the number of identical symbols
                        {
                            if (line[position + j] == symbol) length = j + 1;
                            else break;
                        }
                        if (!Char.IsNumber(symbol)) // If symbol is not a number
                        {
                            if (length == 2) tempString += $"{symbol}{symbol}"; // (Rule 5)
                            else tempString += $"{length}{symbol}"; // (Rule 4)
                        }
                        else // If symbol is a number
                        {
                            tempString += $"{length}\\{symbol}"; // (Rule 7)
                        }
                        position += length;
                    }
                }
                tempList.Add(tempString);
            }
            return tempList;
        }

        public string AddToString(int lengthToString, char symbolToString) // delete
        {
            return "";
        }

        /// <summary>
        /// Method for unpacking text in a list
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<string> Decompress(List<string> inputList)
        {
            List<string> tempList = new List<string>();
            foreach (string line in inputList) // Compress each line in the list
            {
                int length = 0;         // Number of characters
                int position = 0;       // Character position in a string
                char symbol;            // Character in a string
                string tempString = ""; // Temporary string to write
                while (position < line.Length)
                {
                    symbol = line[position];
                    if (symbol == '\\') // 1. If character is '\'
                    {
                        if (line[position + 1] == '\\') // 1.1. If the second character is '\'
                            tempString += '\\';
                        else // 1.2. Second character is not '\'
                            tempString += line[position + 1];
                        length = 2;
                        position += length;
                    }
                    else if (symbol != '\\' & !Char.IsNumber(symbol)) // 2. If the character is not '\' and a number
                    {
                        if (position == line.Length - 1) // 2.1. If the character is the last in the string
                        {
                            tempString += symbol;
                            break;
                        }
                        else if (line[position + 1] == symbol) // 2.2. If the second character is the same
                        {
                            tempString = tempString + symbol + symbol;
                            length = 2;
                        }
                        else // 2.3. The second character is not the same
                        {
                            tempString += symbol;
                            length = 1;
                        }
                        position += length;
                    }
                    if (Char.IsNumber(symbol)) // 3. If character is a number
                    {
                        if (line[position + 1] == '\\') // 3.1. If the second character is '\'
                            for (int j = 0; j < symbol - '0'; j++)
                            {
                                tempString += line[position + 2];
                                length = 3;
                            }
                        else if (line[position + 1] == '\\' & !Char.IsNumber(line[position + 1]))
                            // 3.2. If the second character is not '\' and a number
                            for (int j = 0; j < symbol - '0'; j++)
                            {
                                tempString += line[position + 1];
                                length = 2;
                            }
                        else // 3.3. The second and following characters are a number (the number of digits is 2 or more)
                        {
                            length = 0;
                            while (length < line.Length & Char.IsNumber(line[position + length]))
                            {
                                length++;
                            }
                            int number_of_digits = Convert.ToInt32(line.Substring(position, length));
                            for (int j = 0; j < number_of_digits; j++)
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
