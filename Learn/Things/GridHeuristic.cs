namespace Learn
{
    public class GridHeuristic : IHeuristic
    {
        public int Calculate((int,int) pos, (int,int) goal)
        {
            return Math.Abs(goal.Item1 - pos.Item1) + Math.Abs(goal.Item2 - pos.Item2);
        }
    }
}