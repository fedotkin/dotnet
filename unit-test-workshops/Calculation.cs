namespace Fedotkin.Dotnet.UnitTestWorkshops.Calculator;

public class Calculation
{
    public int Division(int number1, int number2)
    {
        if (number2 == 0)
            throw new DivideByZeroException();
        return number1 / number2;
    }

    public int Addition(int number1, int number2)
    {
        return number1 + number2;
    }
}
