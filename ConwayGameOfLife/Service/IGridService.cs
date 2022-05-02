using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Service
{
    public interface IGridService
    {
        List<Tuple<int, int>> FindActiveCoordinatesOf<T>(T[,] matrix, T value);
        void PrintGrid(int[,] grid);
    }
}
