namespace Learn.Test;
using Xunit;

public class AvoidVisitedFilterTest
{
    [Fact]
    public void Filter_NotVisited_True()
    {
        var state = SearchState<string>.GenerateEmpty(string.Empty, (0,0));
        var move = new Move((0,0), (0,1));
        var filter = new AvoidVisitedFilter<string>();
        
        var isAllowed = filter.FilterValid(state, move);
        
        Assert.True(isAllowed);
    }

    [Fact]
    public void Filter_Visited_False()
    {
        var state = SearchState<string>.GenerateEmpty(string.Empty, (0,0));
        state.Visited.Set(0,1, (0,0));
        var move = new Move((1,1), (0,1));
        var filter = new AvoidVisitedFilter<string>();

        var isAllowed = filter.FilterValid(state, move);

        Assert.False(isAllowed);
    }

}