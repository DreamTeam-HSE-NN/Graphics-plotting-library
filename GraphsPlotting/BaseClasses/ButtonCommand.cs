using System.Windows.Input;

namespace GraphsPlotting.BaseClasses
{
    public class ButtonCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object, bool>? _canExecute;

        public ButtonCommand(Action<object?> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var canExecuteChanged = CanExecuteChanged;
            canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || (parameter != null && _canExecute(parameter));
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
            RaiseCanExecuteChanged();
        }

    }
}
