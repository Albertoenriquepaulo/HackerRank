using System;
using System.ComponentModel;
using System.Linq;

namespace Mini_MaxSum
{
    class Program
    {
        // Complete the miniMaxSum function below.
        static void miniMaxSum(int[] arr)
        {
            if (arr?.Length == 0 || arr == null)
            {
                return;
            }

            ulong min = 0;
            ulong max = 0;

            var numbers = arr.Select(x => (ulong)x).ToList();
            for (var index = 0; index < numbers.Count; index++)
            {
                var numbersWithoutOneElement = numbers.Where((_, i) => i != index).ToList();
                var tempSum = numbersWithoutOneElement.Aggregate((a, b) => a + b);

                if (index == 0)
                {
                    min = max = tempSum;
                }
                if (tempSum < min)
                {
                    min = tempSum;
                }
                else if (tempSum > max)
                {
                    max = tempSum;
                }
            }

            Console.WriteLine($"{min} {max}");
        }
        static void Main(string[] args)
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            miniMaxSum(arr);
        }
    }
}
