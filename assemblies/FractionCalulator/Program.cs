using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FractionCalulator.Structures;

namespace FractionCalulator
{
    class Program
    {
        private static readonly string REG_EXPR = @"((?:[1-9][0-9]*|0)(?:\/[1-9][0-9]*)?)[\s+]?([\+|\-|\*|/])?";
        static void Main(string[] args)
        {
            bool proceed = true;
            Dictionary<string, Func<Fraction, Fraction, Fraction>> commands = new Dictionary<string, Func<Fraction, Fraction, Fraction>>()
            {
                { "+", (a, b) => a + b},
                { "-", (a, b) => a - b},
                { "/", (a, b) => a / b},
                { "*", (a, b) => a * b},
            };
            Console.WriteLine("Hi folks this is Fraction calculator!");
            Console.WriteLine("Put operation in a form fraction operation fraction exmpl: '1/2 + 1/3'");
            Console.WriteLine("Type 's' to stop");
            while (proceed)
            {
                var input = Console.ReadLine();
                if (input.Equals("s"))
                {
                    proceed = false;
                    continue;
                }
                var matches = Regex.Matches(input, REG_EXPR);
                var f1 = matches[0].Groups[1].Value;
                var operation = matches[0].Groups[2].Value;
                var f2 = matches[1].Groups[1].Value;

                if (!commands.TryGetValue(operation.Trim(), out var operationFunc))
                {
                    Console.WriteLine("Unsupported operation");
                }
                else
                {
                    var res = operationFunc(new Fraction(f1), new Fraction(f2));
                    Console.WriteLine($"={res}");
                }
            }
        }
    }
}
