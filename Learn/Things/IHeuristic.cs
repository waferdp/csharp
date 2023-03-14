namespace Learn
{
    public interface IHeuristic
    {
        public int Calculate((int,int) pos, (int,int) goal) { return 0; }
    }
}