using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
    public delegate T MyFunc<T>(T op1, T op2);
    public class Program
    {
        public static void Main(string[] args)
        {
            double result = 0;
            System.Console.WriteLine("Введите выражение (например 2 + 4 ) : ");
            string input = Console.ReadLine().Trim();
            string[] nums = input.Split('+', '-', '/', '*');
            string[] symbs = input.Split(nums, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < symbs.Length; i++)
            {
                MyFunc<double> func = symbs[i] switch
                {
                    "-" => Sub,
                    "*" => Mult,
                    "/" => Div,
                    _ => Sum
                };
                result += func(double.Parse(nums[i]), double.Parse(nums[i + 1]));
            }
            System.Console.WriteLine($"result : {result}");
        }
        public static T Sum<T>(T op1, T op2) => (dynamic)op1 + (dynamic)op2;
        public static T Sub<T>(T op1, T op2) => (dynamic)op1 - (dynamic)op2;
        public static T Mult<T>(T op1, T op2) => (dynamic)op1 * (dynamic)op2;
        public static T Div<T>(T op1, T op2) => (dynamic)op1 / (dynamic)op2;
    }
}