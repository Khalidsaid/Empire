using Adventure.Games.WPF.Commands;
using Adventure.Games.WPF.ViewModels;
using Adventure.Games.WPF.Views;
using Adventure.Library.Games.Simulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adventure.Games.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainGameStart.xaml
    /// </summary>
    public partial class MainGameStart : Window
    {
        #region ViewModels 
        private IGameViewModel gameViewModel;
        private IHomeViewModel homeViewModel;
        #endregion ViewModels

        #region UserControl
        private Home home;
        private Board board;
        #endregion UserControl
        
        #region Constructor
        public MainGameStart()
        {
            InitializeComponent();
            this.InitializeHomeViewModel();
            this.home = new Home() { DataContext = this.homeViewModel };
            this.mainPage.Content = home;
        }
        #endregion Constructor
        
        #region Initializer
        private void InitializeHomeViewModel()
        {
            this.homeViewModel = new HomeViewModel(
                new List<Type> { typeof(GameSimulation) },
                this.StartGame
            );
        }

        private void InitializeGameViewModel()
        {
            this.gameViewModel = new GameViewModel();
        }

        #endregion Initializer

        #region Actions
        public void StartGame()
        {
            this.board = new Board();
            
            this.mainPage.Content = board;
        }
        #endregion Actions
    }
}
