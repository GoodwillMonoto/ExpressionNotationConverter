using MathNotationParser.Evaluators.MathCommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators
{
    public class InfixEvaluator : INotationEvaluator
    {
        public string Expression;
        public decimal Result { get; private set; }

        protected IReadOnlyDictionary<char, MathOperator> operators = new Dictionary<char, MathOperator>
        {
            { '+', new MathOperator('+', 2) },
            { '-', new MathOperator('-', 2) },
            { '/', new MathOperator('/', 3) },
            { '*', new MathOperator('*', 3) },
            { '(', new MathOperator('(', 4) }
        };

        public InfixEvaluator()
        {

        }

        public void SetExpression(string expression)
        {
            Expression = expression;
        }

        public Decimal Evaluate()
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

            if (!decimal.TryParse(Expression, out var result))
            {
                throw new InvalidOperationException("Failed to parse the final result from the expression.");
            }

            Result = result;

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
          Expression = bracketHandler.ResultExpression;

        }

        private void HandleDivision()
        {
            var divisionHandler = new DivisionHandlerCommand(expression: Expression);
            divisionHandler.Handle();
            Expression = divisionHandler.ResultExpression;
        }

        private void HandleMultiplication()
        {
            var multiplicationHandler = new MultiplicationHandlerCommand(expression: Expression);
            multiplicationHandler.Handle();
            Expression = multiplicationHandler.ResultExpression;
        }

        private void HandleAddition()
        {
            var additionHandler = new AdditionHandlerCommand(expression: Expression);
            additionHandler.Handle();
            Expression = additionHandler.ResultExpression;
        }

        private void HandleSubtraction()
        {
            var subtractionHandler = new SubtractionHandlerCommand(expression: Expression);
            subtractionHandler.Handle();
            Expression = subtractionHandler.ResultExpression;
        }
    }
}
