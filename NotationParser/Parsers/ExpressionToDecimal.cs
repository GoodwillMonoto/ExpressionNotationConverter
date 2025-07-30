using MathNotationParser.Evaluators.MathCommandHandlers;
using MathNotationParser.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Parsers
{
    public class InfixToDecimalParser : Parser
    {
        public string Input;
        public Decimal Ouput;
        private int OperationsCount = 0;

        protected override void Parse(string input)
        {
           Input = input;
           

           var tokens = input.Split(' ');

            var initialOperator = operators
                         .Where(op => tokens.Contains(op.Key.ToString()))
                         .OrderByDescending(op => op.Value.Precedence)
                         .FirstOrDefault();

            var initialOperatorIndex = Array.IndexOf(tokens, initialOperator.Key.ToString());

            if (!Decimal.TryParse(tokens[initialOperatorIndex - 1],out decimal initialDecimal))
            {
                 throw new ArgumentException("Invalid input: The first token must be a valid decimal number.");
            }

            

            while(TokensContainOperators(tokens))
            {
                var currentOperator = OperationsCount == 0 ? 
                                        initialOperator :
                                        operators
                                          .Where(op => tokens.Contains(op.Key.ToString()))
                                          .OrderByDescending(op => op.Value.Precedence)
                                          .FirstOrDefault();

                var currentOperatorIndex = OperationsCount == 0 ?
                                            initialOperatorIndex :
                                            Array.IndexOf(tokens, currentOperator.Key.ToString());


                decimal currentLeftDecimal;
                decimal currentRightDecimal;

                if (!Decimal.TryParse(tokens[currentOperatorIndex - 1], out currentLeftDecimal))
                {
                    throw new ArgumentException("Invalid input: The first token must be a valid decimal number.");
                }

                if (!Decimal.TryParse(tokens[currentOperatorIndex + 1], out currentRightDecimal))
                {
                    throw new ArgumentException("Invalid input: The first token must be a valid decimal number.");
                }

                switch (currentOperator.Key)
                {
                    case '/':

                        tokens[currentOperatorIndex - 1] = new  DivisionExpression(new NumberExpression(currentLeftDecimal), new NumberExpression(currentRightDecimal) ).Evaluate().ToString();
                        tokens = tokens.Where((_, index) => index != currentOperatorIndex && index != currentOperatorIndex + 1).ToArray();

                        break;
                    case '*':

                        tokens[currentOperatorIndex - 1] = new MultiplicationExpression(new NumberExpression(currentLeftDecimal), new NumberExpression(currentRightDecimal)).Evaluate().ToString();
                        tokens = tokens.Where((_, index) => index != currentOperatorIndex && index != currentOperatorIndex + 1).ToArray();

                        break;
                    case '+':

                        tokens[currentOperatorIndex - 1] = new AdditionExpression(new NumberExpression(currentLeftDecimal), new NumberExpression(currentRightDecimal)).Evaluate().ToString();
                        tokens = tokens.Where((_, index) => index != currentOperatorIndex && index != currentOperatorIndex + 1).ToArray();

                        break;
                    case '-':

                        tokens[currentOperatorIndex - 1] = new SubtractionExpression(new NumberExpression(currentLeftDecimal), new NumberExpression(currentRightDecimal)).Evaluate().ToString();
                        tokens = tokens.Where((_, index) => index != currentOperatorIndex && index != currentOperatorIndex + 1).ToArray();

                        break;
                    default:
                        throw new InvalidOperationException("Unsupported operator in expression.");
                }
                OperationsCount++;
            }

            Ouput = Decimal.Parse(tokens[0]);

        }

        private bool TokensContainOperators(string[] tokens)
        {
           return tokens.Where(op => operators.ContainsKey(op[0])).Any();
        }

        public Decimal ToDecimal(string expression)
        {
            Parse(expression);
            return Ouput;
        }
    }
}
