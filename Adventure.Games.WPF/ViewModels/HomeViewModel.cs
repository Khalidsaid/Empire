using Adventure.Games.WPF.Commands;
using Adventure.Games.WPF.ViewModels.Commons;
using Adventure.Library.Games.Simulations.Factories;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Adventure.Games.WPF.ViewModels
{
    public class HomeViewModel : BindableBase, IHomeViewModel
    {
        #region Properties

        private IGameSimulationFactory gameSimulationFactory;

        private Type selectedGameSimulation;
        public Type SelectedGameSimulation { get { return this.selectedGameSimulation; } set { SetProperty(ref this.selectedGameSimulation, value); } }

        public IList<Type> GameSimulations { get; set; }

        #endregion Properties

        #region Command

        private DelegateCommand startGameCommand;
        public DelegateCommand StartGameCommand { get { return this.startGameCommand; } set { this.SetProperty(ref this.startGameCommand, value); } }
     
        #endregion Command

        #region Constructors

        public HomeViewModel() : this(new List<Type>()){}

        public HomeViewModel(IList<Type> gameSimulations)
        {
            this.PropertyChanged += HomeViewModel_PropertyChanged;
            this.GameSimulations = gameSimulations;
            this.StartGameCommand = new DelegateCommand(_ => this.StartGame(), this.CanStartGame);
        }
        
        public HomeViewModel(IList<Type> gameSimulations, Action startGame)
        {
            this.PropertyChanged += HomeViewModel_PropertyChanged;
            this.GameSimulations = gameSimulations;
            this.StartGameCommand = new DelegateCommand(_ => startGame(), this.CanStartGame);
        }
        
        #endregion Constructors

        #region StartGameCommand
        public void StartGame()
        {
            MessageBox.Show(this.SelectedGameSimulation.ToString() ?? "null");
        }

        public bool CanStartGame()
        {
            return this.SelectedGameSimulation != null;
        }
        #endregion StartGameCommand

        #region EventHandler

        private void HomeViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "SelectedGameSimulation":
                    this.StartGameCommand.RaiseCanExecuteChanged();
                    break;
            }
        }
        #endregion EventHandler
    }
}
