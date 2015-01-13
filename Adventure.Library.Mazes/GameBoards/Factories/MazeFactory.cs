using Adventure.Library.Gameboards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Mazes.GameBoards.Factories
{
    public class MazeFactory : IGameboardFactory
    {
        public Library.Gameboards.IGameboard CreateGameboard()
        {
            return new Maze();
        }

        public Library.Gameboards.IGameboard CreateGameboard(int rowCount, int columnCount)
        {
            throw new NotImplementedException();
          //  return new Maze();
        }
    }
}
