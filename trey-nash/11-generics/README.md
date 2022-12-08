# Chapter 11: Generics[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Difference Between Generics and C++ Templates
- Efficiency and Type Safety of Generics
- Generic Type Definitions and Constructed Types
  * Generic Classes and Structs
  * Generic Interfaces
  * Generic Methods
  * Generic Delegates
  * Generic Type Conversion
  * Default Value Expression
  * Nullable Types
  * Constructed Types Control Accessibility
  * Generics and Inheritance
- Constraints
  * Constraints on Nonclass Types
- Covariance and Contravariance
  * Covariance
  * Contravariance
  * Invariance
  * Variance and Delegates
- Generic System Collections
- Generic System Interfaces
- Select Problems and Solutions
  * Conversion and Operators within Generic Types
  * Creating Constructed Types Dynamically
- Summary
</details>

## Глава 11. Обобщения
<details>
  <summary><b>Оглавление</b></summary>

- Разница между обобщениями и шаблонами C++
- Эффективность и безопасность типов обобщений
- Определения обобщённых типов и конструируемые типы
  * Обобщённые классы и структуры
  * Обобщённые интерфейсы
  * Обобщённые методы
  * Обобщённые делегаты
  * Преобразование обобщённого типа
  * Выражение значения по умолчанию
  * Типы, допускающие значения _null_
  * Контроль доступа к конструируемым типам
  * Обобщения и наследование
- Ограничения
  * Ограничения на неклассовых типах
- Ковариантность и контравариантность
  * Ковариантность
  * Контравариантность
  * Инвариантность
  * Вариантность и делегаты
- Обобщённые системные коллекции
- Обобщённые системные интерфейсы
- Проблемы выбора и их решение
  * Преобразования и операции внутри обобщённых типов
  * Динамическое создание конструируемых типов
- Резюме
</details>

---
## About
Chapter 11, “Generics,”[^1] introduces you to probably the most exciting feature added to C# 2.0 and
the CLR. Those familiar with C++ templates will find generics somewhat familiar, though many
fundamental differences exist. Using generics, you can provide a shell of functionality within which to
define more specific types at run time. Generics are most useful with collection types and provide great
efficiency compared to the collections of previous .NET versions. Starting with C# 4.0, generic type usage
became even more intuitive with the support of co- and contravariance. Assigning from one generic type
to another when it makes intuitive type-sense is now possible, thus reducing the clutter of conversion
methods needed prior to that.

## Abstract
Support for generics is one of the nicest features of C# and .NET. Generics allow you to create openended types that are converted into closed types at runtime. Each unique closed type is a unique type.
Only closed types can be instantiated. When you declare a generic type, you specify a list of type
parameters in the declaration for which type arguments are given to create closed types, as in the
following example:
```csharp
public class MyCollection<T>
{
    public MyCollection()
    { }

    private T[] storage;
}
```
&nbsp;&nbsp;&nbsp; In this case, I declared a generic type, `MyCollection<T>`, which treats the type within the collection as
an unspecified type. In this example, the type parameter list consists of only one type, and it is described
with syntax in which the generic types are listed, separated by commas, between angle brackets. The
identifier `T` is really just a placeholder for any type. At some point, a consumer of `MyCollection<T>` will
declare what’s called a closed type, by specifying the concrete type that `T` is supposed to represent. For
example, suppose that some other assembly wants to create a `MyCollection<T>` constructed type that
contains members of type `int`. Then it would do so as shown in the following code:
```csharp
public void SomeMethod()
{
    MyCollection<int> collectionOfNumbers = new MyCollection<int>();
}
```
&nbsp;&nbsp;&nbsp; `MyCollection<int>` in this example is the closed type. `MyCollection<int>` can be used just like any
other declared type, and it also follows all the same rules that other nongeneric types follow. The only
difference is that it was born from a generic type. At the point of instantiation, the IL code behind the
implementation of `MyCollection<T>` is JIT-compiled in a way that all the usages of type `T` in the
implementation of `MyCollection<T>` are replaced with type `int`.

&nbsp;&nbsp;&nbsp; Note that all unique constructed types created from the same generic type are, in fact, completely
different types that share no implicit conversion capabilities. For example, `MyCollection<long>` is a
completely different type than `MyCollection<int>`, and you cannot do something like the following:
```csharp
// THIS WILL NOT WORK!!!
public void SomeMethod( MyCollection<int> intNumbers )
{
    MyCollection<long> longNumbers = intNumbers; // ERROR!
}
```
&nbsp;&nbsp;&nbsp; If you’re familiar with the array covariance rules that allow you to do the following, you’ll be happy
to know that C# 4.0 adds new syntax to let you do this with generics:
```csharp
public void ProcessStrings( string[] myStrings )
{
    object[] objs = myStrings;
    foreach( object o in objs )
    {
        Console.WriteLine( o );
    }
}
```
&nbsp;&nbsp;&nbsp; The difference is that with array covariance, the source and the destination of the assignment are of
the same type: `System.Array`. The array covariance rules simply allow you to assign one array from
another, as long as the declared type of the elements in the array is implicitly convertible at compile
time. However, in the case of two constructed generic types, they are completely separate types.

&nbsp;&nbsp;&nbsp; Starting with C# 4.0, the language supports covariance and contravariance between generic
interfaces and delegates with reference-based type arguments. This helps relax the restrictions on
implicit convertibility for some generic types and helps to create code that simply makes sense without a
lot of extra conversion baggage. I will have more to say about the topic of variance in the section titled
“Co- and Contravariance” later in the chapter.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [11_generics](https://github.com/Apress/accelerated-csharp-2010/tree/master/11_generics)

### References
[^1]: Cite this chapter: [Generics](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_11) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
