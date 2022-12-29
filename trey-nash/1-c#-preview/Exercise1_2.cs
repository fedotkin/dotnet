namespace Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview;

/// <summary>
/// C# preview
/// </summary>
static class Exercise1_2
{
    /// <summary>
    /// Method for adding data to a string for compression
    /// </summary>
    /// <param name="num"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static string Addition(int num, char sym)
    {
        string temp = "";
        if (sym == '\\') //If character is '\'
        {
            for (int i = 0; i < num; i++) temp = temp + @"\\";
            return temp;
        }
        else if (!Char.IsNumber(sym)) //If character is not a number
            switch (num)
            {
                case 1: return temp + sym;
                case 2: return temp + sym + sym;
                default: return temp + num + sym;
            }
        else if (Char.IsNumber(sym)) //If character is a number
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
    /// <param name="input_list"></param>
    /// <returns></returns>
    public static List<string> Сompression(List<string> input_list)
    {
        List<string> temp_list = new List<string>();
        for (int i = 0; i < input_list.Count; i++) //Compress each line in the list
        {
            int length = 0;          //Number of identical characters
            int position = 0;        //Character position in a string
            char symbol;             //Character in a string
            string temp_string = ""; //Temporary string to write
            while (position < input_list[i].Length)
            {
                symbol = input_list[i][position];
                if (position == input_list[i].Length - 1) //If the character is the last in the string
                {
                    length = 1;
                    temp_string += Addition(length, symbol);
                    break;
                }
                else if (input_list[i][position + 1] != symbol) //If single character
                {
                    length = 1;
                    temp_string += Addition(length, symbol);
                    position += length;
                }
                else //Same symbols
                {
                    for (int j = 1; j < input_list[i].Length - position; j++) //Count the number of identical characters
                    {
                        if (input_list[i][position + j] == symbol) length = j + 1;
                        else break;
                    }
                    temp_string += Addition(length, symbol);
                    position += length;
                }
            }
            temp_list.Add(temp_string);
        }
        return temp_list;
    }

    /// <summary>
    /// Method for unpacking text in a list
    /// </summary>
    /// <param name="input_list"></param>
    /// <returns></returns>
    public static List<string> Decompression(List<string> input_list)
    {
        List<string> temp_list = new List<string>();
        for (int i = 0; i < input_list.Count; i++) //Compress each line in the list
        {
            int length = 0;          //Number of characters
            int position = 0;        //Character position in a string
            char symbol;             //Character in a string
            string temp_string = ""; //Temporary string to write
            while (position < input_list[i].Length)
            {
                symbol = input_list[i][position];
                if (symbol == '\\') //1. If character is '\'
                {
                    if (input_list[i][position + 1] == '\\') //1.1. If the second character is '\'
                        temp_string += '\\';
                    else //1.2. Second character is not '\'
                        temp_string += input_list[i][position + 1];
                    length = 2;
                    position += length;
                }
                else if (symbol != '\\' & !Char.IsNumber(symbol)) //2. If the character is not '\' and a number
                {
                    if (position == input_list[i].Length - 1) //2.1. If the character is the last in the string
                    {
                        temp_string += symbol;
                        break;
                    }
                    else if (input_list[i][position + 1] == symbol) //2.2. If the second character is the same
                    {
                        temp_string = temp_string + symbol + symbol;
                        length = 2;
                    }
                    else //2.3. The second character is not the same
                    {
                        temp_string += symbol;
                        length = 1;
                    }
                    position += length;
                }
                if (Char.IsNumber(symbol)) //3. If character is a number
                {
                    if (input_list[i][position + 1] == '\\') //3.1. If the second character is '\'
                        for (int j = 0; j < symbol - '0'; j++)
                        {
                            temp_string += input_list[i][position + 2];
                            length = 3;
                        }
                    else if (input_list[i][position + 1] == '\\' & !Char.IsNumber(input_list[i][position + 1])) 
                        //3.2. If the second character is not '\' and a number
                        for (int j = 0; j < symbol - '0'; j++)
                        {
                            temp_string += input_list[i][position + 1];
                            length = 2;
                        }
                    else //3.3. The second and following characters are a number (the number of digits is 2 or more)
                    {
                        length = 0;
                        while (length < input_list[i].Length & Char.IsNumber(input_list[i][position + length]))
                        {
                            length++;
                        }
                        int number_of_digits = Convert.ToInt32(input_list[i].Substring(position, length));
                        for (int j = 0; j < number_of_digits; j++)
                        {
                            temp_string += input_list[i][position + length];
                        }
                        length++;
                    }
                    position += length;
                }
            }
            temp_list.Add(temp_string);
        }
        return temp_list;
    }
}
