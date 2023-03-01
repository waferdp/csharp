namespace Learn;

public class AvoidVisitedFilter<T> : IFilter<T>
{
    public bool FilterValid(SearchState<T> state, Move move)
    {
        return !state.Visited?.ContainsXY(move.Destination) ?? false;
    }
}