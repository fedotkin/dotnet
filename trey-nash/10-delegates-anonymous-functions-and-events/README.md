# Chapter 10: Delegates, Anonymous Functions, and Events[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Overview of Delegates
- Delegate Creation and Use
  * Single Delegate
  * Delegate Chaining
  * Iterating Through Delegate Chains
  * Unbound (Open Instance) Delegates
- Events
- Anonymous Methods
  * Captured Variables and Closures
  * Beware the Captured Variable Surprise
  * Anonymous Methods as Delegate Parameter Binders
- The _Strategy_ Pattern
- Summary
</details>

## Глава 10. Делегаты, анонимные функции и события
<details>
  <summary><b>Оглавление</b></summary>

- Обзор делегатов
- Создание и использование делегатов
  * Одиночный делегат
  * Цепочки делегатов
  * Итерация по цепочкам делегатов
  * Несвязанный делегаты (делегаты открытого экземпляра)
- События
- Анонимные методы
  * Захваченные переменные и замыкания
  * Остерегайтесь сюрпризов, связанных с захваченными переменными
  * Анонимные методы как привязки параметров делегатов
- Шаблон _Strategy_
- Резюме
</details>

---
## About
Chapter 10, “Delegates, Anonymous Functions, and Events,”[^1] shows you the mechanisms used
within C# to provide callbacks. Historically, all viable frameworks have always provided a mechanism to
implement callbacks. C# goes one step further and encapsulates callbacks into callable objects called
_delegates_. Additionally, C# 2.0 allows you to create delegates with an abbreviated syntax called
_anonymous functions_. Anonymous functions are similar to lambda functions in functional
programming. Also, you’ll see how the framework builds upon delegates to provide a publish/subscribe
event notification mechanism, allowing your design to decouple the source of the event from the
consumer of the event.

## Abstract
Delegates provide a built-in, language-supported mechanism for defining and executing callbacks. Their
flexibility allows you to define the exact signature of the callback, and that information becomes part of
the delegate type. Anonymous functions are forms of delegates that allow you to shortcut some of the
delegate syntax that, in many cases, is overkill and mundane[^2]. Building on top of delegates is the support
for events in C# and the .NET platform. Events provide a uniform pattern for hooking up callback
implementations—and possibly multiple instances thereof—to the code that triggers the callback.

## Source code[^1]
**Repository**[^3] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [10_delegates](https://github.com/Apress/accelerated-csharp-2010/tree/master/10_delegates)

### References
[^1]: Cite this chapter: [Delegates, Anonymous Functions, and Events](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_10) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: Even better than anonymous functions are lambda expressions, which deserve an entire chapter and are covered in 
[Chapter 15](../15-lambda-expressions/).
[^3]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
