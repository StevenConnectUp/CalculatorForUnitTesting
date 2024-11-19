using BasicExampleUnitTests;
using CalculatorForUnitTesting.Interfaces;
using NSubstitute;
using Xunit;

public class CalculatorTests
{
    [Fact]
    public void ReturnSumOfTwoNumbers()
    {
        var mockRepo = Substitute.For<INumberRepository>();
        mockRepo.GetNumberA().Returns(10);
        mockRepo.GetNumberB().Returns(20);

        var calculator = new Calculator(mockRepo);

        var result = calculator.Add();

        Assert.Equal(30, result);
    }

    [Fact]
    public void ReturnDifferenceOfTwoNumbers()
    {
        var mockRepo = Substitute.For<INumberRepository>();
        mockRepo.GetNumberA().Returns(20);
        mockRepo.GetNumberB().Returns(10);

        var calculator = new Calculator(mockRepo);

        var result = calculator.Subtract();

        Assert.Equal(10, result);
    }

    [Fact]
    public void ReturnProductOfTwoNumbers()
    {
        var mockRepo = Substitute.For<INumberRepository>();
        mockRepo.GetNumberA().Returns(5);
        mockRepo.GetNumberB().Returns(4);

        var calculator = new Calculator(mockRepo);

        var result = calculator.Multiply();

        Assert.Equal(20, result);
    }

    [Fact]
    public void ReturnQuotientOfTwoNumbers()
    {
        var mockRepo = Substitute.For<INumberRepository>();
        mockRepo.GetNumberA().Returns(20);
        mockRepo.GetNumberB().Returns(4);

        var calculator = new Calculator(mockRepo);

        var result = calculator.Divide();

        Assert.Equal(5, result);
    }

    [Fact]
    public void ThrowDivideByZeroException()
    {
        var mockRepo = Substitute.For<INumberRepository>();
        mockRepo.GetNumberA().Returns(10);
        mockRepo.GetNumberB().Returns(0);

        var calculator = new Calculator(mockRepo);

        Assert.Throws<DivideByZeroException>(() => calculator.Divide());
    }
    [Fact]
    public void HandleNegativeNumbersInAddition()
    {
        // Arrange
        var numberRepository = Substitute.For<INumberRepository>();
        numberRepository.GetNumberA().Returns(-10);
        numberRepository.GetNumberB().Returns(-5);
        var calculator = new Calculator(numberRepository);

        // Act
        var result = calculator.Add();

        // Assert
        Assert.Equal(-15, result);
    }

    [Fact]
    public void HandleLargeNumbersInMultiplication()
    {
        // Arrange
        var numberRepository = Substitute.For<INumberRepository>();
        numberRepository.GetNumberA().Returns(1_000_000);
        numberRepository.GetNumberB().Returns(1_000);
        var calculator = new Calculator(numberRepository);

        // Act
        var result = calculator.Multiply();

        // Assert
        Assert.Equal(1_000_000_000, result);
    }

    [Fact]
    public void HandleZeroInOperations()
    {
        // Arrange
        var numberRepository = Substitute.For<INumberRepository>();
        numberRepository.GetNumberA().Returns(0);
        numberRepository.GetNumberB().Returns(10);
        var calculator = new Calculator(numberRepository);

        // Act
        var addResult = calculator.Add();
        var subtractResult = calculator.Subtract();
        var multiplyResult = calculator.Multiply();
        var divideResult = calculator.Divide();

        // Assert
        Assert.Equal(10, addResult);
        Assert.Equal(-10, subtractResult);
        Assert.Equal(0, multiplyResult);
        Assert.Equal(0.0, divideResult);
    }
}
