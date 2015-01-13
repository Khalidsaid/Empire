using Adventure.Library.Environments.Outlets;
using Adventure.Library.Environments.Zones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure.Library.Gameboards
{
    public interface IGameboard
    {
        int Height { get; }
        int Width { get; }
        string ToString();
    }
}
