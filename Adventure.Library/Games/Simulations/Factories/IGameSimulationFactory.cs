using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Games.Simulations.Factories
{
    public interface IGameSimulationFactory
    {
        IGameSimulation CreateGameSimulation();
    }

    public interface IGameSimulationFactory<T> where T : IGameSimulation, new()
    {
        T CreateGameSimulation();
    }

}
