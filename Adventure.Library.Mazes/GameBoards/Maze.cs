using Adventure.Library.Commons;
using Adventure.Library.Environments.Zones;
using Adventure.Library.Gameboards;
using Adventure.Library.Mazes.Commons;
using Adventure.Library.Mazes.Environments.Zones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure.Library.Mazes.GameBoards
{
    [Flags]
    public enum Direction { None = 0x0, Top = 0x1, Bottom = 0x2, Left = 0x4, Right = 0x8, All = Top | Bottom | Left | Right }

    public class Maze : IGameboard
    {
        public delegate void BuildWallEventHandler(object sender, Coordinate c, Direction d);
        public delegate void DestroyWallEventHandler(object sender, Coordinate c, Direction d);
        public delegate void MazeChangedEventHandler(object sender, Coordinate c);

        public event BuildWallEventHandler BuildWallEvent;
        public event DestroyWallEventHandler DestroyWallEvent;
        public event MazeChangedEventHandler MazeChangedEvent;

        #region Events
        protected virtual void OnBuildWallHandler(Coordinate c, Direction d)
        {
            if (BuildWallEvent != null)
                BuildWallEvent(this, c, d);
        }

        public virtual void OnDestroyWallHandler(Coordinate c, Direction d)
        {
            if (DestroyWallEvent != null)
                DestroyWallEvent(this, c, d);
        }

        protected virtual void OnMazeChangedHandler(Coordinate c)
        {
            if (MazeChangedEvent != null)
                MazeChangedEvent(this, c);
        }
        #endregion Events

        #region Operator []
        public Square this[Coordinate c]
        {
            get { return this[c.X, c.Y]; }
            set { this[c.X, c.Y] = value; }
        }
        public Square this[int x, int y]
        {
            get
            {
                Square z;
                this.Zones.TryGetValue(x, y, out z);
                return z;
            }
            set
            {
                if (!this.Zones.ContainsKey(y))
                    this.Zones.Add(y, new SortedDictionary<int, Square>());
                this.Zones[y][x] = value;
                OnMazeChangedHandler(new Coordinate(x, y));
            }
        }

        #endregion

        #region Implements IGameboard

        public int Height { get; private set; }

        public int Width { get; private set; }

        #endregion Implements IGameboard

        #region Properties

        public Matrix<bool> VerticalWalls { get; private set; }
        public Matrix<bool> HorizontalWalls { get; private set; }
        public Matrix<Square> Zones { get; private set; }
        #endregion Properties

        #region Constructors

        public Maze()
            : this(0, 0)
        {
        }

        public Maze(int witdh, int height)
        {
            this.Zones = new Matrix<Square>();
            this.VerticalWalls = new Matrix<bool>();
            this.HorizontalWalls = new Matrix<bool>();
            this.Width = witdh;
            this.Height = height;
        }

        #endregion Constructors

        #region ToString
        public override string ToString()
        {
            var boardToString = new StringBuilder();

            for (int y = 0; y < this.Height; y++)
            {
                if (this.Zones.ContainsKey(y))
                {
                    ///HorizontalWall row
                    for (int x = 0; x < this.Width; x++)
                    {
                        bool horizontalWall = false;
                        this.HorizontalWalls.TryGetValue(x, y, out horizontalWall);
                        if (horizontalWall)
                            boardToString.AppendFormat("------");
                        else
                            boardToString.AppendFormat("{0,6}", "");
                    }
                    boardToString.AppendLine();

                    ///Square row
                    for (int x = 0; x < this.Width; x++)
                    {
                        ///Vertical Wall
                        bool verticalWall = false;
                        this.VerticalWalls.TryGetValue(x, y, out verticalWall);
                        if (verticalWall)
                            boardToString.AppendFormat("{0,1}", "|");
                        else
                            boardToString.AppendFormat("{0,1}", " ");

                        Square zone;
                        if (this.Zones.TryGetValue(x, y, out zone))
                            boardToString.AppendFormat(" {0} ", zone.ToString());
                        else
                            boardToString.AppendFormat("{0,4}", "");
                    }
                    ///Last VerticalWall
                    bool lastVerticalWall = false;
                    this.VerticalWalls.TryGetValue(this.Width, y, out lastVerticalWall);
                    if (lastVerticalWall)
                        boardToString.AppendFormat("{0,1}", "|");


                }
                boardToString.AppendLine();

            }

            ///Last HorizontalWall row
            for (int x = 0; x < this.Width; x++)
            {
                bool lasthorizontalWall = false;
                this.HorizontalWalls.TryGetValue(x, this.Height, out lasthorizontalWall);
                if (lasthorizontalWall)
                    boardToString.AppendFormat("------");
                else
                    boardToString.AppendFormat("{0,6}", "");
            }
            boardToString.AppendLine();



            return boardToString.ToString();
        }
        #endregion ToString

        #region Walls

        public void BuildWalls(Coordinate coordinate, Direction direction)
        {
            this.BuildWalls(coordinate.X, coordinate.Y, direction);
        }
        public void BuildWalls(int x, int y, Direction direction)
        {
            if (direction.HasFlag(Direction.Top))
                this.HorizontalWalls[x, y] = true;
            if (direction.HasFlag(Direction.Bottom))
                this.HorizontalWalls[x, y + 1] = true;
            if (direction.HasFlag(Direction.Left))
                this.VerticalWalls[x, y] = true;
            if (direction.HasFlag(Direction.Right))
                this.VerticalWalls[x + 1, y] = true;
            this.OnBuildWallHandler(new Coordinate(x, y), direction);
        }


        public void DestroyWalls(Coordinate coordinate, Direction direction)
        {
            this.DestroyWalls(coordinate.X, coordinate.Y, direction);
        }
        public void DestroyWalls(int x, int y, Direction direction)
        {
            if (direction.HasFlag(Direction.Top))
                this.HorizontalWalls[x, y] = false;
            if (direction.HasFlag(Direction.Bottom))
                this.HorizontalWalls[x, y + 1] = false;
            if (direction.HasFlag(Direction.Left))
                this.VerticalWalls[x, y] = false;
            if (direction.HasFlag(Direction.Right))
                this.VerticalWalls[x + 1, y] = false;
            this.OnDestroyWallHandler(new Coordinate(x, y), direction);
        }

        public Direction GetWalls(Coordinate c)
        {
            return this.GetWalls(c.X, c.Y);
        }

        public Direction GetWalls(int x, int y)
        {
            Direction d = Direction.None;
            if (this.VerticalWalls[x, y])
                d |= Direction.Left;
            if (this.VerticalWalls[x + 1, y])
                d |= Direction.Right;
            if (this.HorizontalWalls[x, y])
                d |= Direction.Top;
            if (this.HorizontalWalls[x, y + 1])
                d |= Direction.Bottom;
            return d;
        }

        #endregion Walls

        public void Clear()
        {
            this.Zones.Clear();
            this.HorizontalWalls.Clear();
            this.VerticalWalls.Clear();
        }

        public bool ContainsKey(int x, int y)
        {
            return this.Zones.ContainsKey(x, y);
        }
    }
}