using System;
using System.Linq.Expressions;

namespace GraphsPlotting
{
    class Expression
    {
        public string Token;
        //public Expression arg1;
        //public Expression arg2;
        public Expression[] Args = [];
        public Expression(string token) { this.Token = token; }
        public Expression(string token, Expression a)
        {
            this.Token = token;
            this.Args = new Expression[1];
            this.Args[0] = a;
        }
        public Expression(string token, Expression a, Expression b)
        {
            this.Token = token;
            this.Args = new Expression[2];
            this.Args[0] = a;
            this.Args[1] = b;
        }
    }
    class Parcer
    {
        private string _input;
        private int _i;
        public Parcer(string expression)
        {
            _input = expression;
        }

        private string Parse_token()
        {
            if (_i > _input.Length - 1) return "";

            while (_input[_i] == ' ' || _input[_i] == 'y' || _input[_i] == '=')
                if (_i < _input.Length - 1) ++_i; else break;

            if (Char.IsDigit(_input, _i))
            {
                string number = "";
                while (Char.IsDigit(_input, _i) || _input[_i] == '.' || _input[_i] == ',')
                {
                    number += _input[_i];
                    ++_i;
                    if (_i > _input.Length - 1)
                        break;
                }
                return number;
            }

            switch (_input[_i])
            {
                case 'x':
                    ++_i;
                    return "x";
                case 'e':
                    ++_i;
                    return "e";
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
                    if (_input[_i + 1] == 'i' && _input[_i + 2] == 'n')
                    {
                        _i += 3;
                        return "sin";
                    }
                    return "";
                case 'c':
                    if (_input[_i + 1] == 'o' && _input[_i + 2] == 's')
                    {
                        _i += 3;
                        return "cos";
                    }
                    if (_input[_i + 1] == 't' && _input[_i + 2] == 'g')
                    {
                        _i += 3;
                        return "ctg";
                    }
                    return "";
                case 't':
                    if (_input[_i + 1] == 'g')
                    {
                        _i += 2;
                        return "tg";
                    }
                    return "";
                case 'l':
                    if (_input[_i + 1] == 'g')
                    {
                        _i += 2;
                        return "lg";
                    }
                    if (_input[_i + 1] == 'n')
                    {
                        _i += 2;
                        return "ln";
                    }
                    return "";
/*                case 'a':
                    _i++;
                    if (_input[_i] == 's')
                        goto case 's';
                    if (_input[_i] == 'c')
                        goto case 'c';
                    if (_input[_i] == 't')
                        goto case 't';
                    break;
*/
                case '(':
                    ++_i;
                    return "(";
                case ')':
                    ++_i;
                    return ")";
            }
            return "";
        }


        private Expression Parse_simple_expression()
        {
            var token = Parse_token();
            if (token == "")
                return new Expression("Incorrect input");

            if (token == "(")
            {
                var result = Parse();
                if (Parse_token() != ")") return new Expression("Expexted )");
                return result;
            }

            if (Char.IsDigit(token[0]) || token[0] == 'x' || token[0] == 'e')
                return new Expression(token);

            var arg = Parse_simple_expression();

            return new Expression(token, arg);
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
        Expression Parse_binary_expression(int minPriority)
        {
            var leftExpr = Parse_simple_expression();
            if (leftExpr.Args.Length != 0)
            {
                if (leftExpr.Args[0].Token == "Incorrect input" || leftExpr.Args[0].Token == "Expexted )")
                {
                    return leftExpr.Args[0];
                }
            }
            else if (leftExpr.Token == "Incorrect input" || leftExpr.Token == "Expexted )") return leftExpr;

            while (true)
            {
                var op = Parse_token();
                var priority = Get_priority(op);
                if (priority <= minPriority)
                {
                    _i -= op.Length;
                    return leftExpr;
                }

                var rightExpr = Parse_binary_expression(priority);
                leftExpr = new Expression(op, leftExpr, rightExpr);
            }
        }

        public Expression Parse()
        {
            var result = Parse_binary_expression(0);
            if (result.Token == "Incorrect input" || result.Token == "Expexted )")
            {
                MessageBox.Show(result.Token);
                return new Expression("Error");
            }
            else return result;
        }

        private bool Checker(Expression expr)
        {
            return false;
        }
        public double Calculate(Expression expr, double x)
        {
            switch (expr.Args.Length)
            {
                case 2:
                    var a = Calculate(expr.Args[0], x);
                    var b = Calculate(expr.Args[1], x);
                    if (expr.Token == "+") return a + b;
                    if (expr.Token == "-") return a - b;
                    if (expr.Token == "*") return a * b;
                    if (expr.Token == "/") return a / b;
                    if (expr.Token == "^") return Math.Pow(a, b);
                    if (expr.Token == "mod") return (int)a % (int)b;
                    return -1;

                case 1:
                    var c = Calculate(expr.Args[0], x);
                    if (expr.Token == "+") return +c;
                    if (expr.Token == "-") return -c;
                    if (expr.Token == "abs") return Math.Abs(c);
                    if (expr.Token == "sin") return Math.Sin(c);
                    if (expr.Token == "cos") return Math.Cos(c);
                    if (expr.Token == "ln") return Math.Log(c);
                    if (expr.Token == "lg") return Math.Log10(c);
                    if (expr.Token == "tg") return Math.Tan(c);
                    if (expr.Token == "ctg") return 1/Math.Tan(c);
                    if (expr.Token == "asin") return Math.Asin(c);
                    if (expr.Token == "acos") return Math.Acos(c);
                    if (expr.Token == "atg") return Math.Atan(c);
                    if (expr.Token == "actg") return 1/Math.Atan(c);
                    return -3;

                case 0:
                    if (expr.Token == "x")
                        return (double)x;
                    if (expr.Token == "e") 
                        return Math.E;
                    return Double.Parse(expr.Token);
            }

            return -2;
        }
    }
}
