using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure.Library
{
   public class Area
    {
        int Row { get; set; }
        int Column { get; set; }

        public Area(int row, int column)
        {
            Row = row;
            Column = column;
        }

        
    }
}
