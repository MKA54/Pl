using Ariph;

namespace Plumsail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = "(MMMDCCXXIV - MMCCXXIX) * II";

            _ = new Calculator();
            var result = Calculator.Evaluate(input);

            Console.WriteLine(result);
        }
    }
}