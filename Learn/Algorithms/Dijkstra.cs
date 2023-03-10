namespace Learn;

public class Dijkstra
{
    private WeightedGraph graph {get; set;}
    private Dictionary<(int,int), (int,int)> visited = new Dictionary<(int, int), (int, int)>();

    public Dijkstra(WeightedGraph graph)
    {
        this.graph = graph;
    }
    
    public List<(int, int)> Search((int, int) start, (int, int) goal)
    {
        var queue = new PriorityQueue<((int,int),(int,int)), int>();
        //var visited = new Dictionary<(int, int), (int, int)>();
        var current  = start;
        var costs = new Dictionary<(int, int), int>();
        costs[start] = 0;
        visited[start] = start;
        var neighbors = graph.GetNeighbors(start);
        foreach(var neighbor in neighbors)
        {
            queue.Enqueue((current, neighbor), graph.GetCost(current,neighbor));
        }

        while(true)
        {
            var move = queue.Dequeue();
            var cost = costs[move.Item1] + graph.GetCost(move);
            costs[move.Item2] = cost;
            visited[move.Item2] = move.Item1;
            neighbors = graph.GetNeighbors(move.Item2).Where(neighbor => !visited.ContainsKey(neighbor)).ToList();
            foreach(var neighbor in neighbors)
            {
                queue.Enqueue((move.Item2,neighbor), cost + graph.GetCost(move.Item2, neighbor));
            }
            current = move.Item2;
            if(move.Item2 == goal || queue.Count == 0)
            {
                break;
            }
        }

        return FindShortestRoute(start, goal);
    }



    private List<(int, int)> FindShortestRoute((int, int) start, (int, int) goal)
    {
        if (!graph.Contains(goal))
        {
            return new List<(int, int)>();
        }
        var pos = goal;
        var path = new List<(int, int)>();
        while(pos != start)
        {
            path.Add(pos);
            pos = visited[pos];
        }
        path.Add(start);
        return path;
    }

    public int GetCostOfRoute((int,int) start, (int,int) goal)
    {
        if (!graph.Contains(goal))
        {
            return 0;
        }
        var pos = goal;
        var cost = 0;
        while(pos != start)
        {
            cost += graph.GetCost(visited[pos], pos);
            pos = visited[pos];
        }
        return cost;
    }
}