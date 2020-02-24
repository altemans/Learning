using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameTheLife.Model
{
    public class Field
    {
        private ObservableCollection<Cell> cells = new ObservableCollection<Cell>();
        private Options options;
        private ObservableCollection<Cell> newCells = new ObservableCollection<Cell>();
        private Random rand = new Random();

        public ObservableCollection<Cell> Cells
        {
            get => cells;
            set
            {
                if(cells == value)
                    return;
                cells = value;
                CellsChanged?.Invoke();
            }
        }
        public event Action CellsChanged;

        public Field(Options opt)
        {
            options = opt;
            int j = 0;
            for(int i = 0; i < options.Height; i++)
                for(int k = 0; k < options.Width; k++, j++)
                {
                    int check = rand.Next(0, 2);
                    if(check == 0)
                        cells.Add(new Cell(false, i, k, Brushes.Black, j));
                    else
                        cells.Add(new Cell(true, i, k, Brushes.Green, j));
                }
        }
                // Row * Width + Col
                // [-1R -1C] [-1R 0C] [-1R +1C]
                // [ 0R -1C] [xx  xx] [ 0R +1C]
                // [+1R -1C] [+1R 0C] [+1R +1C]

        public void Step()
        {
            newCells = new ObservableCollection<Cell>(Cells);
            foreach(Cell cell in newCells)
            {
                int row = cell.Row, col = cell.Col, count = 0;
                if(row < options.Height - 1)
                    if(newCells[(row + 1) * options.Height + col].IsAlive)
                        count++;
                if(col < options.Width -1)
                    if(newCells[row * options.Height + (col + 1)].IsAlive)
                        count++;
                if(col > 0)
                    if(newCells[row * options.Height + (col - 1)].IsAlive)
                        count++;
                if(row > 0)
                    if(newCells[(row - 1) * options.Height + col].IsAlive)
                        count++;
                if(options.NumberOfNeighbors == 8)
                { 
                    if(row > 0 && col > 0)
                        if(newCells[(row - 1) * options.Height + (col - 1)].IsAlive)
                            count++;
                    if(row > 0 && col < options.Width - 1)
                        if(newCells[(row - 1) * options.Height + (col + 1)].IsAlive)
                            count++;
                    if(col > 0 && row < options.Height - 1)
                        if(newCells[(row + 1) * options.Height + (col - 1)].IsAlive)
                            count++;
                    if(row < options.Height - 1 && col < options.Width - 1)
                        if(newCells[(row + 1) * options.Height + (col + 1)].IsAlive)
                            count++;
                }
                if(!cell.IsAlive)
                {
                    if(count >= options.MinBirthday && count <= options.MaxBirthday)
                    {
                        Cells[cell.Index] = new Cell(true, cell.Row, cell.Col, Brushes.Green, cell.Index);
                    }
                }
                else
                {
                    if(!(count >= options.MinSurvive && count <= options.MaxSurvive))
                        Cells[cell.Index] = new Cell(false, cell.Row, cell.Col, Brushes.Black, cell.Index);
                    
                }
            }
        }
        public void NewGame()
        {
            cells.Clear();
            int j = 0;
            for(int i = 0; i < options.Height; i++)
                for(int k = 0; k < options.Width; k++, j++)
                {
                    int check = rand.Next(0, 2);
                    if(check == 0)
                        cells.Add(new Cell(false, i, k, Brushes.Black, j));
                    else
                        cells.Add(new Cell(true, i, k, Brushes.Green, j));
                }
        }

        public void GameStart()
        {
            Step();
        }
    }
}
