// See https://aka.ms/new-console-template for more information
using System.Dynamic;
using System.Text.RegularExpressions;

namespace Learn 
{

    public class Program
    {

        private static int CalcProduct(string filename) 
        {
            var lines = Reader.readLines(filename);
            var parsed = ParseInput(lines);
            //var valid =  parsed.Where(line => IsBetween(line));
            var valid =  parsed.Where(line => IsCorrect(line));
            return valid.Count();
        }

        private static bool IsBetween(PasswordLine line) 
        {
            var letter = line.Letter;
            var count = line.Password?.Count(c => c == letter);
            return count >= line.Low && count <= line.High;
        }

        private static bool IsCorrect(PasswordLine line)
        {
            var letter = line.Letter;
            var low = line.Low - 1;
            var high = line.High - 1;
            return line.Password?[low] == letter ^ line.Password?[high] == letter;
        }

        private static IEnumerable<PasswordLine> ParseInput(IEnumerable<String> input)
        {
            var numberMatch = new Regex("([0-9]+)");
            var letterMatch = new Regex("[a-z]");

            var parsed = new List<PasswordLine>();
            foreach(var line in input) 
            {
                var numbers =  numberMatch.Match(line);
                var low = int.Parse(numbers.Value);
                var high = int.Parse(numbers.NextMatch().Value);
                var letter = letterMatch.Match(line).Value[0];
                var password =line.Split(":")[1].Trim();
                var passwordLine = new PasswordLine()
                {
                    Low = low,
                    High = high,
                    Letter = letter,
                    Password = password
                };
                parsed.Add(passwordLine);
            }
            return parsed;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Test: " + CalcProduct(@"test_input.txt"));
            Console.WriteLine("Result: " + CalcProduct(@"input.txt"));
        }
    }
}


