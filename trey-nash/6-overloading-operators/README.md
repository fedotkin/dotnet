# Chapter 6: Overloading Operators[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- Just Because You Can Doesn’t Mean You Should
- Types and Formats of Overloaded Operators
- Operators Shouldn’t Mutate Their Operands
- Does Parameter Order Matter?
- Overloading the Addition Operator
- Operators That Can Be Overloaded
  * Comparison Operators
  * Conversion Operators
  * Boolean Operators
- Summary
</details>

## Глава 6. Перегрузка операций	
<details>
  <summary><b>Оглавление</b></summary>

- Можете – не значит должны
- Типы и форматы перегруженных операций
- Операции не должны изменять свои операнды
- Имеет ли значение порядок параметров?
- Перегрузка операции сложения
- Операции, допускающие перегрузку
  * Операции сравнения
  * Операции преобразования
  * Булевские операции
- Резюме
</details>

---
## About
Chapter 6, “Overloading Operators,”[^1] details how you may provide custom functionality for the
built-in operators of the C# language when applied to your own defined types. You’ll see how to
overload operators responsibly, because not all managed languages that compile code for the CLR are
able to use overloaded operators.

## Abstract
C# adopted the capability of operator overloading from C++. Just as you can overload methods, you can
overload operators such as `+`, `-`, `*`, and so on. In addition to overloading arithmetic operators, you can
also create custom conversion operators to convert from one type to another. You can overload other
operators to allow objects to be used in Boolean test expressions.

## Source code[^1]
**Repository**[^2] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
/ [6_operators](https://github.com/Apress/accelerated-csharp-2010/tree/master/6_operators)

### References
[^1]: Cite this chapter: [Overloading Operators](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_6) in 
[_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
