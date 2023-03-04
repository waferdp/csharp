namespace Learn;

public class SearchState<T>
{
    public Matrix2d<T> Grid {get; set;}
    public Matrix2d<(int, int)> Visited {get; set;}

    public SearchState(T defaultState, (int, int) defaultOrigin)
    {
        Grid = Matrix2d<T>.Empty(defaultState);
        Visited = Matrix2d<(int, int)>.Empty(defaultOrigin);
    }
}