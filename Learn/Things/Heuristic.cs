namespace Learn
{
    public class Heuristic
    {
        public int Calculate((int,int) pos, (int,int) goal)
        {
            return Math.Abs(goal.Item1 - pos.Item1) + Math.Abs(goal.Item2 - pos.Item2);
        }
    }
}