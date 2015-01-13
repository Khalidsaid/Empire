using Adventure.Games.WPF.Mazes.Commons;
using Adventure.Library.Mazes.Builders;
using Adventure.Library.Mazes.GameBoards;
using Adventure.Library.Mazes.Games.Simulations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Adventure.Games.WPF.Mazes.ViewModels
{
    public class MazeViewModel : INotifyPropertyChanged
    {
        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Implement INotifyPopertyChanged

        #region Commands
        private DelegateCommand buildCommand;
        public DelegateCommand BuildCommand { get { return this.buildCommand; } set { SetProperty(ref this.buildCommand, value); } }

        private DelegateCommand initializeCommand;
        public DelegateCommand InitializeCommand { get { return this.initializeCommand; } set { SetProperty(ref this.initializeCommand, value); } }

        private DelegateCommand newMazeCommand;
        public DelegateCommand NewMazeCommand { get { return this.newMazeCommand; } set { SetProperty(ref this.newMazeCommand, value); } }
        #endregion Commands

        #region Properties

        public MazeGameSimulation MazeGameSimulation { get; private set; }

        public int Width { get {  return this.MazeGameSimulation.Width; } }
        public int Height { get { return this.Maze.Height; } }
        
        
        public Maze Maze { get; set; }

        public SettingsViewModel Settings { get; private set; }
        public bool MazeIsGenerated
        {
            get { return this.MazeGameSimulation.State.HasFlag(StateMazeGame.Initialized); }
        }

        #endregion Properties

        #region Constructors
        public MazeViewModel()
        {
            this.Settings = new SettingsViewModel(3,3);

            this.BuildCommand = new DelegateCommand(async _ => await this.BuildAsync(), () => { return !this.MazeIsGenerated; });
            //this.InitializeCommand = new DelegateCommand(async _ => await this.InitializeAsync(), () => { return true; });
            this.NewMazeCommand = new DelegateCommand(async _ => await this.NewMazeAsync(), () => { return true; });

        }
        #endregion Constructors

        
        public Border this[int x, int y]
        {
            get
            {
                var t = new Thickness();
                var d = this.Maze.GetWalls(x, y);
                if (d.HasFlag(Direction.Top)) t.Top = 1;
                if (d.HasFlag(Direction.Bottom)) t.Bottom = 1;
                if (d.HasFlag(Direction.Left)) t.Left = 1;
                if (d.HasFlag(Direction.Right)) t.Right = 1;
                return new Border() { BorderThickness = t, BorderBrush = Brushes.Black };
            }
        }

        public async Task BuildAsync()
        {
            await this.MazeGameSimulation.BuildMazeAsync();
        }

        //public async Task InitializeAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task NewMazeAsync()
        {
            var width = this.Settings.Width;
            var height = this.Settings.Height;
            await this.MazeGameSimulation.CreateNewGameAsync(width, height);
        }
    }
}
