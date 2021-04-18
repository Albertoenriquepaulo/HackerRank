using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace GradingStudents
{
    class Result
    {
        public static List<int> gradingStudents(List<int> grades)
        {
            if (!grades.All(x => x >= 0 && x <= 100))
            {
                return null;
            }
            for (var index = 0; index < grades.Count; index++)
            {
                var grade = grades[index];
                int? nextMultipleOfFive;

                if ((nextMultipleOfFive = NextMultipleOfFive(grade)) == null)
                {
                    continue;
                }

                var roundGrade = RoundGrade(grade, (int)nextMultipleOfFive);
                grades[index] = roundGrade != null ? (int)nextMultipleOfFive : grade;
            }

            return grades;
        }

        public static int? NextMultipleOfFive(int number)
        {
            if (number < 38)
            {
                return null;
            }
            var lastDigit = number % 10;
            var factorToAdd = lastDigit < 5 ? 5 - lastDigit : 10 - lastDigit;

            return number + factorToAdd;
        }

        public static int? RoundGrade(int number, int multipleOfFiveNumber)
        {
            if (multipleOfFiveNumber - number < 3)
            {
                return multipleOfFiveNumber;
            }
            return null;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> grades = new List<int>(); //{ 4, 73, 67, 38, 33 };


            for (int i = 0; i < gradesCount; i++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
                grades.Add(gradesItem);
            }

            List<int> result = Result.gradingStudents(grades);

        }
    }
}
