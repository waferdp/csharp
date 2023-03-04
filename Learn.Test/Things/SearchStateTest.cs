namespace Learn.Test;
using Xunit;

public class SearchStateTest
{
    [Fact]
    public void Constructor_GoodInput_Works()
    {
        var state = SearchState<string>.GenerateEmpty(".", (0,0));
        Assert.Equal(".", state.Grid[0,0]);
        Assert.Equal((0,0), state.Visited[0,0]);
    }
}