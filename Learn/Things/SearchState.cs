namespace Learn;

public class SearchState<T>
{
    public Matrix2d<T> Grid {get; set;}
    public Matrix2d<(int, int)> Visited {get; set;}

    public SearchState(Matrix2d<T> grid, Matrix2d<(int, int)> visited)
    {
        Grid = grid;
        Visited = visited;
    }

    public static SearchState<T> GenerateEmpty(T defaultState, (int, int) defaultOrigin)
    {
        var grid = Matrix2d<T>.Empty(defaultState);
        var visited = Matrix2d<(int, int)>.Empty((0,0));
        return new SearchState<T>(grid, visited);
    }
}