using System.Windows;
using System.Windows.Controls;
using ZedGraph;
using System.IO;


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
            zgc.GraphPane.XAxis.Title.Text = "Ось X";
            zgc.GraphPane.YAxis.Title.Text = "Ось Y";
            zgc.GraphPane.Title.Text = "График";
            zgc.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(zedGraph_ContextMenuBuilder);
            zgc.DoubleClickEvent += new ZedGraphControl.ZedMouseEventHandler(zedGraph_DoubleClick);
        }

        private void zedGraph_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, System.Drawing.Point mousePt,
                                         ZedGraphControl.ContextMenuObjectState objState)
        {
            // Переименуем (переведем на русский язык) некоторые пункты контекстного меню
            menuStrip.Items[0].Text = "Копировать";
            menuStrip.Items[1].Text = "Сохранить как картинку…";
            menuStrip.Items[2].Text = "Параметры страницы…";
            menuStrip.Items[3].Text = "Печать…";
            menuStrip.Items[4].Text = "Показывать значения в точках…";
            menuStrip.Items[5].Text = "Отдалиться";
            menuStrip.Items[6].Text = "Отменить все масштабирования/перемещения";
            menuStrip.Items[7].Text = "Установить масштаб по умолчанию…";
        }

        private bool zedGraph_DoubleClick(ZedGraphControl sender, MouseEventArgs e)
        {
            return false;
        }

        uint color = 0;
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DrawGraphic(TextBoxInput.Text);
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                string line;
                StreamReader reader = new StreamReader(path);
                while ((line = reader.ReadLine()) != null)
                {
                    DrawGraphic(line);
                }
            }
            else System.Windows.MessageBox.Show("File does not exist");
        }

        private void DrawGraphic(string input)
        {
            // Парсим полученное выражение
            Parcer parser = new Parcer(input);
            var result = parser.Parse();
            if (result.Token == "Error") return;
            // Получим панель для рисования
            GraphPane pane = zgc.GraphPane;
            pane.XAxis.Cross = 0.0;

            // Ось Y будет пересекаться с осью X на уровне X = 0
            pane.YAxis.Cross = 0.0;

            // Отключим отображение первых и последних меток по осям
            pane.XAxis.Scale.IsSkipFirstLabel = true;
            pane.XAxis.Scale.IsSkipLastLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.XAxis.Scale.IsSkipCrossLabel = true;


            // Отключим отображение первых и последних меток по осям
            pane.YAxis.Scale.IsSkipFirstLabel = true;

            // Отключим отображение меток в точке пересечения с другой осью
            pane.YAxis.Scale.IsSkipLastLabel = true;
            pane.YAxis.Scale.IsSkipCrossLabel = true;

            // Спрячем заголовки осей
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();

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
            for (double x = xmin; x < xmax; x += (xmax - xmin) / 100000)
            {
                // добавим в список точку
                list.Add(x, parser.Calculate(result, x));
            }

            Color[] clr = { Color.Brown, Color.Blue, Color.Green, Color.Red, Color.Gray, Color.Purple, Color.Pink, Color.Orange };
            // Создадим кривую с названием "Sinc",
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(input, list, clr[color++ % clr.Length], SymbolType.None);

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

            if (str == "Очистить")
            {                
                zgc.GraphPane.CurveList.Clear();
                zgc.Invalidate();
            }
            else
            {
                TextBoxInput.SelectedText += str;
            }

        }

        private void zgc_DoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(functions.Content == "Функции")
            {
                first.Content = "sin()";
                second.Content = "cos()";
                third.Content = "e^()";
                fourth.Content = "x^2";
                fifth.Content = "x^3";
                sixth.Content = "x^(1/2)";
                seventh.Content = "log()";
                eighth.Content = "ln()";
                ninth.Content = "tg()";
                functions.Content = "Цифры";
            }
            else
            {
                first.Content = "1";
                second.Content = "2";
                third.Content = "3";
                fourth.Content = "4";
                fifth.Content = "5";
                sixth.Content = "6";
                seventh.Content = "7";
                eighth.Content = "8";
                ninth.Content = "9";
                functions.Content = "Функции";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Text = "";
        }
    }
}  