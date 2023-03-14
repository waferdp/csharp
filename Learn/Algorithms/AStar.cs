namespace Learn;

public class AStar : PrioritySearch
{
    public AStar(WeightedGraph graph, IHeuristic heuristic) : base(graph, heuristic)
    {
    }
}