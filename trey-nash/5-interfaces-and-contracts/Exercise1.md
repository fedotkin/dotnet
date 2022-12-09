There is this code:

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
    ...
}

Add the body of class ClassA. 
Before that, rewrite interface IA via an abstract class definition.
That is, comment out IA and define a new base abstract class, ClassIA
(the abstract class ClassIA will be fully abstract: all signatures are abstract)