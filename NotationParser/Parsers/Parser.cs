using MathNotationParser.Evaluators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Parsers
{
    public abstract class Parser
    {
        protected IReadOnlyDictionary<char, MathOperator> operators = new Dictionary<char, MathOperator>
        {
            { '+', new MathOperator('+', 2) },
            { '-', new MathOperator('-', 2) },
            { '/', new MathOperator('/', 3) },
            { '*', new MathOperator('*', 3) }
        };

        protected abstract void Parse(string input);
    }
}
