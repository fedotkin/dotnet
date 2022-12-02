# Chapter 14: Extension Methods[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Introduction to Extension Methods
  * How Does the Compiler Find Extension Methods?
  * Under the Covers
  * Code Readability versus Code Understandability
- Recommendations for Use
  * Consider Extension Methods Over Inheritance
  * Isolate Extension Methods in Separate Namespace
  * Changing a Type’s Contract Can Break Extension Methods
- Transforms
- Operation Chaining
- Custom Iterators
  * Borrowing from Functional Programming
- The Visitor Pattern
- Summary
</details>

## Глава 14. Расширяющие методы
<details>
  <summary><b>Оглавление</b></summary>

- Введение в расширяющие методы
  * Как компилятор находит расширяющие методы?
  * Что происходит "за кулисами"
  * Читабельность или понятность кода
- Рекомендации по использованию
  * Использование расширяющих методов вместо наследования
  * Изоляция расширяющих методов в отдельном пространстве имён
  * Изменение контракта типа может нарушить работу расширяющих методов
- Трансформации
- Цепочки операций
- Пользовательские итераторы
  * Заимствование из фукнционального программирования
- Шаблон Visitor
- Резюме
</details>

---
## About
Chapter 14, “Extension Methods,”[^1] are new since C# 3.0. Because you can invoke them like instance
methods on a type they extend, they can appear to augment the contract of types. But they are much
more than that. In this chapter, I show you how extension methods can begin to open up the world of
functional programming in C#.

## Abstract
Using extension methods, you can declare methods that appear to augment the public interface, or
contract, of a type. At first glance, they may appear to provide a way to extend classes that are not meant
to be extended. However, it’s very important to note that extension methods cannot break
encapsulation. That’s because they’re not really instance methods at all and thus cannot crack the shell
of encapsulation on the type they are extending.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [14_extension_methods](https://github.com/Apress/accelerated-csharp-2010/tree/master/14_extension_methods)

### References
[^1]: Cite this chapter: [Extension Methods](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_14) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
