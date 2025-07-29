using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators
{
    public interface INotationEvaluator
    {
        public void SetExpression(string expression);
        public Decimal Evaluate();
    }
}
