# The 'dotnet' Lab: .NET, C#

<img src="../assets/dotnet-logo.svg?raw=true" height="100" alt=".NET Logo" />&nbsp;&nbsp;&nbsp;<img src="../assets/csharp-logo.png?raw=true" height="100" alt="C# Logo" />

## About
Learning laboratory for .NET Framework and C# language. Researches, books, coding challenges, small projects.

## What is .NET Framework?[^1]
**.NET Framework is a software development framework for building and running applications on Windows.**

**.NET Framework is part of the .NET platform, a collection of technologies for building apps 
for Linux, macOS, Windows, iOS, Android, and more.**

### .NET and .NET Framework
[.NET is a developer platform](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet) 
made up of [tools](https://dotnet.microsoft.com/en-us/platform/tools), 
[programming languages](https://dotnet.microsoft.com/en-us/languages), 
and libraries for building many different types of applications.

There are various implementations of .NET. Each implementation allows .NET code to execute in 
different places — Linux, macOS, Windows, iOS, Android, and many more.

1. **.NET Framework** is the original implementation of .NET. 
It supports running websites, services, desktop apps, and more on Windows.
2. **.NET** is a cross-platform implementation for running websites, services, and console apps 
on Windows, Linux, and macOS. 
[.NET is open source](https://dotnet.microsoft.com/en-us/platform/open-source) on GitHub. 
.NET was previously called .NET Core.
3. [**Xamarin/Mono**](https://dotnet.microsoft.com/en-us/learn/xamarin/what-is-xamarin) 
is a .NET implementation for running apps on all the major mobile operating systems, including iOS and Android.

[.NET Standard](https://dotnet.microsoft.com/en-us/platform/dotnet-standard) 
is a formal specification of the APIs that are common across .NET implementations. 
This allows the same code and libraries to run on different implementations.

## A tour of the C# language[^2]
C# (pronounced "See Sharp") is a modern, object-oriented, and type-safe programming language. 
C# enables developers to build many types of secure and robust applications that run in .NET. 
C# has its roots in the C family of languages and will be immediately familiar 
to C, C++, Java, and JavaScript programmers. 
This tour provides an overview of the major components of the language in C# 11 and earlier. 
If you want to explore the language through interactive examples, try the 
[introduction to C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/) tutorials.

C# is an object-oriented, ***component-oriented*** programming language. 
C# provides language constructs to directly support these concepts, 
making C# a natural language in which to create and use software components. 
Since its origin, C# has added features to support new workloads and emerging software design practices. 
At its core, C# is an ***object-oriented*** language. You define types and their behavior.

Several C# features help create robust and durable applications. 
[***Garbage collection***](https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/) 
automatically reclaims memory occupied by unreachable unused objects. 
[***Nullable types***](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references) 
guard against variables that don't refer to allocated objects. 
[***Exception handling***](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/) 
provides a structured and extensible approach to error detection and recovery. 
[***Lambda expressions***](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions) 
support functional programming techniques. 
[***Language Integrated Query (LINQ)***](https://learn.microsoft.com/en-us/dotnet/csharp/linq/) 
syntax creates a common pattern for working with data from any source. Language support for 
[***asynchronous operations***](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) 
provides syntax for building distributed systems. C# has a 
[***unified type system***](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/). 
All C# types, including primitive types such as `int` and `double`, inherit from a single root `object` type. 
All types share a set of common operations. Values of any type can be stored, transported, 
and operated upon in a consistent manner. 
Furthermore, C# supports both user-defined 
[reference types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types) and 
[value types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types). 
C# allows dynamic allocation of objects and in-line storage of lightweight structures. 
C# supports generic methods and types, which provide increased type safety and performance. 
C# provides iterators, which enable implementers of collection classes to define custom behaviors for client code.
<details>
   <summary>...</summary>

C# emphasizes ***versioning*** to ensure programs and libraries can evolve over time in a compatible manner. 
  Aspects of C#'s design that were directly influenced by versioning considerations include the separate 
  `virtual` and `override` modifiers, the rules for method overload resolution, 
  and support for explicit interface member declarations.
</details>

## C# documentation[^3]
Learn how to write any application using the C# programming language on the .NET platform.

## References
[^1]: [What is .NET Framework? | Microsoft](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet-framework)
[^2]: [A tour of the C# language | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)
[^3]: [C# docs - get started, tutorials, reference | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/)
