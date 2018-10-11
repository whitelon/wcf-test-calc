using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedLib
{

    public class CalcService : ICalc
    {
        public double Add(double a, double b)
        {
            var result = a + b;
            Console.WriteLine($"{a} + {b} -> {result}");
            return result;
        }

        public double Divide(double a, double b)
        {
            var result = a / b;
            Console.WriteLine($"{a} / {b} -> {result}");
            return result;
        }

        public double Multiply(double a, double b)
        {
            var result = a * b;
            Console.WriteLine($"{a} * {b} -> {result}");
            return result;
        }

        public double Power(double number, double power)
        {
            var result = Math.Pow(number, power);
            Console.WriteLine($"{number} + {power} -> {result}");
            return result;
        }

        public double Subtract(double a, double b)
        {
            var result = a - b;
            Console.WriteLine($"{a} - {b} -> {result}");
            return result;
        }
    }

}
