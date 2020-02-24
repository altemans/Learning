using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameTheLife.Model
{
    public class Cell
    {
        private bool isAlive;
        public int Index { get; set; }
        public Cell(bool isAlive, int row, int col, Brush background, int index)
        {
            IsAlive = isAlive;
            Row = row;
            Col = col;
            Background = background;
            Index = index;
        }
        public bool IsAlive
        {
            get => isAlive;
            set
            {
                if(isAlive == value)
                    return;
                isAlive = value;
                Background = !isAlive ? Brushes.Black : Brushes.Green;
                IsAliveChanged?.Invoke();
            }

        }
        public event Action IsAliveChanged;


        public int Row { get; set; }
        public int Col { get; set; }
        public Brush Background { get; set; }
    }
}
