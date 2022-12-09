namespace Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts
{
    public class Chapter5
    {
        /// <summary>
        /// Run method (calls a demo of the Exercise1.cs class)
        /// </summary>
        public static void Run()
        {
            Exercise1.ClassA obj = new Exercise1.ClassA();
            obj.MethodA();
            ((Exercise1.IB)obj).MethodA();
            Console.WriteLine(obj.MethodB(5));
        }
    }
}
