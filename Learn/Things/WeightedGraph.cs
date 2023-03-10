namespace Learn;

public class WeightedGraph
{
    private Dictionary<(int,int), Dictionary<(int,int), int>> nodes;
    private PriorityQueue<((int,int), (int,int)), int> heap;
    private List<(int,int)> Moves = new List<(int , int)>{(1, 0), (0, 1), (-1, 0), (0, -1)};

    public WeightedGraph()
    {
        nodes = new Dictionary<(int, int), Dictionary<(int, int), int>>();
        heap = new PriorityQueue<((int, int), (int, int)), int>();
    }

    public static WeightedGraph CreateFromGrid(Matrix2d<int> grid, int? notVisitable = null)
    {
        var graph = new WeightedGraph();
        for(int y = 0; y < grid.Height; y++)
        {
            for(int x = 0; x < grid.Width; x++)
            {
                var neighbors = graph.Moves
                    .Select(move => (x + move.Item1, y + move.Item2))
                    .Where(move => move.Item1 >= 0 && move.Item1 < grid.Width && move.Item2 >= 0 && move.Item2 < grid.Height);
                if(notVisitable.HasValue)
                {
                    neighbors = neighbors.Where(move => grid[move.Item1, move.Item2] != notVisitable);
                }
                neighbors = neighbors.ToList();
                foreach(var neighbor in neighbors)
                {
                    graph.SetLeg((x,y), neighbor, grid[neighbor.Item1, neighbor.Item2]);
                }
            }
        }
        return graph;
    }

    public void SetLeg((int, int) source, (int,int) destination, int cost)
    {
        if (!nodes.ContainsKey(source))
        {
            nodes[source] = new Dictionary<(int, int), int>();
        }
        if (!nodes[source].ContainsKey(destination))
        {
            nodes[source][destination] = cost;
        }
    }

    public bool Contains((int,int) node)
    {
        return nodes.ContainsKey(node);
    }

    public List<(int, int)> GetNeighbors((int, int) node)
    {
        return nodes[node].Keys.ToList();
    }

    public int GetCost((int, int) source, (int,int) destination)
    {
        return nodes[source][destination];
    }

    public int GetCost(((int,int),(int,int)) move)
    {
        return GetCost(move.Item1, move.Item2);
    }
}