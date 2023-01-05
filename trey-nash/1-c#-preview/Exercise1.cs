namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

/// <summary>
/// C# preview
/// </summary>
public class TextCompression : ITextCompression
{
    /// <summary>
    /// Reads from the text file.
    /// </summary>
    /// <param name="fileName"></param>
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
    /// Method for adding data to a string for compression
    /// </summary>
    /// <param name="num"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public string AddToString(int num, char sym)
    {
        string temp = "";
        if (sym == '\\') // If character is '\'
        {
            for (int i = 0; i < num; i++) temp = temp + @"\\";
            return temp;
        }
        else if (!Char.IsNumber(sym)) // If character is not a number
            switch (num)
            {
                case 1: return temp + sym;
                case 2: return temp + sym + sym;
                default: return temp + num + sym;
            }
        else if (Char.IsNumber(sym)) // If character is a number
            switch (num)
            {
                case 1: return temp + "\\" + sym;
                default: return temp + num + "\\" + sym;
            }
        return temp;
    }

    /// <summary>
    /// Text compression method in the list
    /// </summary>
    /// <param name="inputList"></param>
    /// <returns></returns>
    public List<string> Сompress(List<string> inputList)
    {
        List<string> tempList = new List<string>();
        for (int i = 0; i < inputList.Count; i++) // Compress each line in the list
        {
            int length = 0;         // Number of identical characters
            int position = 0;       // Character position in a string
            char symbol;            // Character in a string
            string tempString = ""; // Temporary string to write
            while (position < inputList[i].Length)
            {
                symbol = inputList[i][position];
                if (position == inputList[i].Length - 1) // If the character is the last in the string
                {
                    length = 1;
                    tempString += AddToString(length, symbol);
                    break;
                }
                else if (inputList[i][position + 1] != symbol) // If single character
                {
                    length = 1;
                    tempString += AddToString(length, symbol);
                    position += length;
                }
                else // Same symbols
                {
                    for (int j = 1; j < inputList[i].Length - position; j++) // Count the number of identical characters
                    {
                        if (inputList[i][position + j] == symbol) length = j + 1;
                        else break;
                    }
                    tempString += AddToString(length, symbol);
                    position += length;
                }
            }
            tempList.Add(tempString);
        }
        return tempList;
    }

    /// <summary>
    /// Method for unpacking text in a list
    /// </summary>
    /// <param name="inputList"></param>
    /// <returns></returns>
    public List<string> Decompress(List<string> inputList)
    {
        List<string> temp_list = new List<string>();
        for (int i = 0; i < inputList.Count; i++) // Compress each line in the list
        {
            int length = 0;         // Number of characters
            int position = 0;       // Character position in a string
            char symbol;            // Character in a string
            string tempString = ""; // Temporary string to write
            while (position < inputList[i].Length)
            {
                symbol = inputList[i][position];
                if (symbol == '\\') // 1. If character is '\'
                {
                    if (inputList[i][position + 1] == '\\') // 1.1. If the second character is '\'
                        tempString += '\\';
                    else // 1.2. Second character is not '\'
                        tempString += inputList[i][position + 1];
                    length = 2;
                    position += length;
                }
                else if (symbol != '\\' & !Char.IsNumber(symbol)) // 2. If the character is not '\' and a number
                {
                    if (position == inputList[i].Length - 1) // 2.1. If the character is the last in the string
                    {
                        tempString += symbol;
                        break;
                    }
                    else if (inputList[i][position + 1] == symbol) // 2.2. If the second character is the same
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
                    if (inputList[i][position + 1] == '\\') // 3.1. If the second character is '\'
                        for (int j = 0; j < symbol - '0'; j++)
                        {
                            tempString += inputList[i][position + 2];
                            length = 3;
                        }
                    else if (inputList[i][position + 1] == '\\' & !Char.IsNumber(inputList[i][position + 1]))
                        // 3.2. If the second character is not '\' and a number
                        for (int j = 0; j < symbol - '0'; j++)
                        {
                            tempString += inputList[i][position + 1];
                            length = 2;
                        }
                    else // 3.3. The second and following characters are a number (the number of digits is 2 or more)
                    {
                        length = 0;
                        while (length < inputList[i].Length & Char.IsNumber(inputList[i][position + length]))
                        {
                            length++;
                        }
                        int number_of_digits = Convert.ToInt32(inputList[i].Substring(position, length));
                        for (int j = 0; j < number_of_digits; j++)
                        {
                            tempString += inputList[i][position + length];
                        }
                        length++;
                    }
                    position += length;
                }
            }
            temp_list.Add(tempString);
        }
        return temp_list;
    }
}
