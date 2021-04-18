using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BirthdayCakeCandles
{
    class Result
    {

        /*
         * Complete the 'birthdayCakeCandles' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY candles as parameter.
         */

        public static int birthdayCakeCandles(List<int> candles)
        {
            var item = candles.Max(x => x);

            return candles.Count(x => x == item);

            // var tal = candles.Count(x => x == candles.Max(x => x));
            // This seems to be better but consume much more time than the two lines below
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

            var candles = Console.ReadLine()?.TrimEnd().Split(' ').ToList()
                .Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

            var result = Result.birthdayCakeCandles(candles);

        }
    }
}