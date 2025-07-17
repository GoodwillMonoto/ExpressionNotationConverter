namespace MathNotationParser.Interpreters
{
    public class AdditionExpression : IMathExpresion
    {
        private IMathExpresion Left;
        private IMathExpresion Right;
        public AdditionExpression(IMathExpresion left, IMathExpresion right)
        {
            Left = left;
            Right = right;
        }
        public decimal Evaluate()
        {
            return Left.Evaluate() + Right.Evaluate();
        }
    }
}
