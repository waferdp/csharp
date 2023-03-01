namespace Learn;

public class Move
{
    public (int, int) Source {get; private set;}
    public (int, int) Destination {get; private set;}
    
    public Move((int,int) source, (int, int) destination)
    {
        Source = source;
        Destination = destination;
    }
}