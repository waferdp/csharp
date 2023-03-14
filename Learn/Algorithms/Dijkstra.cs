namespace Learn;

public class Dijkstra : PrioritySearch
{
    public Dijkstra(WeightedGraph graph) : base(graph, new NullHeuristic())
    {
    }
}