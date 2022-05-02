using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Service
{
    public class GridService : IGridService
    {

        public void PrintGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write("{0} ", grid[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public List<Tuple<int, int>> FindActiveCoordinatesOf<T>(T[,] matrix, T value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        list.Add(new Tuple<int, int>(x, y));
                }
            }
            return list;
        }
    }
}
