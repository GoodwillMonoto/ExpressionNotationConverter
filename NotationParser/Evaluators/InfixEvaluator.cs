using MathNotationParser.Evaluators.MathCommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators
{
    public class InfixEvaluator : INotationEvaluator
    {
        public string Expression;
        public double Result { get; private set; }

        protected IReadOnlyDictionary<char, MathOperator> operators = new Dictionary<char, MathOperator>
        {
            { '+', new MathOperator('+', 2) },
            { '-', new MathOperator('-', 2) },
            { '/', new MathOperator('/', 3) },
            { '*', new MathOperator('*', 3) },
            { '(', new MathOperator('(', 4) }
        };


        public InfixEvaluator(string expression)
        {
            Expression = expression;
        }

        public double Evaluate()
        {
            while (ExpressionContainsOperators())
            {
                var currentOperator = operators
                    .Where(op => Expression.Contains(op.Key))
                    .OrderByDescending(op => op.Value.Precedence)
                    .FirstOrDefault();

                switch (currentOperator.Key)
                {
                    case '(':
                        HandleBrackets();
                        break;
                    case '/':
                        HandleDivision();
                        break;
                    case '*':
                        HandleMultiplication();
                        break;
                    case '+':
                        HandleAddition();
                        break;
                    case '-':
                        HandleSubtraction();
                        break;
                    default:
                        throw new InvalidOperationException("Unknown operator in expression.");
                }
            }

            return Result;
        }

        private bool ExpressionContainsOperators()
        {
            foreach (var op in operators)
            {
                if (Expression.Contains(op.Key))
                {
                    return true;
                }
            }
            return false;
        }

        private void HandleBrackets()
        {
          var bracketHandler = new BracketHandlerCommand(expression: Expression);
        }

        private void HandleDivision()
        {
            // Logic to handle division in the expression
            // This will involve finding division operators and evaluating them
        }

        private void HandleMultiplication()
        {
            // Logic to handle multiplication in the expression
            // This will involve finding multiplication operators and evaluating them
        }

        private void HandleAddition()
        {
            // Logic to handle addition in the expression
            // This will involve finding addition operators and evaluating them
        }

        private void HandleSubtraction()
        {
            // Logic to handle subtraction in the expression
            // This will involve finding subtraction operators and evaluating them
        }
    }
}
