using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GameTheLife.Model;

namespace GameTheLife.ViewModel
{
    public class OptionsViewModel : INotifyPropertyChanged
    {
        public Options Options { get => options; }
        private Options options;

        public OptionsViewModel(Options opt)
        {
            options = opt;
        }

        public int Width
        {
            get => options.Width;
            set
            {
                if(options.Width == value)
                    return;
                options.Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get => options.Height;
            set
            {
                if(options.Height == value)
                    return;
                options.Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public int MinSurvive
        {
            get => options.MinSurvive;
            set
            {
                if(options.MinSurvive == value)
                    return;
                options.MinSurvive = value;
                OnPropertyChanged(nameof(MinSurvive));
            }
        }

        public int MaxSurvive
        {
            get => options.MaxSurvive;
            set
            {
                if(options.MaxSurvive == value)
                    return;
                options.MaxSurvive = value;
                OnPropertyChanged(nameof(MaxSurvive));
            }
        }

        public int MinBirthday
        {
            get => options.MinBirthday;
            set
            {
                if(options.MinBirthday == value)
                    return;
                options.MinBirthday = value;
                OnPropertyChanged(nameof(MinBirthday));
            }
        }

        public int MaxBirthday
        {
            get => options.MaxBirthday;
            set
            {
                if(options.MaxBirthday == value)
                    return;
                options.MaxBirthday = value;
                OnPropertyChanged(nameof(MaxBirthday));
            }
        }

        public int NumberOfNeighbors
        {
            get => options.NumberOfNeighbors;
            set
            {
                if(options.NumberOfNeighbors == value)
                    return;
                options.NumberOfNeighbors = value;
                OnPropertyChanged(nameof(NumberOfNeighbors));
            }
        }
        public int TimerValue
        {
            get => options.TimerValue;
            set
            {
                if(options.TimerValue == value)
                    return;
                options.TimerValue = value;
                OnPropertyChanged(nameof(TimerValue));
            }
        }

        public void ChangeNeigTo4()
        {
            NumberOfNeighbors = 4;
        }
        public void ChangeNeigTo8()
        {
            NumberOfNeighbors = 8;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
