using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNotationParser
{
    public class MathOperator
    {
        public char OperatorToken { get; set; }
        public int Precedence { get; set; }
        public bool IsLeftAssociative { get; set; }



        public MathOperator(char operatorToken, int precedence, bool isLeftAssociative = true ) 
        {
            OperatorToken = operatorToken;
            Precedence = precedence;
            IsLeftAssociative = isLeftAssociative;
        }


    }
}
