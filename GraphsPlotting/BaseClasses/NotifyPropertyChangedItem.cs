using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphsPlotting.BaseClasses
{
    public class NotifyPropertyChangedItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = "OnPropertyChanged")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
