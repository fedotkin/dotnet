# Chapter 9: Arrays, Collection Types, and Iterators[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Introduction to Arrays
  * Implicitly Typed Arrays
  * Type Convertibility and Covariance
  * Sortability and Searchability
  * Synchronization
  * Vectors vs. Arrays
- Multidimensional Rectangular Arrays
- Multidimensional Jagged Arrays
- Collection Types
  * Comparing _ICollection&lt;T&gt;_ with _ICollection_
  * Collection Synchronization
  * Lists
  * Dictionaries
  * Sets
  * _System.Collections.ObjectModel_
  * Efficiency
- _IEnumerable&lt;T&gt;_, _IEnumerator&lt;T&gt;_, _IEnumerable_, and _IEnumerator_
  * Types That Produce Collections
- Iterators
  * Forward, Reverse, and Bidirectional Iterators
- Collection Initializers
- Summary
</details>

## Глава 9. Массивы, типы коллекций и итераторы	
<details>
  <summary><b>Оглавление</b></summary>

- Представление массивов
  * Неявно типизированные массивы
  * Возможность преобразования и ковариантность
  * Возможности сортировки и поиска
  * Синхронизация
  * Сравнение векторов и массивов
- Многомерные прямоугольные массивы
- Многомерные зубчатые массивы
- Типы коллекций
  * Сравнение _ICollection&lt;T&gt;_ и _ICollection_
  * Синхронизация коллекций
  * Списки
  * Словари
  * Наборы
  * _System.Collections.ObjectModel_
  * Эффективность
- _IEnumerable&lt;T&gt;_, _IEnumerator&lt;T&gt;_, _IEnumerable_ и _IEnumerator_
  * Типы, производящие коллекции
- Итераторы
  * Прямые, обратные и двунаправленные итераторы
- Инициализаторы коллекций
- Резюме
</details>

---
## About
Chapter 9, “Arrays, Collection Types, and Iterators,”[^1] covers the various array and collection types
available in C#. You can create two types of multidimensional arrays, as well as your own collection
types while utilizing collection-utility classes. You’ll see how to define forward, reverse, and bidirectional
iterators using the new iterator syntax introduced in C# 2.0, so that your collection types will work well
with foreach statements.

## Abstract
Collection types have been around in various forms since the dawn of programming. I’m sure you
remember the linked list exercises when you were learning to write programs. In this chapter, I’ll give a
brief overview of arrays but won’t go into much detail, as arrays have not changed much between the
various .NET releases.

&nbsp;&nbsp;&nbsp; However, I’ll spend more time explaining the major generic collection interfaces and iterators along
with what sorts of cool things you can do with them. Traditionally, creating enumerators for collection
types has been tedious and annoying. Iterators make this task a breeze, while making your code a lot
more readable in the process.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [9_arrays_collections](https://github.com/Apress/accelerated-csharp-2010/tree/master/9_arrays_collections)

### References
[^1]: Cite this chapter: [Arrays, Collection Types, and Iterators](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_9) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
