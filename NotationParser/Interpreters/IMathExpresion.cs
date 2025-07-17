using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Interpreters
{
    public interface IMathExpresion
    {
        public decimal Evaluate();
    }
}
