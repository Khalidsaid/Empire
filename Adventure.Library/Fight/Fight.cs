using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure.Library.Fight
{
    public class Fight
    {
        public Fight()
        {

        }

        public Area Kill(Area areaElephant, List<Area> listAreaArmee)
        {
            foreach (var areaArmee in listAreaArmee)
            {
                if (areaArmee.Row == areaElephant.Row && areaArmee.Column == areaElephant.Column)
                    return areaArmee;
            }
            return null;
        }

      

        public Area WhichArmee(Area a, List<Area> listAreaArmee)
        {
            foreach (var area in listAreaArmee)
            {
                if (a == area)
                {
                    
                    return area;
                }
            }
            return null;
        }
    }
}
