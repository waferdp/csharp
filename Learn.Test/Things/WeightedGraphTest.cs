namespace Learn.Test;
using Learn;
using Xunit;


public class WeightedGraphTest
{
    [Fact]
    public void TakeCheapestMove_OneSmaller_TakesSmallerCost()
    {
        var weightedGraph = new WeightedGraph();
        weightedGraph.SetLeg((0,0), (0,1), 2);
        weightedGraph.SetLeg((0,0), (1,0), 1);

        var cheapest = weightedGraph.TakeCheapestMove();
        Assert.Equal(((0,0),(1,0)), cheapest);
    }

    [Fact]
    public void Fails()
    {
        Assert.Fail("This always fails");
    }
}