using Adventure.Games.WPF.ViewModels.Commons;
using Adventure.Library.Games.Simulations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Adventure.Games.WPF.ViewModels
{
    public class GameViewModel : BindableBase, IGameViewModel
    {
        /// <summary>
        /// Gets or sets the current Game instance.
        /// </summary>
        public IGameSimulation Game { get; private set; }

        /// <summary>
        /// Gets the height in the current game.
        /// </summary>
        public int Height { get { return Game.Height; } }

        ///// <summary>
        ///// Gets the width in the current game.
        ///// </summary>
        public int Widrh { get { return Game.Width; } }

        public GameViewModel()
        {
            this.Game = new GameSimulation();
        }

    }
}
