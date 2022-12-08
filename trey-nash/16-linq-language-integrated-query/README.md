# Chapter 16: LINQ: Language Integrated Query[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- A Bridge to Data
  * Query Expressions
  * Extension Methods and Lambda Expressions Revisited
- Standard Query Operators
- C# Query Keywords
  * The _from_ Clause and Range Variables
  * The _join_ Clause
  * The _where_ Clause and Filters
  * The _orderby_ Clause
  * The _select_ Clause and Projection
  * The _let_ Clause
  * The _group_ Clause
  * The _into_ Clause and Continuations
- The Virtues of Being Lazy
  * C# Iterators Foster Laziness
  * Subverting Laziness
  * Executing Queries Immediately
  * Expression Trees Revisited
- Techniques from Functional Programming
  * Custom Standard Query Operators and Lazy Evaluation
  * Replacing _foreach_ Statements
- Summary
</details>

## Глава 16. LINQ: язык интегрированных запросов
<details>
  <summary><b>Оглавление</b></summary>

- Мост к данным
  * Выражения запросов
  * Вернёмся к расширяющим методам и лямбда-выражениям
- Стандартные операции запросов
- Ключевые слова запросов C#
  * Конструкция _from_ и переменные диапазона
  * Конструкция _join_
  * Конструкция _where_ и фильтры
  * Конструкция _orderby_
  * Конструкция _select_ и проекция
  * Конструкция _let_
  * Конструкция _group_
  * Конструкция _into_ и продолжение
- Преимущества лени
  * Поощрение лени операторами C#
  * Ниспровержение лени
  * Немедленное выполнение запросов
  * Ещё раз о деревьях выражений
- Приёмы функционального программирования
  * Пользовательские стандартные операции запросов и "ленивое" вычисление
  * Замена операторов _foreach_
- Резюме
</details>

---
## About
Chapter 16, “LINQ: Language Integrated Query,”[^1] is the culmination of all of the new features added
to C# 3.0. Using LINQ expressions via the LINQ-oriented keywords, you can seamlessly integrate data
queries into your code. LINQ forms a bridge between the typically imperative programming world of C#
programming and the functional programming world of data query. LINQ expressions can be used to
manipulate normal objects as well as data originating from SQL databases, Datasets, and XML just to
name a few.

## Abstract
C-style languages (including C#) are imperative in nature, meaning that the emphasis is placed on the
state of the system, and changes are made to that state over time. Data-acquisition languages such as
SQL are functional in nature, meaning that the emphasis is placed on the operation and there is little or
no mutable data used during the process. LINQ bridges the gap between the imperative programming
style and the functional programming style. LINQ is a huge topic that deserves entire books devoted to it
and what you can do with LINQ.[^2] There are several implementations of LINQ readily available: LINQ to
Objects, LINQ to SQL, LINQ to Dataset, LINQ to Entities, and LINQ to XML. I will be focusing on LINQ to
Objects because I’ll be able to get the LINQ message across without having to incorporate extra layers
and technologies.

##
:notebook: **Note** Development for LINQ started some time ago at Microsoft and was born out of the efforts of Anders
Hejlsberg and Peter Golde. The idea was to create a more natural and language-integrated way to access data
from within a language such as C#. However, at the same time, it was undesirable to implement it in such a way
that it would destabilize the implementation of the C# compiler and become too cumbersome for the language. As
it turns out, it made sense to implement some building blocks in the language in order to provide the functionality
and expressiveness of LINQ. Thus we have features like lambda expressions, anonymous types, extension
methods, and implicitly typed variables. All are excellent features in themselves, but arguably were precipitated by LINQ.

##
&nbsp;&nbsp;&nbsp; LINQ does a very good job of allowing the programmer to focus on the business logic while
spending less time coding up the mundane plumbing that is normally associated with data access code.
If you have experience building data-aware applications, think about how many times you have found
yourself coding up the same type of boilerplate code over and over again. LINQ removes some of that burden.

## Source code[^1]
**Repository**[^3] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [16_linq](https://github.com/Apress/accelerated-csharp-2010/tree/master/16_linq)

### References
[^1]: Cite this chapter: [LINQ: Language Integrated Query](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_16) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: For more extensive coverage of LINQ, I suggest you check out [_Foundations of LINQ in C#_](https://link.springer.com/book/10.1007/978-1-4302-0382-7), 
by Joseph C. Rattz, Jr. ([Apress](https://www.apress.com/), 2007). 
[Amazon](https://www.amazon.com/-/en/Joseph-C-Rattz-Jr/dp/1590597893)
[^3]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
