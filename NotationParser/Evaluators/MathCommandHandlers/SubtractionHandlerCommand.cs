using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class SubtractionHandlerCommand : IMathCommandHandler
    {
        public double value;

        public string expression;

        public void Handle(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
