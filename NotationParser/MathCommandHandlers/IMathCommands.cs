using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser.MathCommands
{
    public interface IMathCommandHandler
    {
        public void Handle(string expression);
    }
}
