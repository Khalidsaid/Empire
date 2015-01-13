using System;

namespace Adventure.Library.Commons
{
    public class Coordinate : IComparable<Coordinate>, IEquatable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Coordinate() : this(0,0) { }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return String.Format("[{0};{1}]", this.X, this.Y);
        }


        public int CompareTo(Coordinate other)
        {
            return ((this.X - other.X) == 0) ? (this.Y - other.Y) : (this.X - other.X);
        }

        public bool Equals(Coordinate other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

    }
}
