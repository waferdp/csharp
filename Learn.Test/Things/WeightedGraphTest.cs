namespace Learn.Test;
using Learn;
using Xunit;


public class WeightedGraphTest
{
    [Fact]
    public void TakeCheapestMove_OneSmaller_TakesSmallerCost()
    {
        var weightedGraph = new WeightedGraph();
        weightedGraph.SetLeg((1,0), (1,1), 3);
        weightedGraph.SetLeg((1,0), (0,0), 1);
        weightedGraph.SetLeg((1,0), (2,0), 2);

        var cheapest = weightedGraph.TakeCheapestMove();
        Assert.Equal(((1,0),(0,0)), cheapest);
    }
}