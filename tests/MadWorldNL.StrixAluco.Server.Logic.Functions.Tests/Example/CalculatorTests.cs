using NUnit.Framework;

namespace MadWorldNL.StrixAluco.Example;

public class CalculatorTests
{
    [Test]
    public void Add_GivenTwoIntegers_ReturnsSum()
    {
        // Arrange
        var calculator = new Calculator();
        const int a = 5;
        const int b = 3;

        // Act
        var result = calculator.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(8));
    }
}