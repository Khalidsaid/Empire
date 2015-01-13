using Adventure.Library.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure.Library.Game
{
    public class SimpleSimulation
    {
        public IList<ACharacter> Characters { get; set; }
        public SimpleSimulation(IList<ACharacter> characters)
        {
            this.Characters = characters;
        }

        public override string ToString()
        {
            if (Characters.Count > 0)
            {
                return String.Join(Environment.NewLine + Environment.NewLine, Characters.Select(c => c.ToString()));
            }
            return "No Chararcter";
        }

    }
}
