using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser
{
    public class PostfixToInfixParser : Parser
    {
        protected override string Parse(string rpnstring)
        {
            var expressParseList = rpnstring.Split(' ');
            var expressionStack = new Stack<Expression>();

            foreach (var parseItem in expressParseList)
            {
                // Check if the item is an operator
                if (operators.ContainsKey(parseItem[0]) && parseItem.Length == 1)
                {
                    var mathOperator = operators[parseItem[0]];
                    var rightExpression = expressionStack.Pop();
                    var leftExpression = expressionStack.Pop();


                    // Check precedence and add parentheses if necessary
                    int leftPrecedence = leftExpression.MathOperator != null  ? leftExpression.MathOperator.Precedence : 10 ;
                    int rightPrecedence = rightExpression.MathOperator != null ? rightExpression.MathOperator.Precedence : 10;

                    if ((leftPrecedence < mathOperator.Precedence || (leftPrecedence == mathOperator.Precedence)))
                        leftExpression.Mathexpression = '(' + leftExpression.Mathexpression + ')';

                    if ((rightPrecedence < mathOperator.Precedence || (rightPrecedence == mathOperator.Precedence)))
                        rightExpression.Mathexpression = '(' + rightExpression.Mathexpression + ')';

                    expressionStack.Push(new Expression(leftExpression.Mathexpression,rightExpression.Mathexpression,mathOperator));
                }
                else
                {
                    expressionStack.Push(new Expression(parseItem));
                }
            }
         
           return expressionStack.Peek().Mathexpression;
        }

        public string ToInfix(string rpnstring)
        {

            return Parse(rpnstring);
        }
    }

}