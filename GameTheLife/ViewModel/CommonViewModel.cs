using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameTheLife.Model;

namespace GameTheLife.ViewModel
{
    public class CommonViewModel : INotifyPropertyChanged
    {
        private FieldViewModel fieldVM;
        private OptionsViewModel optionsVM;
        private Field field;
        private Options options;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        

        public CommonViewModel()
        {
            options = new Options();
            field = new Field(options);

            optionsVM = new OptionsViewModel(options);
            fieldVM = new FieldViewModel(field);
        }

        public FieldViewModel FieldVM => fieldVM;
        public OptionsViewModel OptionsVM => optionsVM;

        public void ChangeToAlive(MouseEventArgs o)
        {
            if(o.OriginalSource is StackPanel)
            {
                StackPanel butt = (System.Windows.Controls.StackPanel)o.OriginalSource;
                if(!(butt.DataContext is Cell))
                    return;
                Cell cel = (Cell)(butt.DataContext);
                if(cel.IsAlive == false)
                {
                    Cell newCell = new Cell(true, cel.Row, cel.Col, Brushes.Green, cel.Index);
                    fieldVM.Field.Cells[cel.Index] = newCell;
                    return;
                }
            }
        }
        public void ChangeToDeath(MouseEventArgs o)
        {
            if(o.OriginalSource is StackPanel)
            {
                StackPanel butt = (System.Windows.Controls.StackPanel)o.OriginalSource;
                if(!(butt.DataContext is Cell))
                    return;
                Cell cel = (Cell)(butt.DataContext);
                if(cel.IsAlive == true)
                {
                    fieldVM.Field.Cells[cel.Index] = new Cell(false, cel.Row, cel.Col, Brushes.Black, cel.Index);
                    return;
                }
            }
        }
        public void StartGame()
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,0,0,OptionsVM.TimerValue);
            timer.IsEnabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            fieldVM.Field.GameStart();
        }
        public void NewGame()
        {
            fieldVM.Field.NewGame();
        }
        public void StopGame()
        {
            timer.Stop();
            timer.IsEnabled = false;
            timer.Tick -= new EventHandler(timer_Tick);
        }
        public void ChangeNeigTo4()
        {
            OptionsVM.Options.NumberOfNeighbors = 4;
        }
        public void ChangeNeigTo8()
        {
            OptionsVM.Options.NumberOfNeighbors = 8;
        }
         public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
