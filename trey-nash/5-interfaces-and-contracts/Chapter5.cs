namespace ChapterExercises._5_interfaces_and_contracts
{
    public class Chapter5
    {
        //метод Run (вызывает демонстрацию класса Exercise1.cs)
        public static void Run()
        {
            ClassA obj = new ClassA();
            obj.MethodA();
            ((IB)obj).MethodA();
            Console.WriteLine(obj.MethodB(5));
        }
    }
}
