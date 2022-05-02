using NUnit.Framework;
using ConwayGameOfLife;
using ConwayGameOfLife.Service;
using Moq;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ConwayGameOfLifeTest;

public class GameOfLifeTest
{
    public GameOfLife Game { get; set; }

    [SetUp]
    public void Setup()
    {
        IGameService gameService = new GameService();
        IGridService gridService = new GridService();
        IIOService iOService = new IOService();

        Game = new GameOfLife(gameService, gridService, iOService);
    }

    [Test]
    [TestCase(3, "2,1|2,2|2,3","1,2|2,2|3,2")]
    [TestCase(5, "9,8|10,9|8,10|9,10|10,10", "9,10|10,11|10,12|11,10|11,11")]
    [TestCase(10, "1,2|2,1|2,3|3,2", "1,2|2,1|2,3|3,2")]
    public void RunGame_Positive(int nthGeneration,string inputPosition,string expectedOutPut)
    {
        int[,] grid = new int[25, 25];
        MockConsoleServices(nthGeneration, inputPosition);
        Game.Run(grid);

        List<string> outPutList = new List<string>();
        foreach (var item in Game.OutputActivePosition)
        {
            outPutList.Add(string.Format("{0},{1}", item.Item1, item.Item2));
        }
        var actualOutputValues = string.Join("|", outPutList);
        Assert.AreEqual(expectedOutPut, actualOutputValues);
    }


    [Test]
    [TestCase(3, "2,1|2,2|2,3", "6,2|5,2|1,2")]
    public void RunGame_Negative(int nthGeneration, string inputPosition, string expectedOutPut)
    {
        int[,] grid = new int[25, 25];
        MockConsoleServices(nthGeneration, inputPosition);
        Game.Run(grid);

        List<string> outPutList = new List<string>();
        foreach (var item in Game.OutputActivePosition)
        {
            outPutList.Add(string.Format("{0},{1}", item.Item1, item.Item2));
        }
        var actualOutputValues = string.Join("|", outPutList);
        Assert.AreNotEqual(expectedOutPut, actualOutputValues);
    }



    private void MockConsoleServices(int nthGeneration, string inputPosition)
    {
        Mock<IIOService> mockIOService = new Mock<IIOService>();
        mockIOService
            .Setup(s => s.GetGenerationNumber())
            .Returns(nthGeneration);
        var inputPositionList = inputPosition.Split('|').ToList();
        mockIOService
            .Setup(s => s.GetInputActiveCells())
            .Returns(inputPositionList);
        Game._iOService = mockIOService.Object;
    }
}