using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Channels;
using static System.Int32;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();

            TryParse(Console.ReadLine(), out var times);

            for (var i = 0; i < times; i++)
            {
                numbers.Add(Parse(Console.ReadLine() ?? string.Empty));
            }

            var result = FindPrime(numbers);
            result.ForEach(Console.WriteLine);
        }

        private static List<string> FindPrime(IReadOnlyList<int> numbers)
        {
            var result = new List<string>();
            const string prime = "Prime";
            const string notPrime = "Not prime";

            for (var index = 0; index < numbers.Count; index++)
            {
                var possiblePrime = numbers[index];
                result.Add(prime);

                if (possiblePrime < 2)
                {
                    result[index] = notPrime;
                    continue;
                }

                for (var divisor = 2; divisor <= Math.Sqrt(possiblePrime); divisor++)
                {
                    if (possiblePrime % divisor != 0) continue;
                    result[index] = notPrime;
                    break;
                }
            }

            return result;
        }

    }
}
