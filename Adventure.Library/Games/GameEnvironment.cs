using Adventure.Library.Gameboards;
using Adventure.Library.Gameboards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Games
{
    public class GameEnvironment
    {
        public IGameboard CreateGameboard(IGameboardFactory gameboardFactory, int rowCount = 0, int columnCount = 0)
        {
            return gameboardFactory.CreateGameboard(rowCount, columnCount);
        }
    }
}
