namespace Learn.Test;
using Learn;
using Xunit;

public class BreadthFirstTest
{
    [Fact]
    public void Search_SmallMatrix_Works()
    {
        var data = new List<List<int>>() { new List<int>(){1, 2, 3}, new List<int>(){4, 5, 6}, new List<int>(){7, 8, 9}};
        var matrix = new Matrix2d<int>(data, 0);
        var bds = new BreadthFirst<int>(matrix);

        var shortest = bds.Search((0,0), (2, 1));
        Assert.Equal(4, shortest.Count());
        Assert.Equal((2, 1), shortest.First());
        Assert.Equal((0, 0), shortest.Last());
    }
}