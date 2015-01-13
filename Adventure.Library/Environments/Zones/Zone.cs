using Adventure.Library.Commons;
using System.Collections.Generic;

namespace Adventure.Library.Environments.Zones
{
    public class Zone : IZone
    {
        public IList<IZone> Zones { get; private set; }

        public IList<Buildings.IBuilding> Buildings { get; private set; }

        public IList<Characters.ACharacter> Characters { get; private set; }

        public Coordinate Coordinate { get; private set; }
        public int X { get { return this.Coordinate != null ? this.Coordinate.X : 0; } }
        public int Y { get { return this.Coordinate != null ? this.Coordinate.Y : 0; } }


        public Zone(int x, int y) : this(new Commons.Coordinate(x, y)) { }
        public Zone(Commons.Coordinate coordinate)
        {
            this.Coordinate = coordinate;
        }
    }
}
