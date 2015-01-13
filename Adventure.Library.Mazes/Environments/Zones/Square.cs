using Adventure.Library.Commons;
using Adventure.Library.Environments.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Mazes.Environments.Zones
{
    [Flags]
    public enum StateSquare {None = 0x0, Start = 0x1, End = 0x2, Visited = 0x4 }
    public class Square : IZone
    {
        public Coordinate Coordinate { get; private set; }
        public int X { get { return this.Coordinate.X; } }
        public int Y { get { return this.Coordinate.Y; } }
        public StateSquare State { get; set; }
        
        public Square(int x, int y) : this(new Coordinate(x, y)) { }

        public Square(Coordinate coordinate)
        {
            this.State = StateSquare.None;
            this.Coordinate = coordinate;
        }

        public override string ToString()
        {
            if (this.State.HasFlag(StateSquare.Visited))
                return "[.]";
            if (this.State.HasFlag(StateSquare.Start))
                return "[S]";
            if (this.State.HasFlag(StateSquare.End))
                return "[E]";
            return "[ ]";
        }

    }
}
