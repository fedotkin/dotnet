Given this code:

```csharp
public interface IA {
    void MethodA();
    bool PropA { get; }
    int this[int index];
    event EventHandler EventA;
}
public interface IB {
    void MethodA();
    int MethodB(int index);
}
public class ClassA : IA, IB
{
    //...
}
```

- Add the body of the `ClassA` class. 
- Rewrite `IA` interface via an abstract class definition.
Note! Don't comment out the `IA` interface, and define a new base abstract `ClassIA` class.
Also, note please, the abstract `ClassIA` class will be fully abstract: all signatures are abstract.