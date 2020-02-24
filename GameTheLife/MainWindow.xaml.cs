using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameTheLife.ViewModel;

namespace GameTheLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CommonViewModel();
        }

        private bool leftDown = false;
        private bool rightDown = false;
        private bool buttonDown = false;

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           
            if(!leftDown && !rightDown)
                return;
            if(leftDown)
                ((CommonViewModel)DataContext).ChangeToAlive(e);
            if(rightDown)
                ((CommonViewModel)DataContext).ChangeToDeath(e);

        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            leftDown = false;
            rightDown = false;
            buttonDown = false;
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            leftDown = true;
            ((CommonViewModel)DataContext).ChangeToAlive(e);
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            rightDown = true;
            ((CommonViewModel)DataContext).ChangeToDeath(e);
        }

        private void Window_Button_Click(object sender, RoutedEventArgs e)
        {
                buttonDown = true;
            if(e.OriginalSource is Button)
            {
                if(buttonDown)
                {
                    if(((Button)e.OriginalSource).Name == "StartButton")
                        ((CommonViewModel)DataContext).StartGame();
                    if(((Button)e.OriginalSource).Name == "StopButton")
                        ((CommonViewModel)DataContext).StopGame();
                    if(((Button)e.OriginalSource).Name == "NewGame")
                        ((CommonViewModel)DataContext).NewGame();
                }
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if(((ComboBoxItem)e.OriginalSource).Name == "CB4")
                ((CommonViewModel)DataContext).ChangeNeigTo4();
            if(((ComboBoxItem)e.OriginalSource).Name == "CB8")
                ((CommonViewModel)OptionsGrid.DataContext).ChangeNeigTo8();
        }

    }
}
