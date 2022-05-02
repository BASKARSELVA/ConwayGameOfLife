using ConwayGameOfLife;
using ConwayGameOfLife.Service;

namespace ConwayGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //Grid init
            int rows = 25, cols = 25;
            int[,] grid = new int[rows, cols];

            //Initialize Services
            IGameService gameService = new GameService();
            IGridService gridService = new GridService();
            IIOService iOService = new IOService();

            var gameOfLife=new GameOfLife(gameService, gridService,iOService);
            //Run Game
            gameOfLife.Run(grid);
        }
    }
}