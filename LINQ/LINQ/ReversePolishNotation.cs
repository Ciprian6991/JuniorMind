using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class ReversePolishNotation
    {
        private readonly string operation;

        public ReversePolishNotation(string input)
        {
            this.operation = input;
        }

        public double Calculate()
        {
            var seed = Enumerable.Empty<double>();

            var result = operation.Split().Aggregate(seed, (operands, current) =>
                                                      IsOperator(current)
                                                    ? GetNewResult(operands, current)
                                                    : operands.Append(Convert.ToDouble(current)));

            return result.First();
        }

        private IEnumerable<double> GetNewResult(IEnumerable<double> operands, string current)
        {
            const int skip = 2;

            return operands.SkipLast(skip)
                                          .Append(Operate(
                                                          operands.TakeLast(skip), current));
        }

        private double Operate(IEnumerable<double> values, string toOperate)
        {
            double operand1 = values.First();

            double operand2 = values.Last();

            switch (toOperate)
            {
                case "+":
                    return operand1 + operand2;

                case "-":
                    return operand1 - operand2;

                case "*":
                    return operand1 * operand2;

                default:
                    return operand1 / operand2;
            }
        }

        private bool IsOperator(string element)
        {
            return "+-*/%".Contains(element);
        }
    }
}
