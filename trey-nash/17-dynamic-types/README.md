# Chapter 17: Dynamic Types[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- What does _dynamic_ Mean?
- How Does _dynamic_ Work?
  * The Great Unification
  * Call Sites
  * Objects with Custom Dynamic Behavior
  * Efficiency
  * Boxing with Dynamic
- Dynamic Conversions
  * Implicit Dynamic Expressions Conversion
- Dynamic Overload Resolution
- Dynamic Inheritance
  * You Cannot Derive from _dynamic_
  * You Cannot Implement _dynamic_ Interfaces
  * You Can Derive From Dynamic Base Types
- Duck Typing in C#
- Limitations of _dynamic_ Types
- _ExpandoObject_: Creating Objects Dynamically
- Summary
</details>

## Глава 17. Динамические типы
<details>
  <summary><b>Оглавление</b></summary>

- Что означает динамический?
- Как работает тип _dynamic_?
  * Замечательная унификация
  * Места вызовов
  * Объекты со специальным динамическим поведением
  * Эффективность
  * Упаковка с помощью типа _dynamic_
- Динамические преобразования
  * Неявные преобразования динамических выражений
- Динамическое разрешение перегрузки
- Динамическое наследование
  * Нельзя наследовать от _dynamic_
  * Нельзя реализовывать интерфейсы _dynamic_
  * Возможность наследования от динамических базовых типов
- Утиная типизация в C#
- Ограничения динамических типов
- Динамическое создание объектов с помощью _ExpandoObject_
- Резюме
</details>

---
## About
Chapter 17, “Dynamic Types,”[^1] covers the new dynamic type added in C# 4.0. Along with the
dynamic type comes easier integration with dynamic .NET languages, including COM Automation
objects. Gone are the days of coding unnatural-looking and hard-to-read code purely in efforts to
integrate with these components because the dynamic type implementation handles all of that rote
work for you. The implementation of the dynamic type utilizes the Dynamic Language Runtime (DLR)
which is the same foundation for dynamic languages such as IronRuby and IronPython, among others.
And while using the dynamic type in conjunction with DLR types such as `ExpandoObject`, you can create
and implement truly dynamic types in C#.

## Abstract
Throughout this book, I have emphasized the importance of type and type safety. After all, C# is a
strongly typed language, and you are most effective when you use the C# type system along with the
compiler to eliminate any programming errors early at compile time rather than later at run time.
However, there are some areas where the static, strongly-typed nature of C# creates headaches. Those
areas often involve interoperability. In this chapter, I will introduce you to the `dynamic` type (which is
new in C# 4.0) and discuss what it means from both a language standpoint as well as a runtime standpoint.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [17_dynamic_types](https://github.com/Apress/accelerated-csharp-2010/tree/master/17_dynamic_types)

### References
[^1]: Cite this chapter: [Dynamic Types](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_17) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
