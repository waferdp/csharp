namespace Learn.Test;
using Learn;
using Xunit;


public class WeightedGraphTest
{
    [Fact]
    public void GetCost_ExistingLeg_ReturnsCost()
    {
        var weightedGraph = new WeightedGraph();
        weightedGraph.SetLeg((1,0), (1,1), 3);

        var cost = weightedGraph.GetCost(((1,0), (1,1)));
        Assert.Equal(3, cost);
    }

    [Fact]
    public void GetNeighbors_TwoNeighbors_ReturnsTwo()
    {
        var weightedGraph = new WeightedGraph();
        weightedGraph.SetLeg((1,0), (1,1), 3);
        weightedGraph.SetLeg((1,0), (0,0), 1);
        weightedGraph.SetLeg((2,1), (2,0), 2);

        var neighbors = weightedGraph.GetNeighbors((1,0));
        Assert.Equal(2, neighbors.Count);
    }
}