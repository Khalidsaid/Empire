using Adventure.Library.Commons;
using Adventure.Library.Mazes.GameBoards;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Adventure.Games.WPF.Mazes.Views
{
    /// <summary>
    /// Logique d'interaction pour MazeBoard.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        Dictionary<string, Border> borders;

        public MazeBoard()
        {
            this.borders = new Dictionary<string, Border>();
            InitializeComponent();
            //this.mazeViewModel.Maze.DestroyWallEvent += Maze_DestroyWallEvent;
            //this.mazeViewModel.Maze.BuildWallEvent += Maze_BuildWallEvent;
        }

        private void Maze_BuildWallEvent(object sender, Coordinate c, Direction d)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Border b = new Border();
                Thickness t = new Thickness(0);

                if (this.borders.TryGetValue(c.ToString(), out b))
                {
                    this.mazeGrid.Children.Remove(b);
                    t = b.BorderThickness;
                }

                if (d.HasFlag(Direction.Left)) t.Left = 1;
                if (d.HasFlag(Direction.Right)) t.Right = 1;
                if (d.HasFlag(Direction.Top)) t.Top = 1;
                if (d.HasFlag(Direction.Bottom)) t.Bottom = 1;

                b = new Border() { BorderThickness = t, BorderBrush = Brushes.Black };
                Grid.SetColumn(b, c.X);
                Grid.SetRow(b, c.Y);
                this.mazeGrid.Children.Add(b);
                this.borders[c.ToString()] = b;
            });
        }

        private void Maze_DestroyWallEvent(object sender, Library.Commons.Coordinate c, Library.Mazes.GameBoards.Direction d)
        {
            Application.Current.Dispatcher.Invoke(() =>
           {
               Border b = new Border();
               Thickness t = new Thickness(1);

               if (this.borders.TryGetValue(c.ToString(), out b))
               {
                   this.mazeGrid.Children.Remove(b);
                   t = b.BorderThickness;
               }

               if (d.HasFlag(Direction.Left)) t.Left = 0;
               if (d.HasFlag(Direction.Right)) t.Right = 0;
               if (d.HasFlag(Direction.Top)) t.Top = 0;
               if (d.HasFlag(Direction.Bottom)) t.Bottom = 0;
               b = new Border() { BorderThickness = t, BorderBrush = Brushes.Black };
               Grid.SetColumn(b, c.X);
               Grid.SetRow(b, c.Y);
               this.mazeGrid.Children.Add(b);
               this.borders[c.ToString()] = b;

               if (d.HasFlag(Direction.Left)) c.X--;
               if (d.HasFlag(Direction.Right)) c.X++;
               if (d.HasFlag(Direction.Top)) c.Y--;
               if (d.HasFlag(Direction.Bottom)) c.Y++;
               if (c.X < 0 || c.Y < 0) return;

               b = new Border();

               if (this.borders.TryGetValue(c.ToString(), out b))
               {
                   this.mazeGrid.Children.Remove(b);
                   t = b.BorderThickness;
               }
               else
                   t = new Thickness(1);

               if (d.HasFlag(Direction.Left)) t.Right = 0;
               if (d.HasFlag(Direction.Right)) t.Left = 0;
               if (d.HasFlag(Direction.Top)) t.Bottom = 0;
               if (d.HasFlag(Direction.Bottom)) t.Top = 0;
               b = new Border() { BorderThickness = t, BorderBrush = Brushes.Black };
               Grid.SetColumn(b, c.X);
               Grid.SetRow(b, c.Y);
               this.mazeGrid.Children.Add(b);
               this.borders[c.ToString()] = b;
           });
        }

        private void MazeBoard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

    }
}
