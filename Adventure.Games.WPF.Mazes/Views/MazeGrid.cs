using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Adventure.Games.WPF.Mazes.Views
{
    public class MazeGrid : Grid
    {
        public static readonly DependencyProperty RowCountProperty = DependencyProperty.Register(
          "RowCount", typeof(int), typeof(MazeGrid), new PropertyMetadata(0, new PropertyChangedCallback(RowCountPropertyChanged)));
        public int RowCount
        {
            get { return (int)this.GetValue(RowCountProperty); }
            set { this.SetValue(RowCountProperty, value); }
        }

        public static readonly DependencyProperty ColumnCountProperty = DependencyProperty.Register(
          "ColumnCount", typeof(int), typeof(MazeGrid), new PropertyMetadata(0, new PropertyChangedCallback(ColumnCountPropertyChanged)));
        public int ColumnCount
        {
            get { return (int)this.GetValue(ColumnCountProperty); }
            set { this.SetValue(ColumnCountProperty, value); }
        }

        public delegate void RowCountEventHandler(object sender, DependencyPropertyChangedEventArgs e);
        public delegate void ColumnCountEventHandler(object sender, DependencyPropertyChangedEventArgs e);

        private static void RowCountPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is MazeGrid)
            {
                var grid = sender as MazeGrid;
                grid.RowDefinitions.Clear();
                for (int i = 0; i < grid.RowCount; i++)
                    grid.RowDefinitions.Add(new RowDefinition() {  });
            }
        }
        private static void ColumnCountPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is MazeGrid)
            {
                var grid = sender as MazeGrid;
                grid.ColumnDefinitions.Clear();
                for (int i = 0; i < grid.ColumnCount; i++)
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public MazeGrid()
        {

        }

    }
}
