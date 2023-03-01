namespace Learn;

public interface IFilter<T>
{
    public bool FilterValid(SearchState<T> state, Move move);
}