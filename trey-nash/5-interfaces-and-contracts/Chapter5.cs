namespace Fedotkin.Dotnet.TreyNash.Ch5_InterfacesAndContracts;

public static class Chapter5
{
    /// <summary>
    /// Runs the demo of <see cref="Exercise1"/>.
    /// </summary>
    public static void Run()
    {
        Exercise1.ClassA obj = new Exercise1.ClassA();
        obj.MethodA();
        ((Exercise1.IB)obj).MethodA();
        Console.WriteLine(obj.MethodB(5));
    }
}
