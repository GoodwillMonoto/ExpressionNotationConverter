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
          bracketHandler.Handle();
          
        }

        private void HandleDivision()
        {
            var divisionHandler = new DivisionHandlerCommand(expression: Expression);
            divisionHandler.Handle();
        }

        private void HandleMultiplication()
        {
            var multiplicationHandler = new MultiplicationHandlerCommand(expression: Expression);
            multiplicationHandler.Handle();
        }

        private void HandleAddition()
        {
            var additionHandler = new AdditionHandlerCommand(expression: Expression);
            additionHandler.Handle();
        }

        private void HandleSubtraction()
        {
            var subtractionHandler = new SubtractionHandlerCommand(expression: Expression);
            subtractionHandler.Handle();
        }
    }
}
