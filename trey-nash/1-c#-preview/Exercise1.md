# Exercise 1
## Paint "Hello World!" as ASCII art
Given this code from the **Listing 1-1.** *hello_world.cs*:

```csharp
class EntryPoint {
    static void Main() {
        System.Console.WriteLine( "Hello World!" );
    }
}
```
But this code is static and plain. Let's make it funny and more dynamic via ASCII art paintings!
```
// Hello World!
  ___ ___         .__  .__            __      __            .__       .___._.
 /   |   \   ____ |  | |  |   ____   /  \    /  \___________|  |    __| _/| |
/    ~    \_/ __ \|  | |  |  /  _ \  \   \/\/   /  _ \_  __ \  |   / __ | | |
\    Y    /\  ___/|  |_|  |_(  <_> )  \        (  <_> )  | \/  |__/ /_/ |  \|
 \___|_  /  \___  >____/____/\____/    \__/\  / \____/|__|  |____/\____ |  __
       \/       \/                          \/                         \/  \/
```
If you have not heard about ASCII art, you could look into these online tools:
- [Text to ASCII Art Generator](http://patorjk.com/software/taag/) | [patorjk](https://patorjk.com/)
  > Create text art from words.
  Use this [link](http://patorjk.com/software/taag/#p=display&f=Graffiti&t=Hello%20World!) to paint the ["Hello World!"](http://patorjk.com/software/taag/#p=display&f=Graffiti&t=Hello%20World!) text.
- [Interactive ASCII Text Generator](https://ascii.co.uk/text) | [ascii.co.uk](https://ascii.co.uk/)
  > Type in the above box to generate ASCII Art Text on the fly!
  Note this online tool cannot print special characters like '@', '#', '$', etc.

## Tasks
1. Generate 1st "Hello World" art, save to a text file.
  Read the art from the file and print it to the console.
2. Generate 2nd "Hello World" art. Compress it to a string stream by the rule: `AAA` -> `3A`.
  Decompress the art and print it to the console.

Paint a beautiful version of "Hello World!" which you like via some favourite font.
The painted art should be at least 5 lines in height! Bigger is better.

### Task #1 notes
You need to keep the art in text file. Open the text file as text file stream and redirect text stream to the console. 
And that's it! More about .NET `System.IO` streams here:
[Stream Class](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-7.0)
The task implementation requires usage of [TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter?view=net-7.0) 
and [TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader?view=net-7.0).

### Task #2 notes
In this task you need to keep the art in compressed version of text. Text should be located either in a file or embedded as string data right in C# code. Choose the preferred way of data storing.
There are 3 major steps of implementation:
- Paint the art and keep somewhere, for example in C# code.
- Design compression algorithm via applying compressing rules, see below.
- Compress text data manually or programmatically.
- Design decompression algorithm via the rules, see below.
- Decompress text data programmatically, not manually!
- Print decompressed text of the art to the console.

### Compression rules
1. Count the similar character and remember the cursor.
2. Don't count characters which don't repeat! 
3. Replace repeating character block, like `AAA` -> `3A`.
4. Compressed data consist of pairs (length, char). So, (5, 'b') means "5b" in the stream.
5. Digit chars must be escaped via backslash `\`, like `A b 1 22 333` -> `A b \1 2\2 3\3`
6. Repeating chars of length 3 and longer must be compressed, like `a aa aaa` -> `a aa 3a`
7. Non-repeating chars of length 1 should be skipped and just ignored, like `A BB C` -> `A 2B C`
8. Escape backslash char, like `\` -> `\\` and `\ \\ \\\` -> `\\ \\\\ \\\\\\`

Compression examples:
- "Aaaa bb" -> "A3a 2b"
- "Time: 12:22" -> "Time: \1\2:2\2"
- "Number: 1223334444.55555000" -> "Number: \12\23\34\4.5\53\0"
- "d8YaaaaY8b" -> "d\8Y4aY\8b"
- ">===>" -> ">3=>"
- "1\22\\333\\\" -> "\1\\2\2\\\\3\3\\\\\\"

### Dompression rules
In general, these rules are negative version of the compressing rules. But decompression algorithm should convert back short compressed blocks, and remove backslash for digital char blocks.
- Convert back compressed block as pair (length, char) to repeated chars block, like `3A` -> `AAA`.
- Convert back compressed digital block as pair (length, \digit) to repeated digit block, like `\1 \2\2 3\3` -> `1 22 333`.
- Remove backslash for escaped backslash char, like `\\` -> `\`.


Decompression examples:
- "A3a 2b" -> "Aaaa bb"
- "Time: \1\2:2\2" -> "Time: 12:22"
- "Number: \12\23\34\4.5\53\0" -> "Number: 1223334444.55555000"
- "d\8Y4aY\8b" -> "d8YaaaaY8b"
- ">3=>" -> ">===>"
- "\1\\2\2\\\\3\3\\\\\\" -> "1\22\\333\\\"

### Real example of compression
Given this art of "C#" text:
```
        CCCCCCCCCCCCC                          |
     CCC::::::::::::C     ######    ######     |
   CC:::::::::::::::C     #::::#    #::::#     |
  C:::::CCCCCCCC::::C     #::::#    #::::#     |
 C:::::C       CCCCCC######::::######::::######|
C:::::C              #::::::::::::::::::::::::#|
C:::::C              ######::::######::::######|
C:::::C                   #::::#    #::::#     |
C:::::C                   #::::#    #::::#     |
C:::::C              ######::::######::::######|
C:::::C              #::::::::::::::::::::::::#|
 C:::::C       CCCCCC######::::######::::######|
  C:::::CCCCCCCC::::C     #::::#    #::::#     |
   CC:::::::::::::::C     #::::#    #::::#     |
     CCC::::::::::::C     ######    ######     |
        CCCCCCCCCCCCC                          |
```
So, the compression algorithm produces:
```
8 13C26 |
5 3C12:C5 6#4 6#5 |
3 2C15:C5 #4:#4 #4:#5 |
  C5:8C4:C5 #4:#4 #4:#5 |
 C5:C7 6C6#4:6#4:6#|
C5:C14 #24:#|
C5:C14 6#4:6#4:6#|
C5:C19 #4:#4 #4:#5 |
C5:C19 #4:#4 #4:#5 |
C5:C14 6#4:6#4:6#|
C5:C14 #24:#|
 C5:C7 6C6#4:6#4:6#|
  C5:8C4:C5 #4:#4 #4:#5 |
3 CC15:C5 #4:#4 #4:#5 |
5 3C12:C5 6#4 6#5 |
8 13C26 |
```
Note '|' char is new line symbol aka '\n'.
