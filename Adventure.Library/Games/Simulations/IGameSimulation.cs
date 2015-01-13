using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Games.Simulations
{
    public interface IGameSimulation
    {
        /// <summary>
        /// Gets or sets the height in the current game.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets or sets the width in the current game.
        /// </summary>
        int Width { get; }
    }
}
