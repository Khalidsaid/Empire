using Adventure.Library.Environments.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Gameboards
{
    public class Gameboard : IGameboard
    {
        public Gameboard() : base() { }
        public Gameboard(int rowCount) : this(rowCount, rowCount) { }
        public Gameboard(int rowCount, int columnCount) { }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int Height
        {
            get { throw new NotImplementedException(); }
        }

        public int Width
        {
            get { throw new NotImplementedException(); }
        }
    }
}
