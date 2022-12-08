# Chapter 7: Exception Handling and Exception Safety[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- How the CLR Treats Exceptions
- Mechanics of Handling Exceptions in C#
  * Throwing Exceptions
  * Changes with Unhandled Exceptions Starting with .NET 2.0
  * Syntax Overview of the **try**, **catch**, and **finally** Statements
  * Rethrowing Exceptions and Translating Exceptions
  * Exceptions Thrown in **finally** Blocks
  * Exceptions Thrown in Finalizers
  * Exceptions Thrown in Static Constructors
- Who Should Handle Exceptions?
- Avoid Using Exceptions to Control Flow
- Achieving Exception Neutrality
  * Basic Structure of Exception-Neutral Code
  * Constrained Execution Regions
  * Critical Finalizers and **SafeHandle**
- Creating Custom Exception Classes
- Working with Allocated Resources and Exceptions
- Providing Rollback Behavior
- Summary
</details>

## Глава 7. Безопасность и обработка исключений
<details>
  <summary><b>Оглавление</b></summary>

- Как CLR трактует исключения
- Механизм обработки исключений в C#
  * Генерация исключений
  * Изменения, касающиеся необработанных исключений, которые появились в .NET 2.0
  * Обзор синтаксиса операторов **try**, **catch** и **finally**
  * Повторная генерация и трансляция исключений
  * Исключения, сгенерированные в блоке **finally**
  * Исключения, сгенерированные в финализаторах
  * Исключения, сгенерированные в статических конструкторах
- Кто должен обрабатывать исключения?
- Избегайте применения исключений для управления потоком выполнения
- Обеспечение нейтральности к исключениям
  * Базовая структура нейтрального к исключениям кода
  * Ограниченные области выполнения
  * Критические финализаторы и **SafeHandle**
- Создание пользовательских классов исключений
- Работа с выделенными ресурсами и исключениями
- Обеспечение поведения отката
- Резюме
</details>

---
## About
Chapter 7, “Exception Handling and Exception Safety,”[^1] shows you the exception-handling
capabilities of the C# language and the CLR. Although the syntax is similar to that of C++, creating
exception-safe and exception-neutral code is tricky—even more tricky than creating exception-safe code
in native C++. You’ll see that creating fault-tolerant, exception-safe code doesn’t require the use of `try`,
`catch`, or `finally` constructs at all. I also describe some of the new capabilities added with the .NET 2.0
runtime that allow you to create more fault-tolerant code.

## Abstract
The CLR contains strong support for exceptions. Exceptions can be created and thrown at a point where
code execution cannot continue because of some exceptional condition (usually a method failure or an
invalid state). Writing exception-safe code is a difficult art to master. It would be a mistake to assume
that the only tasks required when writing exception-safe code are simply throwing exceptions when an
error occurs and catching them at some point. Such a view of exception-safe code is shortsighted and
will lead you down a path of despair. Instead, exception-safe coding means guaranteeing the integrity of
the system in the face of exceptions. When an exception is thrown, the runtime will iteratively unwind
the stack while cleaning up. Your job as an exception-safe programmer is to structure your code in such
a way that the integrity of the state of your objects is not compromised as the stack unwinds. That is the
true essence of exception-safe coding techniques.

&nbsp;&nbsp;&nbsp; In this chapter, I will show you how the CLR handles exceptions and the mechanics involved with
handling exceptions. However, there is more to exception handling than just that. For example, I’ll
describe which areas of code should handle exceptions as well as pitfalls to avoid when implementing
exception handling. Most importantly, I will show you how writing exception-safe code may not even
involve handling exceptions at all. Such code is typically called _exception-neutral_ code. It may sound
surprising, but read on for all of the details.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [7_exception_safety](https://github.com/Apress/accelerated-csharp-2010/tree/master/7_exception_safety)

### References
[^1]: Cite this chapter: [Exception Handling and Exception Safety](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_7) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
