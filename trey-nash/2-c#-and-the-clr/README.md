# Chapter 2: C# and the CLR[^1]
<details>
  <summary><b>Table of Contents</b></summary>

- The JIT Compiler in the CLR
- Assemblies and the Assembly Loader
  * Minimizing the Working Set of the Application
  * Naming Assemblies
  * Loading Assemblies
- Metadata
- Cross-Language Compatibility
- Summary
</details>

## Глава 2. C# и CLR
<details>
  <summary><b>Оглавление</b></summary>

- JIT-компилятор и CLR
- Сборки и загрузчик сборок
  * Минимизация рабочего набора приложения
  * Назначение сборкам имён
  * Загрузка сборок
- Метаданные
- Совместимость между языками
- Резюме
</details>

---
## About
Chapter 2, “C# and the CLR,”[^1] expands on [Chapter 1](../1-c%23-preview/) and quickly explores the managed environment 
within which C# applications run. I introduce you to assemblies, the basic building blocks of 
applications, into which C# code files are compiled. Additionally, you’ll see how metadata makes 
assemblies self-describing.

## Abstract
As mentioned in the [previous chapter](../1-c%23-preview/), managed applications and native applications have many 
differences, mainly because managed applications run inside the Microsoft CLR. The CLR is a Virtual 
Execution System (VES) that implements the CLI. The CLR provides many useful facilities to managed 
applications, including a highly tuned GC for memory management, a code access security layer, and a 
rich self-describing type system, among others. In this chapter, I’ll show you how the CLR compiles, 
packages, and executes C# programs.

##
:notebook: **Note** In-depth coverage of the CLR is outside the scope of this book, because I focus closely on C# concepts 
and usage. However, I recommend that you become familiar with the CLR. It’s always best to know and 
understand your target platform, and in the case of managed applications such as C#, the platform is the .NET 
CLR. For further, in-depth coverage of the CLR and everything covered in this chapter, see _Essential .NET, Volume 
I: The Common Language Runtime_ by Don Box and Chris Sells (Addison-Wesley Professional, 2002)[^2] and _Pro C# 
2005 and the .NET 2.0 Platform, Third Edition_ by Andrew Troelsen (Apress, 2005)[^3]. After that, you may find many of 
the other, more specific books on the CLR more informative. For complete coverage of the CLR layer that provides 
complete interoperability with native environments such as COM objects and the underlying platform, I recommend 
_.NET and COM: The Complete Interoperability Guide_ by Adam Nathan (Sams, 2002)[^4]. For topics dealing with .NET 
code access security, I recommend _.NET Framework Security_ by Brian A. LaMacchia, et al. (Pearson Education, 
2002)[^5]. Because no developer should ever ignore platform security when designing new systems, I recommend _The 
.NET Developer’s Guide to Windows Security_ by Keith Brown (Addison-Wesley Professional, 2004)[^6].

##
&nbsp;&nbsp;&nbsp; This chapter provides a high-level and cursory description of the mechanisms involved with 
compiling C# and loading code for execution. Once the code is loaded, it must be compiled into native 
machine code for the platform it’s running on. Therefore, you need to understand the concept of JIT 
compilation.

## Source code[^1]
**Repository**[^7] **path**: [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)

<details>
  <summary><b>Page 10. </b><i><b>Listing 2-1. </b>HelloWorld.exe Main Method IL</i></summary>

```csharp
.method private hidebysig static void Main() cil managed
{
   .entrypoint
   // Code size 13 (0xd)
   .maxstack 8
   IL_0000: nop
   IL_0001: ldstr   "Hello World! "
   IL_0006: call    void [mscorlib]System.Console::WriteLine(string)
   IL_000b: nop
   IL_000c: ret
} // end of method EntryPoint::Main
```
</details>

### References
[^1]: Cite this chapter: [C# and the CLR](https://link.springer.com/chapter/10.1007/978-1-4302-2538-6_2) in [_Accelerated C# 2010_](https://link.springer.com/book/10.1007/978-1-4302-2538-6) by Trey Nash ([Apress](https://www.apress.com/), 2010)
[^2]: Book: [_Essential .NET Volume 1: The Common Language Runtime_](https://learning.oreilly.com/library/view/essential-net-volume/0201734117/) 
by Don Box and Chris Sells (Boston, MA: [Addison-Wesley Professional](https://en.wikipedia.org/wiki/Addison-Wesley), 2002).
[Amazon](https://www.amazon.com/Essential-NET-Common-Language-Runtime/dp/0201734117)
[^3]: Book: [_Pro C# 2005 and the .NET 2.0 Platform_](https://link.springer.com/book/10.1007/978-1-4302-0060-4)
by Andrew Troelsen ([Apress](https://www.apress.com/), 2005). 
[Amazon](https://www.amazon.com/2005-NET-Platform-Experts-Voice/dp/1590594193) 
[Google](https://books.google.com/books/about/Pro_C_2005_and_the_NET_2_0_Platform.html?id=Dy-ro5dFp5MC)
[^4]: Book: [_.NET and COM: The Complete Interoperability Guide_](https://www.informit.com/store/.net-and-com-the-complete-interoperability-guide-9780132649414)
by Adam Nathan ([Sams Publishing](https://en.wikipedia.org/wiki/Sams_Publishing), 2002). 
[Amazon](https://www.amazon.com/NET-COM-Complete-Interoperability-Guide/dp/067232170X) 
[Google](https://books.google.com/books?id=x2OIPSyFLBcC)
[^5]: Book: [_.NET Framework Security_](https://www.microsoft.com/en-us/research/publication/net-framework-security/) 
by Brian LaMacchia, Sebastian Lange, Matthew Lyons, Rudi Martin, Kevin T. Price ([Addison-Wesley Professional](https://en.wikipedia.org/wiki/Addison-Wesley), 2002). 
[Amazon](https://www.amazon.com/NET-Framework-Security-Brian-LaMacchia/dp/067232184X)
[^6]: Book: [_The .NET Developer's Guide to Windows Security_](https://www.informit.com/store/.net-developers-guide-to-windows-security-9780321228352) 
by Keith Brown ([Addison-Wesley Professional](https://en.wikipedia.org/wiki/Addison-Wesley), 2004). 
[Amazon](https://www.amazon.com/NET-Developers-Guide-Windows-Security/dp/0321228359) 
[O’Reilly](https://www.oreilly.com/library/view/the-net-developers/0321228359/)
[^7]: GitHub repository: [Apress Source Code](https://github.com/Apress) / [accelerated-csharp-2010](https://github.com/Apress/accelerated-csharp-2010)
