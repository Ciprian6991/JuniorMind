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
            ThrowExceptions(operation);

            var seed = Enumerable.Empty<double>();

            var result = operation.Split().Aggregate(seed, (operands, current) =>
                                                      IsOperator(current)
                                                    ? GetNewResult(operands, current)
                                                    : operands.Append(Convert.ToDouble(current)));

            return result.Last();
        }

        private IEnumerable<double> GetNewResult(IEnumerable<double> operands, string current)
        {
            const int skip = 2;

            var curentResult = Operate(operands.Take(skip), current);

            return operands.Skip(skip).Append(curentResult).Reverse();
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

                case "%":
                    return operand1 % operand2;

                default:
                    return operand1 / operand2;
            }
        }

        private bool IsOperator(string element)
        {
            return "+-*/%".Contains(element);
        }

        private void ThrowExceptions(string expression)
        {
            if (expression != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(expression));
        }
    }
}
