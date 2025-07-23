namespace MathNotationParser.Interpreters
{
    public class MultiplicationExpression : IMathExpresion
    {
        private IMathExpresion Left;
        private IMathExpresion Right;
        public MultiplicationExpression(IMathExpresion left, IMathExpresion right)
        {
            Left = left;
            Right = right;
        }
        public decimal Evaluate()
        {
            return Left.Evaluate() * Right.Evaluate();
        }
    }
}
