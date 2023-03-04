namespace Learn;

public class SearchState<T>
{
    public Matrix2d<T> Grid {get; set;}
    public Matrix2d<(int, int)> Visited {get; set;}

    public SearchState()
    {
        Grid = Matrix2d<T>.Empty(default(T)!);
        Visited = Matrix2d<(int, int)>.Empty((0,0));
    }

    public static SearchState<T> GenerateEmpty(T defaultState, (int, int) defaultOrigin)
    {
        var state = new SearchState<T>
        {
            Grid = Matrix2d<T>.Empty(defaultState),
            Visited = Matrix2d<(int, int)>.Empty(defaultOrigin)
        };
        return state;
    }
}