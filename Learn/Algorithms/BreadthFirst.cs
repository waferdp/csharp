namespace Learn
{
    public class BreadthFirst<T>
    {
        private Matrix2d<T> matrix;
        private Matrix2d<(int,int)> visited;
        private readonly List<(int, int)> moves;
        private Queue<(int, int)> queue;
        public IList<IFilter<T>> FilterFunctions {get; private set;} = new List<IFilter<T>>();

        public BreadthFirst(Matrix2d<T> data)
        {
            moves = new List<(int , int)>{(1, 0), (0, 1), (-1, 0), (0, -1)};
            visited = Matrix2d<(int, int)>.Empty((0, 0));
            queue = new Queue<(int, int)>();
            FilterFunctions.Add(new AvoidVisitedFilter<T>());
            matrix = data;
        }

        public List<(int, int)> Search((int, int) start, (int, int) goal)
        {
            queue.Enqueue(start);
            visited[start.Item1, start.Item2] = (0,0);
            while (queue.Any() && !queue.Contains(goal))
            {
                var pos = queue.Dequeue();
                var neighbors = GetVisitableNeighbors(pos);
                foreach(var neighbor in neighbors)
                {
                    visited[neighbor.Item1, neighbor.Item2] = pos;
                    queue.Enqueue(neighbor);
                }
            }
            return FindShortestRoute(start, goal);
        }

        private List<(int, int)> FindShortestRoute((int, int) start, (int, int) goal)
        {
            if (!matrix.ContainsXY(goal))
            {
                return new List<(int, int)>();
            }
            var pos = goal;
            var path = new List<(int, int)>();
            while(pos != start)
            {
                path.Add(pos);
                pos = visited[pos.Item1, pos.Item2];
            }
            path.Add(start);
            return path;
        }

        private List<(int, int)> GetVisitableNeighbors((int, int) position)
        {
            var neighbors = moves.Select(move => (position.Item1 + move.Item1, position.Item2 + move.Item2)).Where(move => matrix.ContainsXY(move));
            var state = new SearchState<T>(matrix, visited);

            foreach(var filter in FilterFunctions)
            {
                neighbors = neighbors.Where(neighbor => filter.FilterValid(state, new Move(position, neighbor)));
            }
            return neighbors.ToList();
        }
    }
}