namespace Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts
{
    /// <summary>
    /// The classes and interfaces of Exercise #1.
    /// </summary>
    internal class Exercise1
    {
        /// <summary>
        /// Initial interface which is rewritten as the abstract <see cref="ClassIA" /> class.
        /// </summary>
        public interface IA
        {
            void MethodA();
            bool PropA { get; }
            int this[int index] { get; }
            event EventHandler EventA;
        }
        /// <summary>
        /// Abstract class instead of of the <see cref="IA" /> interface (all signatures are abstract)
        /// </summary>
        public abstract class ClassIA
        {
            public abstract void MethodA();
            public abstract bool PropA { get; }
            public abstract int this[int index] { get; }
            public abstract event EventHandler EventA;
        }
        /// <summary>
        /// Interface that is used for inheritance in the new base abstract <see cref="ClassA"/> class
        /// </summary>
        public interface IB
        {
            void MethodA();
            int MethodB(int index);
        }
        /// <summary>
        /// The new base abstract class that inherits the abstract <see cref="ClassIA"/> class and the <see cref="IB"/> interface
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
