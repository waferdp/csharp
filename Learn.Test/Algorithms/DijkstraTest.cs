namespace Learn.Test;
using Learn;
using Xunit;

public class DijkstraTest
{
    [Fact]
    public void Search_SmallMatrix_Works()
    {
        var data = new List<List<int>>() { new List<int>(){1, 1, 1}, new List<int>(){1, 1, 1}, new List<int>(){1, 1, 1}};
        var matrix = new Matrix2d<int>(data, -1);
        var graph = WeightedGraph.CreateFromGrid(matrix, -1);
        var dijkstra = new Dijkstra(graph);
        var shortest = dijkstra.Search((0,0), (2, 1));
        Assert.Equal(4, shortest.Count());
        Assert.Equal((2, 1), shortest.First());
        Assert.Equal((0, 0), shortest.Last());
    }

    [Fact]
    public void Search_NoGoal_EmptyList()
    {
        var data = new List<List<int>>() { new List<int>(){1, 1, 1}, new List<int>(){1, 1, 1}, new List<int>(){1, 1, 1}};
        var matrix = new Matrix2d<int>(data, -1);
        var graph = WeightedGraph.CreateFromGrid(matrix, -1);
        var dijkstra = new Dijkstra(graph);
        var shortest = dijkstra.Search((0,0), (3, 4));
        Assert.Empty(shortest);
    }

    [Fact]
    public void Search_Obstacle_Navigates()
    {
        var data = new List<List<int>>() { new List<int>(){1, 1, 1}, new List<int>(){-1, -1, 1}, new List<int>(){1, 1, 1}};
        var matrix = new Matrix2d<int>(data, -1);
        var graph = WeightedGraph.CreateFromGrid(matrix, -1);
        var dijkstra = new Dijkstra(graph);
        var shortest = dijkstra.Search((0,0), (1, 2));
        
        Assert.Equal(6, shortest.Count());
        Assert.Equal(5, dijkstra.GetCost((1, 2)));
    }

    [Fact]
    public void Search_ExpensiveMoves_Navigates()
    {
        var data = new List<List<int>>() { new List<int>(){1, 1, 1}, new List<int>(){3, 4, 1}, new List<int>(){1, 1, 1}};
        var matrix = new Matrix2d<int>(data, -1);
        var graph = WeightedGraph.CreateFromGrid(matrix, -1);
        var dijkstra = new Dijkstra(graph);
        var shortest = dijkstra.Search((0,0), (1, 2));
        
        Assert.Equal(4, shortest.Count());
        Assert.Equal(5, dijkstra.GetCost((1, 2)));
    }
}