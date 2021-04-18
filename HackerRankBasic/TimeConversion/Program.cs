using System;
using System.Linq;

namespace TimeConversion
{
    class Program
    {
        static string timeConversion(string s)
        {
            var resultList = s.Substring(0, s.Length - 2).Split(':').ToList();

            if (int.TryParse(resultList.FirstOrDefault(), out var hour) == false)
            {
                return null;
            }

            resultList.Add(s.Substring(s.Length - 2));
            var isAM = resultList.LastOrDefault() == "AM" ? true : false;

            if (!isAM)
            {
                resultList[0] = (hour + 12).ToString();
            }

            if (hour == 12)
            {
                resultList[0] = isAM ? "00" : hour.ToString();
            }
            var result = string.Join(':', resultList.Take(3)) + resultList.LastOrDefault();

            return result;
        }

        static void Main(string[] args)
        {
            //string s = Console.ReadLine();
            string s = "1:05:45PM";

            string result = timeConversion(s);

            Console.WriteLine(result);
        }
    }
}
