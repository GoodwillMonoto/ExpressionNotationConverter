using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser
{
    public class Expression
    {
        public string Mathexpression;
        public MathOperator MathOperator;

        public Expression(String expression)
        {
            Mathexpression = expression;
        }

        public Expression(String leftExpression, String rightExpression, MathOperator mathOperator)
        {
            Mathexpression = $"{leftExpression} {mathOperator.OperatorToken} {rightExpression}";
            MathOperator = mathOperator;
        }

    }
}
