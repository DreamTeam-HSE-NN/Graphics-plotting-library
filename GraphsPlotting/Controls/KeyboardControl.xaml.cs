using GraphsPlotting.BaseClasses;
using GraphsPlotting.Helpers;
using System.Windows.Input;

namespace GraphsPlotting.Controls
{
    /// <summary>
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class KeyboardControl
    {
        private KeyboardModel _model;
        public KeyboardControl()
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

        public ButtonCommand ClickCommand => new ButtonCommand(Click!);

        private void Click(object obj)
        {
            if (obj is Key key)
            {
                var a = key.GetStringValue();
                return;
            }
        }

        #endregion
    }
}
