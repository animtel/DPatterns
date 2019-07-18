using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DPatterns.Patterns.BehavioralPatterns.Interpreter
{
    //Interpreter - pattern which give for us opportunity for textual input precessing into oop structures, and after that turning this structures into complicated process;
    //OR
    //A component that process structured text data. Does so by turning it into separate lexical tokens (lexing) and then interpreting sequences of said tokens(parsing);
    //We can use it for:
    //HTML and XML parsing;
    //For numeric expression;
    //Regular Expressions;
    //Programming language compilers and interpreters, and IDE;
    //This pattern we can to split into two parts: lexing and parsing

    //Part 1:
    //Lexer - it's functionality which provide us set of tokens from input;
    //Token - it's presentation of symbol or part of expression which we want to split to the different cell
    //For example we have expression: "(13+4)-(12+1)" and after lexer it should see smth like this: `(`     `13`    `+`     `4`     `)`     `-`     `(`     `12`    `+`     `1`     `)`

    //Part 2:
    //On to the parsing process. All we need to do is turn a sequence of
    //Tokens into a binary tree of IExpressions.
    class InterpreterClient : IClient
    {
        public InterpreterClient()
        {
            Execute();
        }
        public void Execute()
        {
            string input = "(13+4)-(12+1)";
            var tokens = Lex(input);
            Console.WriteLine(string.Join("\t", tokens));
            var parsed = Parse(tokens);
            Console.WriteLine($"{input} = {parsed.Value}");
        }

        #region Part1: Lexing

        static List<Token> Lex(string input)
        {
            var result = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i]) // yep, this code seems not clearly, you should understand, that here nice place for chain of responsibility, but for easy understanding i dont realize it here.
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Token.Type.Lparen, "("));
                        break;
                    case ')':
                        result.Add(new Token(Token.Type.Rparen, ")"));
                        break;
                    default:
                        var sb = new StringBuilder(input[i].ToString());
                        for (int j = i + 1; j < input.Length; ++j) //retrieving full number; FYI if we have number 145, we need to write to the token 145, not 1, for that i'm using loop
                        {
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                ++i;
                            }
                            else
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                break;
                            }
                        }
                        break;
                }
            }

            return result;
        }

        class Token
        {
            public enum Type
            {
                Integer,
                Plus,
                Minus,
                Lparen,
                Rparen
            }

            public Type MyType;
            public string Text;

            public Token(Type myType, string text)
            {
                MyType = myType;
                Text = text;
            }

            public override string ToString()
            {
                return $@"`{Text}`";
            }

        }

        #endregion

        #region Part2: Parsing

        static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.Type.Plus:
                        result.MyOperationType = BinaryOperation.OperationType.Addition;
                        break;
                    case Token.Type.Minus:
                        result.MyOperationType = BinaryOperation.OperationType.Substraction;
                        break;
                    case Token.Type.Lparen:
                        int j = i;
                        for (; j < tokens.Count; ++j)
                            if (tokens[j].MyType == Token.Type.Rparen)
                                break; // found it!
                        // process subexpression w/o opening
                        var subExpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subExpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = element;
                        }

                        i = j; // advance
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }


        interface IElement // At the top, it is often useful to have an abstract class or interface that all elements of the tree implement
        {
            int Value { get; }
        }

        class Integer : IElement
        {
            public int Value { get; }

            public Integer(int value)
            {
                Value = value;
            }
        }

        class BinaryOperation : IElement // In pseudo-code, for "2 + 3" expression, binary operation seems like this: BinaryOperation{Literal{2}, Literal{3}, addition}
        {
            public enum OperationType
            {
                Addition, Substraction
            }

            public OperationType MyOperationType;
            public IElement Left, Right;

            public int Value
            {
                get
                {
                    switch (MyOperationType)
                    {
                        case OperationType.Addition:
                            return Left.Value + Right.Value;
                        case OperationType.Substraction:
                            return Left.Value - Right.Value;
                        default:
                            throw new ArgumentNullException();
                    }
                }
            }
        }

        #endregion
    }
}
