// See https://aka.ms/new-console-template for more information

using MathNotationParser.NotationParsers;
PostfixToInfixParser parser = new PostfixToInfixParser();
Console.WriteLine("This is a simple console application to convert expression notations:");
Console.WriteLine("It supports postfix to infix notatation");
Console.WriteLine("Please ensure you have atleast one charater of space between numbers an oporators");
Console.WriteLine("Example: 3 4 + 5 *");
Console.WriteLine("Please enter a postfix string for conversion");
string input = Console.ReadLine();
var result = parser.ToInfix(input);
Console.WriteLine("The converted infix expression is:");
Console.WriteLine(result);





