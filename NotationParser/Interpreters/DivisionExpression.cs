using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Interpreters
{
    public class DivisionExpression : IMathExpresion
    {
        private IMathExpresion Left;
        private IMathExpresion Right;
        public DivisionExpression(IMathExpresion left, IMathExpresion right)
        {
            Left = left;
            Right = right;
        }
        public decimal Evaluate()
        {
            var leftValue = Left.Evaluate();
            var rightValue = Right.Evaluate();
            if (rightValue == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            return leftValue / rightValue;
        }
    }
}
