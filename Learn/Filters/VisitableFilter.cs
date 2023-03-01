namespace Learn;

public class VisitableFilter<T> : IFilter<T>
{
    private T visitable;

    public VisitableFilter(T visitable)
    {
        this.visitable = visitable;
    }

    public bool FilterValid(SearchState<T> state, Move move)
    {
        var value = state.Grid[move.Destination.Item1, move.Destination.Item2] ?? default(T);
        if (value == null)
        {
            return false;
        }
        return value.Equals(visitable);
    }
}