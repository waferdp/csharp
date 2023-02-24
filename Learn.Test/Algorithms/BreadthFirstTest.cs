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

    [Fact]
    public void Search_NoGoal_EmptyList()
    {
        var data = new List<List<int>>() { new List<int>(){1, 2, 3}, new List<int>(){4, 5, 6}, new List<int>(){7, 8, 9}};
        var matrix = new Matrix2d<int>(data, 0);
        var bds = new BreadthFirst<int>(matrix);

        var shortest = bds.Search((0,0), (3, 4));
        Assert.Empty(shortest);
    }

    [Fact]
    public void Search_Obstacle_Navigates()
    {
        var data = new List<List<string>>() { new List<string>(){".", ".", "."}, new List<string>(){"#", "#", "."}, new List<string>(){".", ".", "."}};
        var matrix = new Matrix2d<string>(data, "#");
        var bds = new BreadthFirst<string>(matrix);
        bds.IsAllowed = delegate((int, int) a, (int, int) b, Matrix2d<string> matrix)
        {
            return matrix[b.Item1, b.Item2] != "#";            
        };

        var shortest = bds.Search((0,0), (1, 2));
        
        Assert.Equal(6, shortest.Count());
    }
}