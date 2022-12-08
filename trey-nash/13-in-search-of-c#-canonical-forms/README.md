# Chapter 13: In Search of C# Canonical Forms[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Reference Type Canonical Forms
  * Default to sealed Classes
  * Use the Non-Virtual Interface (NVI) Pattern
  * Is the _Object_ Cloneable?
  * Is the _Object_ Disposable?
  * Does the Object Need a Finalizer?
  * What Does Equality Mean for This _Object_?
    * Reference Types and Identity Equality
    * Value Equality
    * Overriding _Object.Equals_ for Reference Types
  * If You Override _Equals_, Override _GetHashCode_ Too
  * Does the _Object_ Support Ordering?
  * Is the _Object_ Formattable?
  * Is the _Object_ Convertible?
  * Prefer Type Safety at All Times
  * Using Immutable Reference Types
- Value Type Canonical Forms
  * Override _Equals_ for Better Performance
  * Do Values of This Type Support Any Interfaces?
  * Implement Type-Safe Forms of Interface Members and Derived Methods
- Summary
  * Checklist for Reference Types
  * Checklist for Value Types
</details>

## Глава 13. В поисках канонических форм C#
<details>
  <summary><b>Оглавление</b></summary>

- Канонические формы ссылочных типов
  * Классы должны помечаться как _sealed_ по умолчанию
  * Использование шаблона NVI
  * Является ли _Object_ клонируемым?
  * Является ли _Object_ одноразовым?
  * Нужен ли финализатор для _Object_?
  * Что означает эквивалентность для данного _Object_?
  * Ссылочные типы и эквивалентность идентичности
  * Эквивалентность значений
  * Переопределение _Object.Equals_ для ссылочных типов
  * Если переопределён метод _Equals_, то необходимо переопределить и _GetHashCode_
  * Поддерживает ли объект упорядочивание?
  * Является ли _Object_ форматируемым?
  * Является ли _Object_ преобразуемым?
  * Всегда отдавайте предпочтение безопастности типов
  * Использование неизменяемых ссылочных типов
- Канонические формы типов значений
  * Переопределение _Equals_ для повышения производительности
  * Поддерживают ли значения этого типа какие-то интерфейсы?
  * Реализация безопастных к типам версий для членов интерфейса и унаследованных методов
- Резюме
  * Список вопросов для ссылочных типов
  * Список вопросов для типов значений
</details>

---
## About
Chapter 13, “In Search of C# Canonical Forms,”[^1] is a dissertation on the best design practices for
defining new types and how to make them so you can use them naturally and so consumers won’t abuse
them inadvertently. I touch upon some of these topics in other chapters, but I discuss them in detail in
this chapter. This chapter concludes with a checklist of items to consider when defining new types using C#.

## Abstract
Many object-oriented languages—C# included—don’t offer anything to force developers to create well-designed 
software. There is no better example of this than when using C++ to implement an OO design.
C# is a little more structured than C++; for example, you cannot create free static functions that exist
outside the context of a defined type. Still, C# doesn’t force you to create software that adheres to well-known 
practices of good software design. 

&nbsp;&nbsp;&nbsp; The C++ community quickly identified some canonical forms useful for designing types to meet a
specific purpose. Really and truly, these canonical forms are merely checklists, or recipes, you can use
while designing new classes. Before a pilot can clear an airplane to back out of the gate, he must go
through a strict checklist. The goal of this chapter is to identify such checklists for creating robust types
in the C# world.

&nbsp;&nbsp;&nbsp; When you explore these checklists, you need to consider what sorts of behaviors are required of
objects of the new type you’re creating. For example, is your new type going to be cloneable? In other
words, can it be copied? If instances of your new type are placed in a collection, can they be ordered?
What does it mean to compare two references of this object’s type for equality? In other words, do you
want to know if the two references refer to the same instance? Or do you want to know if two instances
referred to have exactly the same state? These are the types of questions you should ask yourself when
you create a new type.

##
:notebook: **Note** This chapter is rather long, but it’s important to keep so much useful and related information together.
Overall, the chapter is sectioned into two partitions. The first partition covers reference types, and the second
covers value types. I cover reference types first and at greater length, because some material applies to both
reference types and value types. Finally, the chapter concludes with a pair of checklists to go through when
designing new types.
##

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [13_canonical_forms](https://github.com/Apress/accelerated-csharp-2010/tree/master/13_canonical_forms)

### References
[^1]: Cite this chapter: [In Search of C# Canonical Forms](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_13) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
