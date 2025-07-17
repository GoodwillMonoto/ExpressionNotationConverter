namespace MathNotationParser.Interpreters
{
    public class MutliplicationExpression : IMathExpresion
    {
        private IMathExpresion Left;
        private IMathExpresion Right;
        public MutliplicationExpression(IMathExpresion left, IMathExpresion right)
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
