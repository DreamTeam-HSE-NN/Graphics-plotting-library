using System.Collections.ObjectModel;
using GraphsPlotting.Helpers;

namespace GraphsPlotting.Controls
{
    /// <summary>
    /// Interaction logic for FunctionsListControl.xaml
    /// </summary>
    public partial class FunctionsListControl : UserControlBase
    {
        private FunctionsListModel _model;

        public FunctionsListControl()
        {
            _model = new FunctionsListModel();
            DataContext = _model;

            _model.FunctionList.Add(new FunctionViewModel {Function = "asdgafdgh"});
            _model.FunctionList.Add(new FunctionViewModel {Function = "asdgasdgasgasdgs"});
            _model.FunctionList.Add(new FunctionViewModel {Function = "1234513451346"});

            InitializeComponent();
        }
    }

    public class FunctionsListModel : NotifyPropertyChangedItem
    {
        public ObservableCollection<FunctionViewModel> FunctionList { get; set; } =
            new ObservableCollection<FunctionViewModel>();

        public ButtonCommand AddFuncCommand => new ButtonCommand(AddFunc!);
        public ButtonCommand DeleteSelectedCommand => new ButtonCommand(DeleteSelected!);

        private void AddFunc(object obj)
        {
            FunctionList.Add(new FunctionViewModel());
        }

        private void DeleteSelected(object obj)
        {
            foreach (var item in FunctionList.Where(el => el.IsChecked).ToList())
            {
                FunctionList.Remove(item);
            }
        }
    }

    public class FunctionViewModel : NotifyPropertyChangedItem
    {
        private string _function = "";
        private bool _isChecked;

        public string Function
        {
            get => _function;
            set
            {
                _function = value;
                OnPropertyChanged();
            }
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value; 
                OnPropertyChanged();
            }
        }
    }
}
