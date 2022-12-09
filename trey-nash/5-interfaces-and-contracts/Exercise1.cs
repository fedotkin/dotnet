namespace Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts
{
    internal class Exercise1
    {
        /// <summary>
        /// Interface will be rewritten via an abstract class definition
        /// </summary>
        public interface IA
        {
            void MethodA();
            bool PropA { get; }
            int this[int index] { get; }
            event EventHandler EventA;
        }
        /// <summary>
        /// Abstract class instead of interface (all signatures are abstract)
        /// </summary>
        public abstract class ClassIA
        {
            public abstract void MethodA();
            public abstract bool PropA { get; }
            public abstract int this[int index] { get; }
            public abstract event EventHandler EventA;
        }
        public interface IB
        {
            void MethodA();
            int MethodB(int index);
        }
        public class ClassA : ClassIA, IB
        {
            public override void MethodA()
            {
                Console.WriteLine("pip_1");
            }
            void IB.MethodA()
            {
                Console.WriteLine("pip_2");
            }
            public int MethodB(int index) { return index * 10; }
            public override bool PropA { get { return true; } }
            public override int this[int index] { get { return 1; } }
            public override event EventHandler EventA;
        }
    }
}
