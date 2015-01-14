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
        public Area()
        {            
        }

        public void SetInitialArea()
        {
            Random random = new Random();
            int row = random.Next(0, 9);
            this.Row = row;
            int column = random.Next(0, 9);
            this.Column = column;
        }


        public void ModifyAreaIfExist(List<Area> arrayAreas)
        {
            foreach (var area in arrayAreas)
            {
                while (this.Row == area.Row && this.Column == area.Column)
                {
                    SetInitialArea();
                }
            }
        }

        
    }
}
