namespace Learn.Test;
using Xunit;

public class FizzBuzzTest
{
    [Fact]
    public void FizzBuzz_Until5_12Fizz4Buzz()
    {
        var expected = "12Fizz4Buzz";
        var actual = FizzBuzz.OnelineFizz(5);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void FizzBuzz_Until15_EndsWithFizzBuzz()
    {
        var fizzy = FizzBuzz.Fizz(15);
        Assert.Equal("FizzBuzz", fizzy.Last());
    }
}