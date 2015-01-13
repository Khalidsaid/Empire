using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Adventure.Games.WPF.ViewModels
{
    public interface IHomeViewModel : INotifyPropertyChanged
    {
        IList<Type> GameSimulations { get; }
        Type SelectedGameSimulation { get; }
    }
}
