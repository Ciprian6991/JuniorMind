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
            ThrowNullExceptions(operation);
            ThrowInvalidInputExceptions(operation);

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

        private void ThrowNullExceptions(string expression)
        {
            if (expression != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(expression));
        }

        private void ThrowInvalidInputExceptions(string operation)
        {
            var count_Operator_Operand = operation.Split().Aggregate((0, 0), (resultTuple, curentChar) => IsOperator(curentChar) ?
                                                                                        (resultTuple.Item1 + 1, resultTuple.Item2) :
                                                                                        (resultTuple.Item1, resultTuple.Item2 + 1));

            if (count_Operator_Operand.Item1 == count_Operator_Operand.Item2 - 1)
            {
                return;
            }

            throw new ArithmeticException("invalid expression");
        }
    }
}
