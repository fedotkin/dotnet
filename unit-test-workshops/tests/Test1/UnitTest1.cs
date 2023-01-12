using Fedotkin.Dotnet.UnitTestWorkshops.Calculator;

namespace Fedotkin.Dotnet.UnitTestWorkshops.Test1;

public class UnitTest1
{
    [Fact]
    public void PassingTest1()
    {
        // Arrange
        Calculation obj = new Calculation();

        // Act
        int number = obj.Division(8, 2);

        // Assert
        Assert.Equal(4, number);
    }

    [Fact]
    public void PassingTest2()
    {
        // Arrange
        Calculation obj = new Calculation();

        // Act
        int number = obj.Addition(8, 2);

        // Assert
        Assert.Equal(10, number);
    }
}
