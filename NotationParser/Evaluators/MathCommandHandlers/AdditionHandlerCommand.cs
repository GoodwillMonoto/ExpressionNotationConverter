using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public class AdditionHandlerCommand : IMathCommandHandler
    {
        public decimal? ResultValue;

        public string Expression;

        public string ReplacedExpression;

        public void Handle(string expression)
        {

        }
    }
}
