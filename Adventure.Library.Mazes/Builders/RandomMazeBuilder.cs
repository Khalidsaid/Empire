using Adventure.Library.Commons;
using Adventure.Library.Environments.Zones;
using Adventure.Library.Mazes.Environments.Zones;
using Adventure.Library.Mazes.GameBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure.Library.Mazes.Builders
{
    public class RandomMazeBuilder : IMazeBuilder
    {
        #region Properties

        public Maze Maze { get; protected set; }

        private readonly Random random = new Random();
        private HashSet<Coordinate> visitedCoordinate;

        public bool MazeIsCreated { get { return this.Maze != null; } }
        public bool MazeIsGenerated { get; private set; }
        public bool MazeIsInitialized { get; private set; }
        #endregion Properties

        public void CreateNewMaze(int width, int height)
        {
            this.Maze = new Maze(width, height);
        }

        public Task CreateNewMazeAsync(int width, int height)
        {
            return Task.Run(() =>
            {
                this.CreateNewMaze(width, height);
            });
        }

        public void Initialize()
        {
            if (!MazeIsCreated) throw new NullReferenceException("Initialize : Maze was not created.");
            this.Maze.Clear();
            for (int y = 0; y < Maze.Height; y++)
            {
                for (int x = 0; x < Maze.Width; x++)
                {
                    this.Maze[x, y] = new Square(x, y);
                    this.Maze.BuildWalls(x, y, Direction.All);
                }
            }
        }

        public Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                this.Initialize();
            });
        }

        public void Build()
        {
            if (!MazeIsCreated) throw new NullReferenceException("Build : Maze was not created.");
            this.GenerateMazeRecursiveBacktracker();
        }

        public Task BuildAsync()
        {
            return Task.Run(() =>
            {
                this.Build();
            });
        }

        private void GenerateMazeRecursiveBacktracker()
        {
            var rowCount = this.Maze.Height;
            var columnCount = this.Maze.Width;

            if (rowCount < 2 || columnCount < 2) return;

            this.visitedCoordinate = new HashSet<Coordinate>();
            var current = this.GetRandomZone(this.Maze.Zones.SelectMany(kvp => kvp.Value.Values)).Coordinate;
            this.DepthFirstSearch(current);
        }

        private void DepthFirstSearch(Coordinate current)
        {
            this.visitedCoordinate.Add(current);

            var next = this.RecursiveBacktrackerNext(current);
            while (next != null)
            {
                this.DepthFirstSearch(next);
                next = this.RecursiveBacktrackerNext(current);
            }
        }


        public Coordinate RecursiveBacktrackerNext(Coordinate current)
        {
            var neighbours = this.GetNeighbours(current).Where(n => !visitedCoordinate.Contains(n.Coordinate));

            switch (neighbours.Count())
            {
                case 0:
                    return null;
                default:
                    var next = this.GetRandomZone(neighbours).Coordinate;

                    var direction = this.GetDirection(current, next);
                    var directionToList = Enum.GetValues(typeof(Direction)).Cast<Direction>().Where(d => direction.HasFlag(d)).ToList();
                    directionToList.Remove(Direction.None); //Ignore direction None

                    if (directionToList.Count > 1)
                        direction = directionToList[random.Next(directionToList.Count)];

                    this.Maze.DestroyWalls(current, direction);
                    return next;
            }
        }

        public IZone GetRandomZone(IEnumerable<IZone> list)
        {
            return list.ElementAtOrDefault(random.Next(list.Count()));
        }

        public IEnumerable<IZone> GetNeighbours(int x, int y)
        {
            if (this.Maze.ContainsKey(x - 1, y)) yield return this.Maze[x - 1, y];
            if (this.Maze.ContainsKey(x + 1, y)) yield return this.Maze[x + 1, y];
            if (this.Maze.ContainsKey(x, y - 1)) yield return this.Maze[x, y - 1];
            if (this.Maze.ContainsKey(x, y + 1)) yield return this.Maze[x, y + 1];
        }

        public IEnumerable<IZone> GetNeighbours(Coordinate c)
        {
            return this.GetNeighbours(c.X, c.Y);
        }

        public Direction GetDirection(Coordinate current, Coordinate next)
        {
            return this.GetDirection(current.X, current.Y, next.X, next.Y);
        }

        public Direction GetDirection(int currentX, int currentY, int nextX, int nextY)
        {
            var deltaX = nextX - currentX;
            var deltaY = nextY - currentY;
            var direction = Direction.None;
            if (deltaX > 0) direction |= Direction.Right;
            if (deltaX < 0) direction |= Direction.Left;
            if (deltaY > 0) direction |= Direction.Bottom;
            if (deltaY < 0) direction |= Direction.Top;

            return direction;
        }

    }
}
