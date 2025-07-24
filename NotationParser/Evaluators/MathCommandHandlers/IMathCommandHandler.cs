using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.Evaluators.MathCommandHandlers
{
    public interface IMathCommandHandler
    {
        public void Handle();
    }
}
