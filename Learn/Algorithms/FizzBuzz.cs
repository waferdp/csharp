namespace Learn;

public class FizzBuzz
{
    public static IEnumerable<string> Fizz(int until = 100)  
    {
        return Enumerable.Range(1, until).Select(i => 
        {
            var line = string.Empty;
            if (i % 3 == 0) { line += "Fizz"; }
            if (i % 5 == 0) { line += "Buzz"; }
            return line == string.Empty ? i.ToString(): line;
        });
    }

    public static string OnelineFizz(int until = 100)
    {
        return string.Join("", Fizz(until));
    }
}