using ConwayGameOfLife.Service;

namespace ConwayGameOfLife
{
    public class IOService : IIOService
    {
        public int GetGenerationNumber()
        {
            Console.WriteLine("Which generation's population positions are you interested in:");
            return int.Parse(Console.ReadLine() ?? "0");
        }

        public List<string> GetInputActiveCells()
        {
            Console.WriteLine("Input Enter the Cell position to Alive (1):");
            Console.WriteLine("Example: 2,1");
            Console.WriteLine("Note:Please press Enter key for next cell position");
            List<string> inputPosition = new List<string>();
            while (true)
            {
                string f = Console.ReadLine() ?? string.Empty;
                if (f == string.Empty)
                {
                    break;
                }
                else
                    inputPosition.Add(f);
            }
            return inputPosition;
        }

        public void PrintActiveGenerationPositionResult(List<Tuple<int, int>> resultSet)
        {
            Console.WriteLine("Output (Active member position Coordinates):");
            foreach (var tuple in resultSet)
            {
                Console.Write("[({0},{1})]", tuple.Item1, tuple.Item2);
            }
            Console.WriteLine();
        }
    }
}
