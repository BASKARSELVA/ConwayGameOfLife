using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Service
{
    public interface IGameService
    {
        int[,] NextGeneration(int[,] grid, int M, int N);
    }
}
