namespace Learn.Test;
using Xunit;

public class AvoidVisitedFilterTest
{
    [Fact]
    public void Filter_NotVisited_True()
    {
        var state = new SearchState<string>
        {
            Visited = GenerateVisited(),
            Grid = GenerateEmptyGrid()
        };
        var move = new Move((0,0), (0,1));
        var filter = new AvoidVisitedFilter<string>();
        
        var isAllowed = filter.FilterValid(state, move);
        
        Assert.True(isAllowed);
    }

    private Matrix2d<(int, int)> GenerateVisited()
    {
        return Matrix2d<(int,int)>.Empty((0,0));
    }

    private Matrix2d<string> GenerateEmptyGrid()
    {
        return Matrix2d<string>.Empty(string.Empty);
    }
}