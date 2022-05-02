using ConwayGameOfLife.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife
{
    public class GameOfLife
    {
        private IGameService _gameService;
        private IGridService _gridService;
        public IIOService _iOService;
        public int[,] grid { get; set; }
        public List<Tuple<int, int>> OutputActivePosition { get; set; }
        public GameOfLife(IGameService gameService, IGridService gridService,IIOService iOService)
        {
            _iOService = iOService;
            _gameService = gameService;
            _gridService = gridService;
        }

        public void Run(int[,] grid)
        {
            this.grid = grid ?? new int[,] { };
            try
            {
                //Get Generation number to find
                int finalGenerationNum = _iOService.GetGenerationNumber();
                //Map input alive cell values
                MapInputCellValues(_iOService.GetInputActiveCells());
                //Iterate the Generation until the Nth number
                FindNthGenerationGrid(finalGenerationNum);
                //Get the result Position
                OutputActivePosition = _gridService.FindActiveCoordinatesOf<int>(this.grid, 1);
                _iOService.PrintActiveGenerationPositionResult(OutputActivePosition);

                Console.WriteLine("Nth Generation Result:");
                _gridService.PrintGrid(this.grid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error Occured!! Please Close and Open the Game.");
            }
        }

        public void FindNthGenerationGrid(int finalGenerationNum)
        {
            for (int i = 0; i < finalGenerationNum; i++)
            {
                this.grid = _gameService.NextGeneration(grid, grid.GetLength(0), grid.GetLength(1));
                Console.Write("Generation number {0} Completed: \n", i);
            }
        }

        public void MapInputCellValues(List<string> activeCellList)
        {
            foreach (var item in activeCellList)
            {
                var x = Convert.ToInt32(item.Split(',')[0]);
                var y = Convert.ToInt32(item.Split(',')[1]);
                this.grid[x, y] = 1;
            }
        }
    }
}
