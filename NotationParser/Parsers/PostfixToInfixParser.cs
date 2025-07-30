using MathNotationParser.Evaluators;
using MathNotationParser.NotationExpressions;
using MathNotationParser.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.NotationParsers
{
    public class PostfixToInfixParser : Parser
    {
        protected INotationEvaluator notationEvaluator { get; set; }
        public string EvaluationString;
        public string Input;
        public string Output;

        public PostfixToInfixParser(INotationEvaluator notationEvaluator)
        {
            this.notationEvaluator = notationEvaluator;
        }

        protected override void Parse(string rpnstring)
        {
            Input = rpnstring;
            var expressParseList = rpnstring.Split(' ');
            var expressionStack = new Stack<InfixExpressionBuilder>();

            foreach (var parseItem in expressParseList)
            {
                // Check if the item is an operator
                if (operators.ContainsKey(parseItem[0]) && parseItem.Length == 1)
                {
                    var mathOperator = operators[parseItem[0]];
                    var rightExpression = expressionStack.Pop();
                    var leftExpression = expressionStack.Pop();


                    // Check precedence and add parentheses if necessary
                    int leftPrecedence = leftExpression.MathOperator != null ? leftExpression.MathOperator.Precedence : 10;
                    int rightPrecedence = rightExpression.MathOperator != null ? rightExpression.MathOperator.Precedence : 10;

                    if (leftPrecedence < mathOperator.Precedence || leftPrecedence == mathOperator.Precedence)
                        leftExpression.Mathexpression = '(' + leftExpression.Mathexpression + ')';

                    if (rightPrecedence < mathOperator.Precedence || rightPrecedence == mathOperator.Precedence)
                        rightExpression.Mathexpression = '(' + rightExpression.Mathexpression + ')';

                    expressionStack.Push(new InfixExpressionBuilder(leftExpression.Mathexpression, mathOperator, rightExpression.Mathexpression));
                }
                else
                {
                    expressionStack.Push(new InfixExpressionBuilder(parseItem));
                }
            }

            Output = expressionStack.Peek().Mathexpression;
        }

        public string ToInfix(string rpnstring)
        {
            Parse(rpnstring);
            return Output;
        }

        public Decimal Evaluate()
        {

            EvaluationString = notationEvaluator switch
            {
                InfixEvaluator infixEvaluator => Output is null ? ToInfix(Input) : Output,
                _ => throw new InvalidOperationException("Unsupported notation evaluator type.")
            };

            notationEvaluator.SetExpression(EvaluationString);
            return notationEvaluator.Evaluate();
        }

        public void EvaluatePrintSteps()
        {
            notationEvaluator.PrintEvaluationSteps();
        }

    }

}