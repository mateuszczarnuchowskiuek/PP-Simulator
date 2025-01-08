using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(0, 0, 10, 0)]
    [InlineData(10, 0, 10, 10)]
    [InlineData(-2, -10, 10, -2)]
    public void Limiter_ValuesInRange_PassesValues(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData(-1, 0, 10, 0)]
    [InlineData(12, 0, 10, 10)]
    [InlineData(-234, -30, 10, -30)]
    [InlineData(16, 2, 7, 7)]
    public void Limiter_ValuesOutsideOfRange_LimitsValues(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("   Shrek    ", "Shrek")]
    [InlineData("   ", "Unknown")]
    [InlineData("  donkey  ", "Donkey")]
    [InlineData("Puss in Boots a clever and brave cat.", "Puss in Boots a")]
    [InlineData("A                     gfdgdfg.", "A##")]
    [InlineData("", "Unknown")]
    [InlineData("a", "A##")]
    [InlineData("ab", "Ab#")]
    [InlineData("abc", "Abc")]
    public void Shortener_ShouldCorrect(string input, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(input, 3, 15, '#'));
    }
}
