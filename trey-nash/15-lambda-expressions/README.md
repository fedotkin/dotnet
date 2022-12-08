# Chapter 15: Lambda Expressions[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Introduction to Lambda Expressions
  * Lambda Expressions and Closures
    * Closures in C# 1.0
    * Closures in C# 2.0
  * Lambda Statements
- Expression Trees
  * Operating on Expressions
  * Functions as Data
- Useful Applications of Lambda Expressions
  * Iterators and Generators Revisited
  * More on Closures (Variable Capture) and Memoization
  * Currying
  * Anonymous Recursion
- Summary
</details>

## Глава 15. Лямбда-выражения
<details>
  <summary><b>Оглавление</b></summary>

- Введение в лямбда-выражения
  * Лямбда-выражения и замыкания
  * Замыкания в C# 1.0
  * Замыкания в C# 2.0
  * Лямбда-операторы
- Деревья выражений
  * Операции над выражениями
  * Функции как данные
- Полезные применения лямбда-выражений
  * Вернёмся к итераторам и генераторам
  * Замыкание (захват переменной) и мемоизация
  * Каррирование
  * Анонимная рекурсия
- Резюме
</details>

---
## About
Chapter 15, “Lambda Expressions,”[^1] are another feature added to C# 3.0. You can declare and
instantiate delegates using lambda expressions using a syntax that is brief and visually descriptive.
Although anonymous functions can serve the same purpose just mentioned, they are much more
verbose and less syntactically elegant. However, in C# 3.0 and beyond, you can convert lambda
expressions into expression trees. That is, the language has a built-in capability to convert code into data
structures. By itself, this capability is useful, but not nearly as useful as when coupled with Language
Integrated Query (LINQ). Lambda expressions, coupled with extension methods, really bring functional
programming full circle in C#.

## Abstract
Most of the new features of C# 3.0 opened up a world of expressive functional programming to the C#
programmer. Functional programming, in its pure form, is a programming methodology built on top of
immutable variables (sometimes called _symbols_), functions that can produce other functions, and
recursion, just to name a few of its foundations. Some prominent functional programming languages
include Lisp, Haskell, F#,[^2] and Scheme.[^3] However, functional programming does not require a pure
functional language, and one can use and implement functional programming disciplines in
traditionally imperative languages such as the C-based languages (including C#). The features added in
C# 3.0 transformed the language into a more expressive hybrid language in which both imperative and
functional programming techniques can be utilized in harmony. Lambda expressions are arguably the
biggest piece of this functional programming pie.

## Source code[^1]
**Repository**[^4] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [15_lambda_expressions](https://github.com/Apress/accelerated-csharp-2010/tree/master/15_lambda_expressions)

### References
[^1]: Cite this chapter: [Lambda Expressions](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_15) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: F# is an exciting new functional programming language for the .NET Framework. For more information, I invite you
to read Robert Pickering’s [_Foundations of F#_](https://link.springer.com/book/10.1007/978-1-4302-0358-2) 
(Berkeley, CA: [Apress](https://www.apress.com/), 2007). 
[Amazon](https://www.amazon.com/Foundations-F-Experts-Voice-NET/dp/1590597575) 
[Google](https://books.google.com/books?id=6r1q589XwZMC)
[^3]: One of the languages that I use often is C++. Those of you that are familiar with metaprogramming in C++ are
definitely familiar with functional programming techniques. If you do use C++ and you’re curious about
metaprogramming, I invite you to check out David Abrahams’ and Alexey Gurtovoy’s most excellent book 
[_C++ Template Metaprogramming_](https://www.pearson.com/store/p/c-template-metaprogramming-concepts-tools-and-techniques-from-boost-and-beyond/P200000009140/9780321227256) 
(Boston: [Addison-Wesley Professional](https://en.wikipedia.org/wiki/Addison-Wesley), 2004). 
[Amazon](https://www.amazon.com/Template-Metaprogramming-Concepts-Techniques-Beyond/dp/0321227255) 
[Google](https://books.google.com/books?id=wbNQAAAAMAAJ)
[^4]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
