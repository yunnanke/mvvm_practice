using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3_mvvm
{
    public class LineViewModel : INotifyPropertyChanged
    {
        private string _inputA = "";
        private string _inputB = "";

        public string A
        {
            get => _inputA;
            set
            {
                _inputA = value;
                OnPropertyChanged();
                Recalculate();
            }
        }

        public string B
        {
            get => _inputB;
            set
            {
                _inputB = value;
                OnPropertyChanged();
                Recalculate();
            }
        }

        public string Equation { get; private set; } = "Нет данных";
        public string XIntercept { get; private set; } = "-";
        public string YIntercept { get; private set; } = "-";

        public Line? Line { get; private set; }

        private void Recalculate()
        {
            if (double.TryParse(A, out double a) && double.TryParse(B, out double b))
            {
                Line = new Line(a, b);
                Equation = Line.PrintForm();
                var x = Line.GetX();
                XIntercept = x?.ToString("F2") ?? "Нет (a=0)";
                YIntercept = Line.GetY().ToString("F2");
            }
            else
            {
                Line = null;
                Equation = "Некорректный ввод";
                XIntercept = "-";
                YIntercept = "-";
            }

            OnPropertyChanged(nameof(Equation));
            OnPropertyChanged(nameof(XIntercept));
            OnPropertyChanged(nameof(YIntercept));
            OnPropertyChanged(nameof(Line));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}