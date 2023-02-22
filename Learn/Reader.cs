namespace Learn 
{
    public class Reader
    {
        public static List<string> readLines(string filename)
        {
            return File.ReadLines(filename).ToList<string>();
        }
    }
    
}