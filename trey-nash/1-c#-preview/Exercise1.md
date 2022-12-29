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
But this code is static and plain. Let's make it funny and more dynamic via ASCII art paintings:
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
#### [Text to ASCII Art Generator](http://patorjk.com/software/taag/) | [patorjk](https://patorjk.com/)
> **Create text art from words.** <br/>
> Use this [link](http://patorjk.com/software/taag/#p=display&f=Graffiti&t=Hello%20World!) to paint the ["Hello World!"](http://patorjk.com/software/taag/#p=display&f=Graffiti&t=Hello%20World!) text.

#### [Interactive ASCII Text Generator](https://ascii.co.uk/text) | [ascii.co.uk](https://ascii.co.uk/)
> **Type in the above box to generate ASCII Art Text on the fly!** <br/>
> Note this online tool cannot print special characters like '@', '#', '$', etc.

## Tasks
1. Generate 1st "Hello World" art, save to a text file.
  Read the art from the file and print it to the console.
2. Generate 2nd "Hello World" art. Compress it to a string stream by the rule: `AAA` -> `3A`.
  Decompress the art and print it to the console.

Paint a beautiful version of "Hello World!" which you like via some favourite font.
The painted art should be at least 5 lines in height! Bigger is better.

### Task #1 notes
You need to keep the art in text file. Open the text file as text file stream and redirect text stream to the console. And that's it!
<br/>More about .NET `System.IO` streams here: 
[Stream Class](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-7.0)
<br/>The task implementation requires usage of [TextWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter?view=net-7.0) 
and [TextReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.textreader?view=net-7.0).

### Task #2 notes
In this task you need to keep the art in compressed version of text. Text should be located either in a file or embedded as string data right in C# code. Choose the preferred way of data storing.
<br/>The major steps of implementation are:
- Paint the art and keep somewhere, for example in C# code.
- Design compression algorithm via applying compressing rules, see below.
- Compress text data manually or programmatically.
- Design decompression algorithm via the rules, see below.
- Decompress text data programmatically, not manually!
- Print decompressed text of the art to the console.

### Compression rules
1. Count the similar character and remember the cursor.
2. Don't count characters which don't repeat! 
3. Replace repeating character block, like `AAA` -> `3A`. Compressed data consist of pairs `(length, char)`. For example, `(5, 'B')` means `5B` in the output stream.
4. Repeating chars of length 3 and longer must be compressed, like `a aa aaa` -> `a aa 3a`.
5. Non-repeating chars of length 1 or 2 should be skipped and just ignored, like `A BB CCC` -> `A BB 3C`.
6. Digit chars must be escaped via backslash `\`, like `A b 123 12:20 c` -> `A b \1\2\3 \1\2:\2\0 c` because we use numbers in compressed stream (see the main rule #3).
7. Repeating digit-chars of length 2 and longer must be compressed, like `333 4444` -> `3\3 4\4`. Note that `22` -> `2\2`, not `\2\2` as the rule #6 requires. Escaped `\2\2` of 4 chars is longer in output stream and it should be compressed to 3 char block, like `2\2`. Finally, `22 33 44` -> `2\2 2\3 2\4`.
8. Escape backslash char, like `\` -> `\\` and `\ \\ \\\` -> `\\ \\\\ \\\\\\`

Compression examples:
- `AAAA aaa bb b` -> `4A 3a bb b`
- `Time: 12:25` -> `Time: \1\2:\2\5`
- `Number: 1223334444.55555000` -> `Number: \12\23\34\4.5\53\0`
- `d8YaaaaY8b` -> `d\8Y4aY\8b`
- `>===>` -> `>3=>`
- `1\22\\333\\\` -> `\1\\2\2\\\\3\3\\\\\\`

### Decompression rules
In general, these rules are negative version of the compressing rules. But decompression algorithm should 
convert back short compressed blocks, and remove backslash for digital char blocks.
1. Convert back compressed block as pair (length, char) to repeated chars block, like `3A` -> `AAA`.
2. Convert back compressed digital block as pair (length, \digit) to repeated digit block, like `\1 2\2 3\3` -> `1 22 333`.
3. Remove backslash for escaped backslash char, like `\\` -> `\`.

Decompression examples:
- `A3a bb c` -> `Aaaa bb c`
- `Time: \1\2:\2\0` -> `Time: 12:20`
- `Number: \12\23\34\4.5\53\0` -> `Number: 1223334444.55555000`
- `d\8Y4aY\8b` -> `d8YaaaaY8b`
- `>3=>` -> `>===>`
- `\1\\2\2\\\\3\3\\\\\\` -> `1\22\\333\\\`

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
Note the '|' char is new line symbol aka '\n'.