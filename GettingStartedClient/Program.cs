using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GettingStartedClient.CalcServiceReference;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CalcClient();

            for (string userInput = Console.ReadLine(); userInput != null; userInput = Console.ReadLine())
            {
                try
                {
                    (double a, double b, char op) = ParseInput(userInput);
                    double result = 0;
                    switch (op)
                    {
                        case '+':
                            result = client.Add(a, b);
                            break;
                        case '-':
                            result = client.Subtract(a, b);
                            break;
                        case '*':
                            result = client.Multiply(a, b);
                            break;
                        case '/':
                            result = client.Divide(a, b);
                            break;
                        case '^':
                            result = client.Power(a, b);
                            break;
                        default:
                            throw new FormatException();
                    }
                    Console.WriteLine($"{result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }

        private static (double a, double b, char op) ParseInput(string userInput)
        {
            userInput = Regex.Replace(userInput, "\\s", "");

            var firstStr = new StringBuilder();
            var secondStr = new StringBuilder();
            char op = ' ';
            var operations = new[] { '+', '-', '*', '/', '^' };
            bool isFirstNumber = true;

            foreach (var character in userInput)
            {
                if (operations.Contains(character))
                {
                    op = character;
                    switch (isFirstNumber)
                    {
                        case true:
                            isFirstNumber = false;
                            break;
                        case false:
                            throw new FormatException();
                    }
                } 
                else if (char.IsDigit(character) || character == ',')
                {
                    if (isFirstNumber)
                    {
                        firstStr.Append(character);
                    }
                    else
                    {
                        secondStr.Append(character);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }

            op = op != ' ' ? op : throw new FormatException();
            double a = double.Parse(firstStr.ToString());
            double b = double.Parse(secondStr.ToString());
            return (a, b, op);
        }
    }
}
