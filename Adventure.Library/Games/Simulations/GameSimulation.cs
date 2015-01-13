using Adventure.Library.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure.Library.Games.Simulations
{
    public class GameSimulation : IGameSimulation
    {
        private readonly GameEnvironment gameEnvironnement;

        public int Height { get; set; }
        public int Width { get; set; }



        public IList<ACharacter> Characters { get; set; }

        public GameSimulation()
            : this(10, 10)
        {

        }

        public GameSimulation(int width, int height)
        {
            this.gameEnvironnement = new GameEnvironment();

            this.Width = width;
            this.Height = height;
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
