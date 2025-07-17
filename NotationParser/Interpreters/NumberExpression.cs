using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Interpreters
{
    public class NumberExpression : IMathExpresion
    {
        private decimal Value;
        public NumberExpression(decimal value)
        {
            Value = value;
        }
        public decimal Evaluate()
        {
            return Value;
        }
    }
}
