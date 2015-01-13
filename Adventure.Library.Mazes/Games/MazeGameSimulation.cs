using Adventure.Library.Games.Simulations;
using Adventure.Library.Mazes.Builders;
using Adventure.Library.Mazes.Environments.Zones;
using Adventure.Library.Mazes.GameBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Library.Mazes.Games.Simulations
{
    public enum StateMazeGame { None, Initialized, Win, GameOver }

    public class MazeGameSimulation : IGameSimulation
    {
        #region Private Properties
        private Random random = new Random();
        private Maze maze;
        private Stack<Square> stack = new Stack<Square>();
        #endregion Private Properties

        #region Public Properties

        public IMazeBuilder MazeBuilder { get; private set; }
        public int Height
        {
            get { return this.maze.Height; }
        }
        public int Width
        {
            get { return this.maze.Width; }
        }
        public Square Start { get; private set; }
        public Square End { get; private set; }
        public Square Current { get; private set; }
        public StateMazeGame State { get; private set; }
        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Default is RandomMazeBuilder
        /// </summary>
        public MazeGameSimulation()
            : this(new RandomMazeBuilder())
        {
        }

        public MazeGameSimulation(IMazeBuilder mazeBuilder)
        {
            this.State = StateMazeGame.None;
            this.MazeBuilder = mazeBuilder;
        }

        #endregion Constructors

        public Task CreateNewGameAsync(int width, int height)
        {
            return Task.Run(async () =>
            {
                await this.MazeBuilder.CreateNewMazeAsync(width, height);
                await this.MazeBuilder.InitializeAsync();
                this.maze = MazeBuilder.Maze;
            });
        }

        public Task BuildMazeAsync()
        {
            return Task.Run(async () =>
            {
                await this.MazeBuilder.BuildAsync();

                this.RandomizeStart().State = StateSquare.Start;
                this.RandomizeEnd().State = StateSquare.End;
            });
        }

        public Task RunAsync()
        {
            return Task.Run(() =>
            {
                this.Current = this.Start;
                this.Current.State = StateSquare.Visited;
            });
        }

        #region Randomize Start/End
        public Square RandomizeStart()
        {
            this.Start = this.maze[random.Next(this.Width), random.Next(this.Height)];
            return this.Start ?? RandomizeStart();
        }

        public Square RandomizeEnd()
        {
            this.End = this.maze[random.Next(this.Width), random.Next(this.Height)];
            return this.End ?? RandomizeEnd();
        }
        #endregion Randomize Start/End

        #region Randomize
        public Task NextRandomizeAsync()
        {
            return Task.Run(async () =>
            {
                var next = await GetNextRandomizeMoveAsync();
                if (next == null) this.State = StateMazeGame.GameOver;
                this.Move(next);

                if (this.Current == this.End) this.State = StateMazeGame.Win;
            });
        }

        public Task<Square> GetNextRandomizeMoveAsync()
        {
            return Task<Square>.Run(() =>
            {
                return this.GetNextRandomizeMove();
            });
        }

        public Square GetNextRandomizeMove()
        {
            if (this.Current != null)
            {
                var moves = this.GetValideNextMoves();
                if (moves.Count() == 1)
                    return moves.ElementAt(0);
                if (moves.Count() > 1)
                    return moves.ElementAt(random.Next(moves.Count()));
            }
            return null;
        }
        #endregion Randomize

        #region DFS

        public Task NextDFSAsync()
        {
            return Task.Run(async () =>
            {
                var next = await GetNextDSFMoveAsync();
                if (next == null)
                {
                    if (stack.Count > 0)
                        next = this.stack.Pop();
                    else
                        this.State = StateMazeGame.GameOver;
                }
                else
                    this.stack.Push(this.Current);
                this.Move(next);

                if (this.Current == this.End) this.State = StateMazeGame.Win;
            });
        }

        public Task<Square> GetNextDSFMoveAsync()
        {
            return Task<Square>.Run(() =>
            {
                return this.GetNextDSFMove();
            });
        }

        public Square GetNextDSFMove()
        {
            if (this.Current != null)
            {
                var moves = this.GetValideNextMoves().Where(m => !m.State.HasFlag(StateSquare.Visited));
                if (moves.Count() == 1)
                    return moves.ElementAt(0);
                if (moves.Count() > 1)
                {
                    if (moves.Contains(this.End)) return this.End;
                    return moves.ElementAt(random.Next(moves.Count()));
                }
            }
            return null;
        }

        #endregion DFS

        #region Move
        public void Move(Square square)
        {
            if (!IsValideMove(square)) return;
            this.Current = square;
            this.Current.State |= StateSquare.Visited;
        }

        public bool IsValideMove(Square square)
        {
            return this.GetNeighbours(this.Current).Contains(square);
        }
        public IEnumerable<Square> GetValideNextMoves()
        {
            if (this.Current == null)
                throw new NullReferenceException("GetValideNextMoves : Current is null");

            var c = this.Current.Coordinate;
            var walls = this.maze.GetWalls(c);

            if (!walls.HasFlag(Direction.Top) && this.maze.ContainsKey(c.X, c.Y - 1))
                yield return this.maze[c.X, c.Y - 1];
            if (!walls.HasFlag(Direction.Bottom) && this.maze.ContainsKey(c.X, c.Y + 1))
                yield return this.maze[c.X, c.Y + 1];
            if (!walls.HasFlag(Direction.Left) && this.maze.ContainsKey(c.X - 1, c.Y))
                yield return this.maze[c.X - 1, c.Y];
            if (!walls.HasFlag(Direction.Right) && this.maze.ContainsKey(c.X + 1, c.Y))
                yield return this.maze[c.X + 1, c.Y];
        }

        #endregion Move

        public IEnumerable<Square> GetNeighbours(Square z)
        {
            if (z == null) yield break;
            var c = z.Coordinate;
            if (this.maze.ContainsKey(c.X + 1, c.Y)) yield return this.maze[c.X + 1, c.Y];
            if (this.maze.ContainsKey(c.X - 1, c.Y)) yield return this.maze[c.X - 1, c.Y];
            if (this.maze.ContainsKey(c.X, c.Y + 1)) yield return this.maze[c.X, c.Y + 1];
            if (this.maze.ContainsKey(c.X, c.Y - 1)) yield return this.maze[c.X, c.Y - 1];
        }

        public override string ToString()
        {
            return this.maze.ToString();
        }
    }
}
