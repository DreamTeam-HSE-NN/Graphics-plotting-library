using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Expression
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
    class Parcer
    {
        private string input;
        private int i;
        public Parcer(string Expression)
        {
            input = Expression;
        }

        private string Parse_token()
        {
            if (i == input.Length - 1) return "";
            while (input[i] == ' ') ++i;
   
            if (Char.IsDigit(input, i))
            {
                string number = "";
                while (Char.IsDigit(input, i) || input[i] == '.')
                {
                    number += input[i];
                    ++i;
                }
                return number;
            }

            switch (input[i])
            {
                case '+':
                    ++i;
                    return "+";
                case '-':
                    ++i;
                    return "-";
                case '*':
                    ++i;
                    return "*";
                case '/':
                    ++i;
                    return "/";
                case '^':
                    ++i;
                    return "^";
                case 's':
                    if (input[i + 1] == 'i')
                    {
                        i += 2;
                        goto case 'n';
                    }
                    if (input[i + 1] == '(')
                    {
                        ++i;
                        return "cos";
                    }
                    break;
                case 'n':
                    if (input[i] == 'n')
                    {
                        ++i;
                        return "sin";
                    }
                    break;
                
                case '(':
                    ++i;
                    return "(";
                case ')':
                    ++i;
                    return ")";
            }
            return "";
        }


        private Expression Parse_simple_expression()
        {
            string token = Parse_token();
            if (token == "")
                return new Expression("Ivaleb");

            if (token == "(")
            {
                var result = Parse();
                if (Parse_token() != ")") return new Expression("Expexted ) , dalba'b");
                return result;
            }

            if (Char.IsDigit(token[0]))
                return new Expression(token);

            var arg = Parse_simple_expression();

            return new Expression(token, Parse_simple_expression());
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
        Expression Parse_binary_expression(int min_priority)
        {
            var left_expr = Parse_simple_expression();

            while (true)
            {
                var op = Parse_token();
                var priority = Get_priority(op);
                if (priority <= min_priority)
                {
                    i -= op.Length;
                    return left_expr;
                }

                var right_expr = Parse_binary_expression(priority);
                left_expr = new Expression(op, left_expr, right_expr);
            }
        }

        public Expression Parse()
        {
            return Parse_binary_expression(0);
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
