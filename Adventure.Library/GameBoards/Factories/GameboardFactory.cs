using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Gameboards.Factories
{
    public class GameboardFactory : IGameboardFactory
    {
        public IGameboard CreateGameboard()
        {
            return new Gameboard();
        }


        public IGameboard CreateGameboard(int rowCount, int columnCount)
        {
            throw new NotImplementedException();
        }
    }
}
