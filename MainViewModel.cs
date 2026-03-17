using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3_mvvm
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public LineViewModel Line1 { get; } = new();
        public LineViewModel Line2 { get; } = new();

        public MainViewModel()
        {
            Line1.PropertyChanged += OnLineChanged;
            Line2.PropertyChanged += OnLineChanged;
        }

        private void OnLineChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LineViewModel.Line))
            {
                OnPropertyChanged(nameof(ArePerpendicular));
                OnPropertyChanged(nameof(Angle));
            }
        }

        public string ArePerpendicular
        {
            get
            {
                if (Line1.Line != null && Line2.Line != null)
                    return Line1.Line.IsPerpendicular(Line2.Line) ? "Да" : "Нет";
                return "-";
            }
        }

        public string Angle
        {
            get
            {
                if (Line1.Line != null && Line2.Line != null)
                    return $"{Line1.Line.GetAngleBetween(Line2.Line):F2}°";
                return "-";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}