namespace MathNotationParser.Interpreters
{
    public class SubtractionExpression : IMathExpresion
    {
        private IMathExpresion Left;
        private IMathExpresion Right;
        public SubtractionExpression(IMathExpresion left, IMathExpresion right)
        {
            Left = left;
            Right = right;
        }
        public decimal Evaluate()
        {
            return Left.Evaluate() - Right.Evaluate();
        }
    }
}
