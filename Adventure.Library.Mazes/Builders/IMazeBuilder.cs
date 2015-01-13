using Adventure.Library.Mazes.GameBoards;
using System.Threading.Tasks;

namespace Adventure.Library.Mazes.Builders
{
    public interface IMazeBuilder
    {
        Maze Maze { get; }
        bool MazeIsCreated { get; }

        void CreateNewMaze(int rowCount, int columnCount);
        Task CreateNewMazeAsync(int width, int height);

        void Initialize();
        Task InitializeAsync();

        void Build();
        Task BuildAsync();

    }
}
