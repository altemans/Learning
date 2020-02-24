using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameTheLife.Model;


namespace GameTheLife.ViewModel
{
    public class FieldViewModel : INotifyPropertyChanged
    {
        private Field field;
        public Cell Cell { get; }
        public FieldViewModel(Field fie)
        {
            field = fie;
            field.CellsChanged += CollectChanged; 
        }
        public void CollectChanged() { 
}
        public Field Field
        {
            get => field;
            set
            {
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
