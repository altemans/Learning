using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTheLife.Model
{
    public class Options
    {
        public Options(int height = 40, int width = 40, int minSurvive = 2, int maxSurvive = 3, int minBirthday = 3, int maxBirthday = 3, int numberOfNeighbors = 8)
        {
            Height = height;
            Width = width;
            MinSurvive = minSurvive;
            MaxSurvive = maxSurvive;
            MinBirthday = minBirthday;
            MaxBirthday = maxBirthday;
            NumberOfNeighbors = numberOfNeighbors;
        }

        public int Height { get; set; } //Количество строк
        public int Width { get; set; } //Количество столбцов

        public int MinSurvive { get; set; } //Минимальный диапазон выживания
        public int MaxSurvive { get; set; }  //Максимальный диапазон выживания

        public int MinBirthday { get; set; }  //Минимальный диапазон зарождения жизни
        public int MaxBirthday { get; set; }  //Максимальный диапазон зарождения жизни

        public int NumberOfNeighbors { get; set; }  // количество соседей
        public int TimerValue { get; set; } = 100;


    }
}
