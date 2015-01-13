using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Gameboards.Factories
{
    public interface IGameboardFactory
    {
        IGameboard CreateGameboard();
        IGameboard CreateGameboard(int rowCount, int columnCount);
    }
}
