
using Adventure.Library.Characters;
using Adventure.Library.Commons;
using Adventure.Library.Environments.Buildings;
using System.Collections.Generic;
namespace Adventure.Library.Environments.Zones
{
    public interface IZone
    {
        int X { get; }
        int Y { get; }
        Coordinate Coordinate { get; }
        string ToString();
    }
}
