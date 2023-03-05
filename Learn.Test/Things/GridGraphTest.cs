namespace Learn.Test;
using Xunit;

public class GridraphTest 
{

    [Fact]
    public void Build_SquareGrid_IsCorrectSize()
    {
        var graph = new GridGraph(5, 5);
        Assert.Equal(5*5, graph.Size());
    }

    [Fact]
    public void GetNeighbors_Corner_OnlyTwo()
    {
        var graph = new GridGraph(5, 5);
        var neighbors = graph.GetNeighbors((0,0));
        Assert.Equal(2, neighbors.Count());
    }

    [Fact]
    public void GetNeighbors_InsideEdge_FourNeighbors()
    {
        var graph = new GridGraph(5, 5);
        var neighbors = graph.GetNeighbors((1,1));
        Assert.Equal(4, neighbors.Count());
    }

    [Fact]
    public void GetNeighbors_SpecificNode_CorrectNeighbors()
    {
        var expected = new HashSet<(int, int)>() {(1,0), (0,1), (2,1), (1, 2)};
        var graph = new GridGraph(5, 5);

        var neighbors = graph.GetNeighbors((1,1)).ToHashSet();

        Assert.Equal(expected, neighbors);
    }
}