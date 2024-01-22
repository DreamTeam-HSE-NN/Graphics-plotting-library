using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void lblHelloWorld_Click(object sender, EventArgs e)
        {

        }


        private void btnSin_Click(object sender, EventArgs e)
        {
            //string buf = "sin(";
            //buf += textBox1.Text + ")";
            //textBox1.Text = buf;
            textBox1.Text += "sin";
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            //string buf = "cos(";
            //buf += textBox1.Text + ")";
            //textBox1.Text = buf;
            textBox1.Text += "cos";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void btnPrintSin_Click(object sender, EventArgs e)
        {
            Graph.Series.Clear();
            Series mySeriesOfPoint = new Series();
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "ChartArea2";
            for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
            {
                mySeriesOfPoint.Points.AddXY(x, Math.Sin(x));
            }
            Graph.Series.Add(mySeriesOfPoint);
        }

        private void btnPrintCos_Click(object sender, EventArgs e)
        {
            Graph.Series.Clear();
            Series mySeriesOfPoint = new Series();
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "ChartArea2";
            for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
            {
                mySeriesOfPoint.Points.AddXY(x, Math.Cos(x));
            }
            Graph.Series.Add(mySeriesOfPoint);
        }

        private void btnClearGraph_Click(object sender, EventArgs e)
        {
            Graph.Series.Clear();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void btnSubt_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblHelloWorld.Text = textBox1.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Parser parser = new Parser(textBox1.Text);
            var result = parser.Calculate(parser.Parse());



            Graph.Series.Clear();
            Series mySeriesOfPoint = new Series();
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "ChartArea2";
            //for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
           // {
                mySeriesOfPoint.Points.AddXY(0.7, result);
                mySeriesOfPoint.Points.AddXY(1.5, result);
            //}
            Graph.Series.Add(mySeriesOfPoint);
        }
    }


}

