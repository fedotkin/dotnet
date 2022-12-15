namespace Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts
{
    /// <summary>
    /// Here are the classes and interfaces for example
    /// </summary>
    internal class Exercise1
    {
        /// <summary>
        /// Initial interface which is rewritten as abstract class <see cref="ClassIA"/>
        /// </summary>
        public interface IA
        {
            void MethodA();
            bool PropA { get; }
            int this[int index] { get; }
            event EventHandler EventA;
        }
        /// <summary>
        /// Abstract class instead of interface <see cref="IA"/> (all signatures are abstract)
        /// </summary>
        public abstract class ClassIA
        {
            public abstract void MethodA();
            public abstract bool PropA { get; }
            public abstract int this[int index] { get; }
            public abstract event EventHandler EventA;
        }
        /// <summary>
        /// Interface that is used for inheritance in the new base abstract class <see cref="ClassA"/>
        /// </summary>
        public interface IB
        {
            void MethodA();
            int MethodB(int index);
        }
        /// <summary>
        /// The new base abstract class that inherits abstract class <see cref="ClassIA"/> and interface <see cref="IB"/>
        /// </summary>
        public class ClassA : ClassIA, IB
        {
            public override void MethodA() { Console.WriteLine("pip_1"); }
            void IB.MethodA() { Console.WriteLine("pip_2"); }
            public int MethodB(int index) { return index * 10; }
            public override bool PropA { get { return true; } }
            public override int this[int index] { get { return 1; } }
            public override event EventHandler EventA;
        }
    }
}
