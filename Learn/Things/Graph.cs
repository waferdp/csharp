namespace Learn.Things
{
    public class Graph2d
    {
        private Dictionary<(int, int), List<(int,int)>> nodes;

        public Graph2d()
        {
            nodes = new Dictionary<(int, int), List<(int, int)>>();
        }
        
        public void AddNode((int, int) node, List<(int, int)> neighbors)
        {
            nodes[node] = neighbors;
        }

        public List<(int, int)> GetNeighbors((int, int) node)
        {
            return nodes[node];
        }
    }
}