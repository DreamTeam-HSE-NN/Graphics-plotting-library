using System.Windows;
using System.Windows.Controls;
using ZedGraph;


namespace GraphsPlotting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            // Парсим полученное выражение
            Parcer parser = new Parcer(TextBoxInput.Text);
            var result = parser.Parse();
            if (result.Token == "Error") return;
            // Получим панель для рисования
            GraphPane pane = zgc.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list = new PointPairList();

            // Парсим границы отрисовки
            double xmin = 0;
            double xmax = 0;
            if (!(double.TryParse(TextBoxDownBound.Text, out xmin) && double.TryParse(TextBoxUpBound.Text, out xmax)))
            {
                System.Windows.Forms.MessageBox.Show("Incorrect Bounds");
                return;
            }
            

            // Заполняем список точек
            for (double x = xmin; x < xmax; x += (xmax - xmin)/100000)
            {
                // добавим в список точку
                list.Add(x, parser.Calculate(result, x));
            }

            // Создадим кривую с названием "Sinc",
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(TextBoxInput.Text, list, System.Drawing.Color.Blue, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zgc.AxisChange();

            // Обновляем график
            zgc.Invalidate();
        }

        //private void zedGraph_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    // Сюда будут записаны координаты в системе координат графика
        //    double x, y;

        //    // Пересчитываем пиксели в координаты на графике
        //    // У ZedGraph есть несколько перегруженных методов ReverseTransform.
        //    zgc.GraphPane.ReverseTransform(e.Location, out x, out y);

        //    // Выводим результат
        //    string text = string.Format("X: {0};    Y: {1}", x, y);
        //    zgc.Text = text;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((System.Windows.Controls.Button)e.OriginalSource).Content;

            if (str == "Clear")
            {
                TextBoxInput.Text = "";
            }
            else
            {
                TextBoxInput.Text += str;
            }

        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            
        }

 
    }
}