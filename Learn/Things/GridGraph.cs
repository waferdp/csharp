namespace Learn;

public class GridGraph : Graph
{
    private List<(int,int)> Moves = new List<(int , int)>{(1, 0), (0, 1), (-1, 0), (0, -1)};

    public GridGraph(int width, int height) : base()
    {
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                var neighbors = Moves
                    .Select(move => (x + move.Item1, y + move.Item2))
                    .Where(move => move.Item1 >= 0 && move.Item1 < width && move.Item2 >= 0 && move.Item2 < height)
                    .ToList();
                AddNode((x,y), neighbors);
            }
        }
    }
}