# Chapter 4: Classes, Structs, and Objects[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Class Definitions
  * Fields
  * Constructors
  * Methods
    * Static Methods
    * Instance Methods
  * Properties
    * Declaring Properties
    * Accessors
    * Read-Only and Write-Only Properties
    * Auto-Implemented Properties
  * Encapsulation
  * Accessibility
  * Interfaces
  * Inheritance
    * Accessibility of Members
    * Implicit Conversion and a Taste of Polymorphism
    * Member Hiding
    * The base Keyword
  * sealed Classes
  * abstract Classes
  * Nested Classes
  * Indexers
  * partial Classes
  * partial Methods
  * Static Classes
  * Reserved Member Names
    * Reserved Names for Properties
    * Reserved Names for Indexers
    * Reserved Names for Destructors
    * Reserved Names for Events
- Value Type Definitions
  * Constructors
  * The Meaning of this
  * Finalizers
  * Interfaces
- Anonymous Types
- Object Initializers
- Boxing and Unboxing
  * When Boxing Occurs
  * Efficiency and Confusion
- System.Object
  * Equality and What It Means
  * The IComparable Interface
- Creating Objects
  * The new Keyword
    * Using new with Value Types
    * Using new with Class Types
  * Field Initialization
  * Static (Class) Constructors
  * Instance Constructor and Creation Ordering
- Destroying Objects
  * Finalizers
  * Deterministic Destruction
  * Exception Handling
- Disposable Objects
  * The IDisposable Interface
  * The using Keyword
- Method Parameter Types
  * Value Arguments
  * ref Arguments
  * out Parameters
  * param Arrays
  * Method Overloading
  * Optional Arguments
  * Named Arguments
- Inheritance and Virtual Methods
  * Virtual and Abstract Methods
  * override and new Methods
  * sealed Methods
  * A Final Few Words on C# Virtual Methods
- Inheritance, Containment, and Delegation
  * Choosing Between Interface and Class Inheritance
  * Delegation and Composition vs. Inheritance
- Summary
</details>

## Глава 4. Классы, структуры и объекты
<details>
  <summary><b>Оглавление</b></summary>

- Определения классов
  * Поля
  * Конструкторы
  * Методы
  * Свойства
  * Инкапсуляция
  * Доступность
  * Интерфейсы
  * Наследование
  * Герметизированные классы
  * Абстрактные классы
  * Вложенные классы
  * Индексаторы
  * Частичные классы
  * Частичные методы
  * Статические классы
- Зарезервированные имена членов
- Определения типов значений
  * Смысл ключевого слова this
  * Финализаторы
  * Интерфейсы
- Анонимные типы
- Инициализаторы объектов
- Упаковка и распаковка
  * Когда происходит упаковка
  * Эффективность и путаница
- Класс System.Object
  * Эквивалентность и её смысл
  * Интерфейс IComparable
- Создание объектов
  * Ключевое слово new
  * Инициализация полей
  * Статические конструкторы (класса)
  * Конструктор экземпляра и порядок создания
- Уничтожение объектов
  * Финализаторы
  * Детерминированное уничтожение
  * Обработка исключений
- Одноразовые объекты
  * Интерфейс IDisposable
  * Ключевое слово using
- Типы параметров методов
  * Аргументы-значения
  * Аргументы ref
  * Параметры out
  * Массивы params
- Перегрузка методов
  * Необязательные аргументы
  * Именованные аргументы
- Наследование и виртуальные методы
  * Виртуальные и абстрактные методы
  * Методы new и override
  * Методы sealed
- Завершающие замечания о виртуальных методах C#
- Наследование, включение и делегирование
  * Выбор между интерфейсом и наследованием класса
  * Сравнение делегирования и композиции с наследованием
- Резюме
</details>

---
## About
Chapter 4, “Classes, Structs, and Objects,”[^1] provides details about defining types in C#. You’ll learn
more about value types and reference types in the CLR. I also touch upon the native support for
interfaces within the CLR and C#. You’ll see how type inheritance works in C#, as well as how every
object derives from the `System.Object` type. This chapter also contains a wealth of information regarding
the managed environment and what you must know in order to define types that are useful in it. I
introduce many of these topics in this chapter and discuss them in much more detail in later chapters.

## Abstract
Everything is an object! At least, that is the view from inside the CLR and the C# programming language. 
This is no surprise, because C# is, after all, an object-oriented language. The objects that you create 
through class definitions in C# have all the same capabilities as the other predefined objects in the 
system. In fact, keywords in the C# language such as int and bool are merely aliases to predefined value 
types within the `System` namespace, in this case `System.Int32` and `System.Boolean`, respectively.

##
:notebook: **Note** This chapter is rather long, but don’t allow it to be intimidating. In order to cater to a wider audience, this
chapter covers as much C# base material as reasonably possible. If you’re proficient with either C++ or Java, you
may find yourself skimming this chapter and referencing it as you read subsequent chapters. Some of the topics
touched upon in this chapter are covered in more detail in later chapters.

The first section of this chapter covers class (reference type) definitions, which is followed by a section discussing
structure (value type) definitions. These are the two most fundamental classifications of types in the .NET runtime.
Then you’ll learn about `System.Object` (the base type of all types), the nuances of creating and destroying
instances of objects, expressions for initializing objects, and the topic of boxing and unboxing. I then cover newer
C# features such as anonymous types and named and optional arguments. Finally, I cover inheritance and
polymorphism, and the differences between inheritance and containment with regard to code reuse.

##
&nbsp;&nbsp;&nbsp; The ability to invent your own types is paramount to object-oriented systems. The cool thing is that
because even the built-in types of the language are plain-old CLR objects, the objects you create are on a
level playing field with the built-in types. In other words, the built-in types don’t have special powers
that you cannot muster in user-defined types. The cornerstone for creating these types is the _class
definition_. Class definitions, using the C# `class` keyword, define the internal state and the behaviors
associated with the objects of that class’s type. The internal state of an object is represented by the fields
that you declare within the class, which can consist of references to other objects, or values. Sometimes,
but rarely, you will hear people describe this as the “shape” of the object, because the instance field
definitions within the class define the memory footprint of the object on the heap.

&nbsp;&nbsp;&nbsp; The objects created from a class encapsulate the data fields that represent the internal state of the
objects, and the objects can tightly control access to those fields. The behavior of the objects is defined
by implementing methods, which you declare and define within the class definition. By calling one of
the methods on an object instance, you initiate a unit of work on the object. That work can possibly
modify the internal state of the object, inspect the state of the object, or anything else for that matter.

&nbsp;&nbsp;&nbsp; You can define constructors, which the system executes whenever a new object is created. You can
also define a method called a finalizer, which works when the object is garbage-collected. As you’ll see in
[Chapter 13](../13-in-search-of-c%23-canonical-forms/), you should avoid finalizers if at all possible. This chapter covers construction and
destruction in detail, including the detailed sequence of events that occur during the creation of an object.

&nbsp;&nbsp;&nbsp; Objects support the concept of _inheritance_, whereby a _derived class_ inherits the fields and methods
of a _base class_. Inheritance also allows you to treat objects of a derived type as objects of its base type. For
example, a design in which an object of type `Dog` derives from type `Animal` is said to model an is-a
relationship (i.e., `Dog` is-a(n) `Animal`). Therefore, you can implicitly convert references of type `Dog` to
references of type `Animal`. Here, _implicit_ means that the conversion takes the form of a simple
assignment expression. Conversely, you can _explicitly_ convert references of type `Animal`, through a cast
operation, to references of type `Dog` if the particular object referenced through the `Animal` type is, in fact,
an object created from the `Dog` class. This concept, called _polymorphism_, whereby you can manipulate
objects of related types as though they were of a common type, should be familiar to you. Computer
wonks always try to come up with fancy five-dollar words for things such as this, and _polymorphism_ is no
exception, when all it means is that an object can take on multiple type identities. This chapter discusses
inheritance as well as its traps and pitfalls.

&nbsp;&nbsp;&nbsp; The CLR tracks object references. This means each variable of _reference type_ actually contains a
reference to an object on the heap (or is null, if it doesn’t currently refer to an object). When you copy
the value of a reference-type variable into another reference-type variable, another reference to the
same object is created—in other words, the reference is copied. Thus, you end up with two variables that
reference the same object. In the CLR, you have to do extra work to create copies of objects—e.g., you
must implement the `ICloneable` interface or a similar pattern.

&nbsp;&nbsp;&nbsp; All objects created from C# class definitions reside on the system heap, which the CLR garbage
collector manages. The GC relieves you from the task of cleaning up your objects’ memory. You can
allocate them all day long without worrying about who will free the memory associated with them. The
GC is smart enough to track all of an object’s references, and when it notices that an object is no longer
referenced, it marks the object for deletion. Then, the next time the GC compacts the heap, it destroys
the object and reclaims the memory.

##
:notebook: **Note** In reality, the process is much more complex than this. There are many hidden nuances to how the GC
reclaims the memory of unused objects. I talk about this in the section titled “Destroying Objects” later this
chapter. Consider this: The GC removes some complexity in one area, but introduces a whole new set of
complexities elsewhere.

##
&nbsp;&nbsp;&nbsp; Along with classes, the C# language supports the definition of new _value types_ through the `struct`
keyword. Value types are lightweight objects that typically don’t live on the heap, but instead live on the
stack. To be completely accurate, a value type can live on the heap, but only if it is a field inside an object
on the heap. Value types cannot be defined to inherit from another class or value type, nor can another
value type or class inherit from them.

&nbsp;&nbsp;&nbsp; Value types can have constructors, but they cannot have a finalizer. By default, when you pass value
types into methods as parameters, the method receives a copy of the value. I cover the many details of
value types, along with their differences from reference types, in this chapter and in [Chapter 13](../13-in-search-of-c%23-canonical-forms/).

&nbsp;&nbsp;&nbsp; That said, let’s dive in and get to the details. Don’t be afraid if the details seem a little overwhelming
at first. The fact is you can start to put together reasonable applications with C# without knowing every
single detailed behavior of the language. That’s a good thing, because C#, along with the Visual Studio
IDE, is meant to facilitate rapid application development. However, the more details you know about the
language and the CLR, the more effective you’ll be at developing and designing robust C# applications.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [4_classes_structs](https://github.com/Apress/accelerated-csharp-2010/tree/master/4_classes_structs)

### References
[^1]: Cite this chapter: [Classes, Structs, and Objects](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_4) in [_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
