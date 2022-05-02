using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Service
{
    public interface IIOService
    {
        int GetGenerationNumber();
        List<string> GetInputActiveCells();
        void PrintActiveGenerationPositionResult(List<Tuple<int, int>> resultSet);
    }
}
