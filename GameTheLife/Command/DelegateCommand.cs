using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameTheLife.ViewModel
{
    public class DelegateCommand<T> : ICommand
    {
        private Action<T> action;

        public DelegateCommand(Action<T> action) => this.action = action;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => action((T)parameter);
    }
}
