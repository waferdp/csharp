namespace Learn;

public class WeightedGraph
{
    private Dictionary<(int,int), Dictionary<(int,int), int>> nodes;
    private PriorityQueue<((int,int), (int,int)), int> heap;

    public WeightedGraph()
    {
        nodes = new Dictionary<(int, int), Dictionary<(int, int), int>>();
        heap = new PriorityQueue<((int, int), (int, int)), int>();
    }

    public void SetLeg((int, int) source, (int,int) destination, int cost)
    {
        if (!nodes.ContainsKey(source))
        {
            nodes[source] = new Dictionary<(int, int), int>();
        }
        if (nodes[source][destination] > cost)
        {
            nodes[source][destination] = cost;
        }
        heap.Enqueue((source, destination), cost);
    }

    public List<(int, int)> GetNeighbors((int, int) node)
    {
        return nodes[node].Keys.ToList();
    }

    public int GetCost((int, int) source, (int,int) destination)
    {
        return nodes[source][destination];
    }

    public ((int, int), (int,int)) TakeCheapestMove()
    {
        return heap.Dequeue();
    }
}