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

namespace Adventure.Games.WPF.Views
{
    /// <summary>
    /// Logique d'interaction pour Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.Register("RowCount", typeof(int), typeof(Board), new PropertyMetadata(8));
        public int RowCount
        {
            get { return (int)GetValue(RowCountProperty); }
            set { SetValue(RowCountProperty, value); }
        }

        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register("ColumnCount", typeof(int), typeof(Board), new PropertyMetadata(8));
        public int ColumnCount
        {
            get { return (int)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }

        public Board()
        {
            DataContext = this;
            InitializeComponent();
        }
        

        
        private void Board_Loaded(object sender, RoutedEventArgs e)
        {
            this.RefreshGrid();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch(e.Property.Name)
            {
                case "RowCount":
                    this.RefreshGrid();
                    break;
                case "ColumnCount" :
                    this.RefreshGrid();
                    break;
            }
        }

        public void RefreshGrid()
        {
            for (int i = 0; i < this.uniformBoardGrid.Rows * this.uniformBoardGrid.Columns; i++)
            {
                var rectangle = new Rectangle();
                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                rectangle.StrokeThickness = 0.5;
                this.uniformBoardGrid.Children.Add(rectangle);
            }
        }
    }
}
