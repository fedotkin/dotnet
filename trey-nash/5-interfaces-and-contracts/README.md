# Chapter 5. Interfaces and contracts[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Interfaces Define Types
- Defining Interfaces
- Implementing Interfaces
- Interface Member Matching Rules
- Explicit Interface Implementation with Value Types
- Versioning Considerations
- Contracts
- Choosing Between Interfaces and Classes
- Summary
</details>

## Глава 5. Интерфейсы и контракты
<details>
  <summary><b>Оглавление</b></summary>

- Интерфейсы определяют типы
- Определение интерфейсов
- Реализация интерфейсов
- Правила сопоставления членов интерфейсов
- Явная реализация интерфейса с помощью типа значений
- Соображения, касающиеся версий
- Контракты
- Выбор между интерфейсами и классами
- Резюме
</details>

---
## About
Chapter 5, “Interfaces and Contracts”,[^1] details interfaces and the role they play in the C# language. 
Interfaces provide a functionality contract that types may choose to implement. You’ll learn the various 
ways that a type may implement an interface, as well as how the runtime chooses which methods to call 
when an interface method is called.

## Abstract
During your years as a software developer, you’ve likely come across the notion of _interface-based programming_.
If you’re familiar with the seminal book, _Design Patterns: Elements of Reusable Object-Oriented Software_,
by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides (known as the "Gang of Four"),[^2] then you know
that many design patterns employ interface-style "contracts." If you’re not familiar with that book and its
concepts, I urge you to read it. In this chapter, it is my goal to show you how you can model well-defined,
versioned contracts using interfaces. In this context,
<ins>a contract is an agreement by a type to support a set of functionality</ins>.

<details>
  <summary><b>...</b></summary>
  
  If you’ve done any COM or CORBA development over the years, then you’ve most definitely been doing
  interface-based development. In fact, the interface is the only form of communication between components
  in COM. Therefore, much of the design complexity rests in developing solid interfaces before you write any
  lines of implementation code. Failure to follow this paradigm has been the source of many problems. For example,
  Visual Studio 2003 offered an easy environment from which you could create web services. By simply annotating
  methods of a class a certain way, you could expose those methods as methods of the web service. However, the IDE
  fostered an approach whereby the interface was the result of annotating methods on a class rather than the other
  way around. Thus, the cart was put before the horse. Instead, you should clearly define the web service interface
  before doing any coding, and then code the implementation to implement the interface. To name just one benefit of
  this approach, you can code the client and the server concurrently rather than one after the other. Another part
  of the problem is that once an interface is published to the world, you cannot change it. Doing so would break all
  implementations based upon it. Unfortunately, the Visual Studio environment encourages you to break this rule by
  making it easy for you to add a new method to a class and annotate it as a web service method.
  
  <details>
    <summary><b>...</b></summary> 
    In a well-designed, interface-based system, such as in service-oriented architecture (SOA) systems,
    you should always design the interface first, as it’s the contract between components. The contract drives
    the implementation rather than the implementation driving, or defining, the contract. Unfortunately, too
    many tools in the past and even up to the present have promoted this backward development. But just because
    they promote it does not mean you need to follow their erroneous lead. After all, a contract, when applied to
    a type, imposes a set of requirements on that type. It makes no sense for the requirements to be driven by
    the types themselves. In the .NET environment, interfaces are types.
  </details>
</details>

## Source code[^1]
**Repository**[^3] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [5_interfaces](https://github.com/Apress/accelerated-csharp-2010/tree/master/5_interfaces)

[^1]: Cite this chapter: [Interfaces and Contracts](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_5) in [_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash (Apress, 2010)
[^2]: _Design Patterns: Elements of Reusable Object-Oriented Software_ by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides (Boston, MA: Addison-Wesley Professional, 1995) is cited in the references at the end of this book. [Wikipedia](https://en.wikipedia.org/wiki/Design_Patterns)
[^3]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
