namespace Learn.Test;
using Xunit;

public class VisitableFilterTest
{
    [Fact]
    public void Filter_Visitable_True()
    {
        var state = new SearchState<string>(".", (0,0));
        var move = new Move((0,0), (0,1));
        var filter = new VisitableFilter<string>(".");
    
        var isAllowed = filter.FilterValid(state, move);

        Assert.True(isAllowed);
    }

    [Fact]
    public void Filter_NotVisitable_False()
    {
        var state = new SearchState<string>(".", (0,0));
        var move = new Move((0,0), (0,1));
        var filter = new VisitableFilter<string>(".");
        state.Grid[0,1] = "#";

        var isAllowed = filter.FilterValid(state, move);

        Assert.False(isAllowed);
    }

}