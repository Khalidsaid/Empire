using Adventure.Library.Mazes.Builders;
using Adventure.Library.Mazes.Environments.Zones;
using Adventure.Library.Mazes.GameBoards;
using Adventure.Library.Mazes.Games.Simulations;
using System;
using System.Linq;

namespace Adventure.Games.Console.Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new MazeGameSimulation();

                game.CreateNewGameAsync(20, 10).Wait();
                game.BuildMazeAsync().Wait();
                System.Console.WriteLine(game);

                System.Console.WriteLine("Enter key to Run..\n");
                System.Console.ReadKey();

                game.RunAsync().Wait();
                System.Console.WriteLine(game);
                System.Console.WriteLine("Current : {0}", game.Current.Coordinate);

                System.Console.WriteLine("Enter key to continue..\n");
                System.Console.ReadKey();

                while(game.State == StateMazeGame.None)
                {
                    game.NextDFSAsync().Wait();
                    System.Console.WriteLine(game);
                    System.Console.WriteLine("Current : {0}", game.Current.Coordinate);

                    System.Console.WriteLine("Enter key to continue..\n");
                    System.Console.ReadKey();
                }
                System.Console.WriteLine(game.State);
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("----------------------------");
                System.Console.Error.WriteLine(ex.Message);
                System.Console.Error.WriteLine(ex.Source);
            }
            finally
            {
                System.Console.ReadKey();
            }
        }
    }
}
