namespace Learn
{
    public class BreadthFirst<T>
    {
        private Matrix2d<T> matrix;
        private Matrix2d<(int,int)> visited;
        private readonly List<(int, int)> moves;


        public BreadthFirst(Matrix2d<T> data)
        {
            moves = new List<(int , int)>{(1, 0), (0, 1), (-1, 0), (0, -1)};
            visited = Matrix2d<(int, int)>.Empty((0, 0));
            matrix = data;
        }

        public List<(int, int)> Search((int, int) start, (int, int) goal)
        {
            var pos = new List<(int, int)> { start};
            while (!pos.Any(p => p == goal))
            {
                var newPos = new List<(int, int)>();
                foreach(var p in pos)
                {
                    var neighbors = GetVisitableNeighbors(p);
                    foreach(var neighbor in neighbors)
                    {
                        visited[neighbor.Item1, neighbor.Item2] = p;
                        newPos.Add(neighbor);
                    }
                }
            }
            return FindShortestRoute(start, goal);
        }

        private List<(int, int)> FindShortestRoute((int, int) start, (int, int) goal)
        {
            var pos = goal;
            var path = new List<(int, int)>();
            while(pos != start)
            {
                path.Add(pos);
                pos = visited[pos.Item1, pos.Item2];
            }
            return path;
        }


        private List<(int, int)> GetVisitableNeighbors((int, int) position)
        {
            var neighbors = moves.Select(move => (position.Item1 + move.Item1, position.Item2 + move.Item2)).Where(move => matrix.ContainsXY(move));
            return neighbors.Where(neighbor => !visited.ContainsXY(neighbor)).ToList();
        }
    }
}