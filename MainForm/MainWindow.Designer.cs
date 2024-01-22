namespace WindowsFormsApp1
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.lblHelloWorld = new System.Windows.Forms.Label();
            this.btnSin = new System.Windows.Forms.Button();
            this.btnCos = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPrintSin = new System.Windows.Forms.Button();
            this.btnPrintCos = new System.Windows.Forms.Button();
            this.btnClearGraph = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btnSubt = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnMult = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHelloWorld
            // 
            this.lblHelloWorld.AutoSize = true;
            this.lblHelloWorld.Location = new System.Drawing.Point(24, 70);
            this.lblHelloWorld.Name = "lblHelloWorld";
            this.lblHelloWorld.Size = new System.Drawing.Size(19, 13);
            this.lblHelloWorld.TabIndex = 1;
            this.lblHelloWorld.Text = " ---";
            this.lblHelloWorld.Click += new System.EventHandler(this.lblHelloWorld_Click);
            // 
            // btnSin
            // 
            this.btnSin.Location = new System.Drawing.Point(141, 230);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(75, 23);
            this.btnSin.TabIndex = 2;
            this.btnSin.Text = "sin";
            this.btnSin.UseVisualStyleBackColor = true;
            this.btnSin.Click += new System.EventHandler(this.btnSin_Click);
            // 
            // btnCos
            // 
            this.btnCos.Location = new System.Drawing.Point(141, 261);
            this.btnCos.Name = "btnCos";
            this.btnCos.Size = new System.Drawing.Size(75, 23);
            this.btnCos.TabIndex = 3;
            this.btnCos.Text = "cos";
            this.btnCos.UseVisualStyleBackColor = true;
            this.btnCos.Click += new System.EventHandler(this.btnCos_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(141, 379);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Graph
            // 
            chartArea1.Name = "ChartArea2";
            this.Graph.ChartAreas.Add(chartArea1);
            this.Graph.Location = new System.Drawing.Point(330, 12);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(484, 426);
            this.Graph.TabIndex = 5;
            this.Graph.Text = "Graph";
            // 
            // btnPrintSin
            // 
            this.btnPrintSin.Location = new System.Drawing.Point(249, 261);
            this.btnPrintSin.Name = "btnPrintSin";
            this.btnPrintSin.Size = new System.Drawing.Size(75, 23);
            this.btnPrintSin.TabIndex = 6;
            this.btnPrintSin.Text = "print sin";
            this.btnPrintSin.UseVisualStyleBackColor = true;
            this.btnPrintSin.Click += new System.EventHandler(this.btnPrintSin_Click);
            // 
            // btnPrintCos
            // 
            this.btnPrintCos.Location = new System.Drawing.Point(249, 308);
            this.btnPrintCos.Name = "btnPrintCos";
            this.btnPrintCos.Size = new System.Drawing.Size(75, 23);
            this.btnPrintCos.TabIndex = 7;
            this.btnPrintCos.Text = "print cos";
            this.btnPrintCos.UseVisualStyleBackColor = true;
            this.btnPrintCos.Click += new System.EventHandler(this.btnPrintCos_Click);
            // 
            // btnClearGraph
            // 
            this.btnClearGraph.Location = new System.Drawing.Point(249, 379);
            this.btnClearGraph.Name = "btnClearGraph";
            this.btnClearGraph.Size = new System.Drawing.Size(75, 23);
            this.btnClearGraph.TabIndex = 8;
            this.btnClearGraph.Text = "clear graph";
            this.btnClearGraph.UseVisualStyleBackColor = true;
            this.btnClearGraph.Click += new System.EventHandler(this.btnClearGraph_Click);
            // 
            // btnSum
            // 
            this.btnSum.Location = new System.Drawing.Point(27, 261);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(28, 23);
            this.btnSum.TabIndex = 9;
            this.btnSum.Text = "+";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(27, 308);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(28, 23);
            this.btn7.TabIndex = 10;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(27, 348);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(28, 20);
            this.btn4.TabIndex = 11;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(61, 348);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(28, 20);
            this.btn5.TabIndex = 14;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(61, 308);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(28, 23);
            this.btn8.TabIndex = 13;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btnSubt
            // 
            this.btnSubt.Location = new System.Drawing.Point(61, 261);
            this.btnSubt.Name = "btnSubt";
            this.btnSubt.Size = new System.Drawing.Size(28, 23);
            this.btnSubt.TabIndex = 12;
            this.btnSubt.Text = "-";
            this.btnSubt.UseVisualStyleBackColor = true;
            this.btnSubt.Click += new System.EventHandler(this.btnSubt_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(95, 348);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(28, 20);
            this.btn6.TabIndex = 17;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(95, 308);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(28, 23);
            this.btn9.TabIndex = 16;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.Location = new System.Drawing.Point(95, 261);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(28, 23);
            this.btnDiv.TabIndex = 15;
            this.btnDiv.Text = "/";
            this.btnDiv.UseVisualStyleBackColor = true;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(61, 382);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(28, 20);
            this.btn2.TabIndex = 18;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(27, 382);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(28, 20);
            this.btn1.TabIndex = 19;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(95, 382);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(28, 20);
            this.btn3.TabIndex = 20;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btnMult
            // 
            this.btnMult.Location = new System.Drawing.Point(95, 230);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(28, 23);
            this.btnMult.TabIndex = 21;
            this.btnMult.Text = "*";
            this.btnMult.UseVisualStyleBackColor = true;
            this.btnMult.Click += new System.EventHandler(this.btnMult_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(61, 230);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(28, 23);
            this.btnRight.TabIndex = 22;
            this.btnRight.Text = ")";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(27, 230);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(28, 23);
            this.btnLeft.TabIndex = 23;
            this.btnLeft.Text = "(";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "Write your expression here";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(249, 230);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 450);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnMult);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btnSubt);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.btnClearGraph);
            this.Controls.Add(this.btnPrintCos);
            this.Controls.Add(this.btnPrintSin);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCos);
            this.Controls.Add(this.btnSin);
            this.Controls.Add(this.lblHelloWorld);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHelloWorld;
        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Button btnCos;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.Button btnPrintSin;
        private System.Windows.Forms.Button btnPrintCos;
        private System.Windows.Forms.Button btnClearGraph;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btnSubt;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnMult;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnPrint;
    }
}

