using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Games.Simulations.Factories
{
    public class GameSimulationFactory : IGameSimulationFactory
    {
        public IGameSimulation CreateGameSimulation()
        {
            return new GameSimulation();
        }
    }

    public class GameSimulationFactory<T> : IGameSimulationFactory<T> where T : GameSimulation, new()
    {
        public T CreateGameSimulation()
        {
            return new T();
        }
    }
}
