# Chapter 8: Working with Strings[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- _String_ Overview
- String Literals
- Format Specifiers and Globalization
  * _Object.ToString_, _IFormattable_, and _CultureInfo_
  * Creating and Registering Custom _CultureInfo_ Types
  * Format Strings
  * _Console.WriteLine_ and _String.Format_
  * Examples of String Formatting in Custom Types
  * _ICustomFormatter_
  * Comparing Strings
- Working with Strings from Outside Sources
- _StringBuilder_
- Searching Strings with Regular Expressions
  * Searching with Regular Expressions
  * Searching and Grouping
  * Replacing Text with _Regex_
  * _Regex_ Creation Options
- Summary
</details>

## Глава 8. Работа со строками
<details>
  <summary><b>Оглавление</b></summary>

- Обзор _String_
- Строковые литералы
- Спецификаторы формата и глобализация
  * _Object.ToString_, _IFormattable_ и _CultureInfo_
  * Создание и регистрация пользовательских типов _CultureInfo_
  * Форматные строки
  * _Console.WriteLine_ и _String.Format_
  * Примеры строкового форматирования в пользовательских типах
  * _ICustomFormatter_
  * Сравнение строк
- Работа со строками из внешних источников
- _StringBuilder_
- Поиск строк с помощью регулярных выражений
  * Поиск с помощью регулярных выражений
  * Поиск и группирование
  * Замена текста с помощью _Regex_
  * Варианты создания _Regex_
- Резюме
</details>

---
## About
Chapter 8, “Working with Strings,”[^1] describes how strings are a first-class type in the CLR and how to
use them effectively in C#. A large portion of the chapter covers the string-formatting capabilities of
various types in the .NET Framework and how to make your defined types behave similarly by
implementing `IFormattable`. Additionally, I introduce you to the globalization capabilities of the
framework and how to create custom `CultureInfo` for cultures and regions that the .NET Framework
doesn’t already know about.

## Abstract
Within the .NET Framework base class library, the `System.String` type is the model citizen of how to
create an immutable reference type that semantically acts like a value type.

<details>
  <summary><h3>String Overview</h3></summary>

Instances of `String` are immutable in the sense that once you create them, you cannot change them.
Although it may seem inefficient at first, this approach actually does make code more efficient. If you call
the `ICloneable.Clone` method on a string, you get an instance that points to the same string data as the
source. In fact, `ICloneable.Clone` simply returns a reference to `this`. This is entirely safe because the
`String` public interface offers no way to modify the actual `String` data. Sure, you can subvert the system
by employing unsafe code trickery, but I trust you wouldn’t want to do such a thing. In fact, if you
require a string that is a deep copy of the original string, you may call the `Copy` method to do so.

##
:notebook: **Note** Those of you who are familiar with common design patterns and idioms may recognize this usage pattern
as the handle/body or envelope/letter idiom. In C++, you typically implement this idiom when designing reference-based 
types that you can pass by value. Many C++ standard library implementations implement the standard
string this way. However, in C#’s garbage-collected heap, you don’t have to worry about maintaining reference
counts on the underlying data.

##
&nbsp;&nbsp;&nbsp; In many environments, such as C++ and C, the string is not usually a built-in type at all, but rather a
more primitive, raw construct, such as a pointer to the first character in an array of characters. Typically,
string-manipulation routines are not part of the language but rather a part of a library used with the
language. Although that is mostly true with C#, the lines are somewhat blurred by the .NET runtime. The
designers of the CLI specification could have chosen to represent all strings as simple arrays of
`System.Char` types, but they chose to annex `System.String` into the collection of built-in types instead. In
fact, `System.String` is an oddball in the built-in type collection, because it is a reference type and most of
the built-in types are value types. However, this difference is blurred by the fact that the `String` type
behaves with value semantics.

&nbsp;&nbsp;&nbsp; You may already know that the `System.String` type represents a Unicode character string, and
`System.Char` represents a 16-bit Unicode character. Of course, this makes portability and localization to
other operating systems—especially systems with large character sets—easy. However, sometimes you
might need to interface with external systems using encodings other than UTF-16 Unicode character
strings. For times like these, you can employ the `System.Text.Encoding` class to convert to and from
various encodings, including ASCII, UTF-7, UTF-8, and UTF-32. Incidentally, the Unicode format used
internally by the runtime is UTF-16.[^2]
</details>

## Source code[^1]
**Repository**[^3] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [8_strings](https://github.com/Apress/accelerated-csharp-2010/tree/master/8_strings)

### References
[^1]: Cite this chapter: [Working with Strings](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_8) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: For more information regarding the Unicode standard, visit [www.unicode.org](https://home.unicode.org/).
[^3]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
