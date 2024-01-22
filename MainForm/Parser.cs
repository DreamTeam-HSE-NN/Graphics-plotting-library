using System;

namespace WindowsFormsApp1
{
    public class Expression
    {
        public string token;
        //public Expression arg1;
        //public Expression arg2;
        
        public Expression[] args = new Expression[0];
        public Expression(string token) { this.token = token; }
        public Expression(string token, Expression a)
        {
            this.token = token;
            this.args = new Expression[1];
            this.args[0] = a;
        }
        public Expression(string token, Expression a, Expression b)
        {
            this.token = token;
            this.args = new Expression[2];
            this.args[0] = a;
            this.args[1] = b;
        }
    }
    internal class Parser
    {
        private string _input;
        private int _i;

        public Parser(string expression)
        {
            _input = expression;
        }

        private string ParseToken()
        {
            if (_i == _input.Length - 1) return "";
            while (_input[_i] == ' ') ++_i;
   
            if (Char.IsDigit(_input, _i))
            {
                string number = "";
                while (Char.IsDigit(_input, _i) || _input[_i] == '.')
                {
                    number += _input[_i];
                    ++_i;
                }
                return number;
            }

            switch (_input[_i])
            {
                case '+':
                    ++_i;
                    return "+";
                case '-':
                    ++_i;
                    return "-";
                case '*':
                    ++_i;
                    return "*";
                case '/':
                    ++_i;
                    return "/";
                case '^':
                    ++_i;
                    return "^";
                case 's':
                    if (_input[_i + 1] == 'i')
                    {
                        _i += 2;
                        goto case 'n';
                    }
                    if (_input[_i + 1] == '(')
                    {
                        ++_i;
                        return "cos";
                    }
                    break;
                case 'n':
                    if (_input[_i] == 'n')
                    {
                        ++_i;
                        return "sin";
                    }
                    break;
                
                case '(':
                    ++_i;
                    return "(";
                case ')':
                    ++_i;
                    return ")";
            }
            return "";
        }


        private Expression ParseSimpleExpression()
        {
            string token = ParseToken();
            if (token == "")
                return new Expression("Ivaleb");

            if (token == "(")
            {
                var result = Parse();
                if (ParseToken() != ")") return new Expression("Expexted ) , dalba'b");
                return result;
            }

            if (Char.IsDigit(token[0]))
                return new Expression(token);

            var arg = ParseSimpleExpression();

            return new Expression(token, ParseSimpleExpression());
        }

        private int Get_priority(string op)
        {
            switch (op)
            {
                case "+":
                    return 1;
                case "-":
                    return 1;
                case "*":
                    return 2;
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }
        private Expression ParseBinaryExpression(int minPriority)
        {
            var leftExpr = ParseSimpleExpression();

            while (true)
            {
                var op = ParseToken();
                var priority = Get_priority(op);
                if (priority <= minPriority)
                {
                    _i -= op.Length;
                    return leftExpr;
                }

                var rightExpr = ParseBinaryExpression(priority);
                leftExpr = new Expression(op, leftExpr, rightExpr);
            }
        }

        public Expression Parse()
        {
            return ParseBinaryExpression(0);
        }

        public double Calculate(Expression expr)
        {
            switch (expr.args.Length)
            {
                case 2:
                    var a = Calculate(expr.args[0]);
                    var b = Calculate(expr.args[1]);
                    if (expr.token == "+") return a + b;
                    if (expr.token == "-") return a - b;
                    if (expr.token == "*") return a * b;
                    if (expr.token == "/") return a / b;
                    if (expr.token == "^") return Math.Pow(a, b);
                    if (expr.token == "mod") return (int)a % (int)b;
                    return -1;

                case 1:
                    var c = Calculate(expr.args[0]);
                    if (expr.token == "+") return +c;
                    if (expr.token == "-") return -c;
                    if (expr.token == "abs") return Math.Abs(c);
                    if (expr.token == "sin") return Math.Sin(c);
                    if (expr.token == "cos") return Math.Cos(c);
                    return -3;

                //case 0:
                    //return Double.Parse(expr.token);
            }

            return -2;
        }
    }
}
