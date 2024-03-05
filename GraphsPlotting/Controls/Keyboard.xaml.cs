using GraphsPlotting.Helpers;

namespace GraphsPlotting.Controls
{
    /// <summary>
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : UserControlBase
    {
        private KeyboardModel _model;
        public Keyboard()
        {
            _model = new KeyboardModel();
            DataContext = _model;
            InitializeComponent();
        }
    }

    public class KeyboardModel : NotifyPropertyChangedItem
    {
        #region Private

        private string _expression;

        #endregion

        public KeyboardModel()
        {
            _expression = "";
        }


        #region Public

        public string Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ButtonCommand ClickDigitCommand => new ButtonCommand(ClickDigit!);

        private void ClickDigit(object obj)
        {
            if (obj is string str && short.TryParse(str, out _))
            {
                Expression += str;
            }
        }

        #endregion
    }
}
