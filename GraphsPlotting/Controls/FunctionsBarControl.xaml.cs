using GraphsPlotting.BaseClasses;
using GraphsPlotting.Helpers;
using GraphsPlotting.Types.Enums;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace GraphsPlotting.Controls
{
    /// <summary>
    /// Interaction logic for FunctionsBarControl.xaml
    /// </summary>
    public partial class FunctionsBarControl
    {
        private FunctionsBarModel _model;

        public FunctionsBarControl()
        {
            _model = new FunctionsBarModel();
            DataContext = _model;
            InitializeComponent();
        }
    }

    public class FunctionsBarModel : NotifyPropertyChangedItem
    {
        public ObservableCollection<ButtonCommand> Commands {  get; set; } = new ObservableCollection<ButtonCommand> { new ButtonCommand(Empty!) };
        public ButtonCommand EmptyCommand => new ButtonCommand(Empty!);

        private static void Empty(object obj) { }
    }

    public class TrigonometryFunctionModel
    {
        private FunctionNameEnum _functionName;

        public string FuncName => _functionName.GetStringValue();
    }
}
