using Adventure.Library.Characters;
using Adventure.Library;
using Adventure.Library.Characters.Factories;
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
using System.IO;
using Adventure.Library.Fight;
using Adventure.Library.Games;
using System.Windows.Threading;

namespace Tamagochi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameEnvironment gameEnvironnement = new GameEnvironment();
        CharacterFactory charactereFactory;
        public List<Area> arrayAreas = new List<Area>();
        public List<Area> arrayAreasElephant = new List<Area>();
        public List<Area> arrayAreasArmee = new List<Area>();

        Area areaKing= new Area();
        Area areaKnihgt= new Area();
        Area areaArcher= new Area();
        Area areaSoldier= new Area();
        Area areaElephant1= new Area();
        Area areaElephant2= new Area();
        Area areaElephant3= new Area();
        Image imageKing = new Image();
        Image imageKnight = new Image();
        Image imageSoldier = new Image();
        Image imageArcher = new Image();
        Image imageElephant1 = new Image();
        Image imageElephant2 = new Image();
        Image imageElephant3 = new Image();
        Fight fight = new Fight();
        bool mort = false;
        int objectif = 2;


        DispatcherTimer _timer;
        TimeSpan _time = TimeSpan.FromSeconds(20);

        public MainWindow()
        {
            InitializeComponent();
            objectif = gameEnvironnement.SetObjectif();

            labelnbe.Content = objectif;

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;

            gameEnvironnement.CreateGame(charactereFactory, areaKnihgt, areaSoldier, areaArcher, areaKing, areaElephant1, areaElephant2, areaElephant3, arrayAreas, arrayAreasArmee, arrayAreasElephant);

            CreateImage(imageKnight, areaKnihgt, Directory.GetCurrentDirectory() + @".\..\..\Images\knight.gif");
            CreateImage(imageArcher, areaArcher, Directory.GetCurrentDirectory() + @"\..\..\Images\archer.gif");
            CreateImage(imageKing, areaKing, Directory.GetCurrentDirectory() + @"\..\..\Images\king.png");
            CreateImage(imageElephant1, areaElephant1, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageElephant2, areaElephant2, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageElephant3, areaElephant3, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageSoldier, areaSoldier, Directory.GetCurrentDirectory() + @"\..\..\Images\soldier.gif");


            _timer.Start();

        }

        void _timer_Tick(object sender, EventArgs e)
        {
            label1.Content = _time.ToString("c");
            if (_time.Seconds == 0)
            {
                _timer.Stop();
                IsKingAlive();
            }
            else
                _time = _time.Add(TimeSpan.FromSeconds(-1));
        }

        public void CreateImage(Image image, Area area, String imgUrl)
        {
            image.Width = 50;
            image.Height = 50;
            ImageSource imageSource = new BitmapImage(new Uri(imgUrl));
            image.Source = imageSource;
            Grid.SetRow(image, area.Row);
            Grid.SetColumn(image, area.Column);
            grid.Children.Add(image);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_time.Seconds == 0)
                return;
            grid.Children.Remove(imageKnight);
            grid.Children.Remove(imageArcher);
            grid.Children.Remove(imageSoldier);

            if (e.Key == Key.Up)
            {
                if (areaKnihgt.Row > 0)
                    areaKnihgt.Row -= 1;
            }
            if (e.Key == Key.Down)
            {
                if (areaKnihgt.Row < 9)
                    areaKnihgt.Row += 1;
            }
            if (e.Key == Key.Left)
            {
                if (areaKnihgt.Column > 0)
                    areaKnihgt.Column -= 1;
            }
            if (e.Key == Key.Right)
            {
                if (areaKnihgt.Column < 9)
                    areaKnihgt.Column += 1;
            }

            if (e.Key == Key.NumPad5)
            {
                if (areaArcher.Row > 0)
                    areaArcher.Row -= 1;
            }
            if (e.Key == Key.NumPad2)
            {
                if (areaArcher.Row < 9)
                    areaArcher.Row += 1;
            }
            if (e.Key == Key.NumPad1)
            {
                if (areaArcher.Column > 0)
                    areaArcher.Column -= 1;
            }
            if (e.Key == Key.NumPad3)
            {
                if (areaArcher.Column < 9)
                    areaArcher.Column += 1;
            }

            if (e.Key == Key.Z)
            {
                if (areaSoldier.Row > 0)
                    areaSoldier.Row -= 1;
            }
            if (e.Key == Key.S)
            {
                if (areaSoldier.Row < 9)
                    areaSoldier.Row += 1;
            }
            if (e.Key == Key.Q)
            {
                if (areaSoldier.Column > 0)
                    areaSoldier.Column -= 1;
            }
            if (e.Key == Key.D)
            {
                if (areaSoldier.Column < 9)
                    areaSoldier.Column += 1;
            }
            CreateImage(imageKnight, areaKnihgt, Directory.GetCurrentDirectory() + @".\..\..\Images\knight.gif");
            CreateImage(imageArcher, areaArcher, Directory.GetCurrentDirectory() + @".\..\..\Images\archer.gif");
            CreateImage(imageSoldier, areaSoldier, Directory.GetCurrentDirectory() + @".\..\..\Images\soldier.gif");

            
            if (fight.Kill(areaElephant1, arrayAreasArmee) != null)
            {
                grid.Children.Remove(imageElephant1);
                if (areaArcher == fight.Kill(areaElephant1, arrayAreasArmee))
                    labelArcher.Content = Convert.ToInt16(labelArcher.Content) + 1;
                else if (areaSoldier == fight.Kill(areaElephant1, arrayAreasArmee))
                    labelSoldier.Content = Convert.ToInt16(labelSoldier.Content) + 1;
                else if (areaKnihgt == fight.Kill(areaElephant1, arrayAreasArmee))
                    labelKnight.Content = Convert.ToInt16(labelKnight.Content) + 1;
                areaElephant1.KillArea();
            }

            if (fight.Kill(areaElephant2, arrayAreasArmee) != null)
            {
                if (areaArcher == fight.Kill(areaElephant2, arrayAreasArmee))
                    labelArcher.Content = Convert.ToInt16(labelArcher.Content) + 1;
                else if (areaSoldier == fight.Kill(areaElephant2, arrayAreasArmee))
                    labelSoldier.Content = Convert.ToInt16(labelSoldier.Content) + 1;
                else if (areaKnihgt == fight.Kill(areaElephant2, arrayAreasArmee))
                    labelKnight.Content = Convert.ToInt16(labelKnight.Content) + 1;
                grid.Children.Remove(imageElephant2);
                areaElephant2.KillArea();
            }

            if (fight.Kill(areaElephant3, arrayAreasArmee) != null)
            {
                grid.Children.Remove(imageElephant3);
                if (areaArcher == fight.Kill(areaElephant3, arrayAreasArmee))
                    labelArcher.Content = Convert.ToInt16(labelArcher.Content) + 1;
                else if (areaSoldier == fight.Kill(areaElephant3, arrayAreasArmee))
                    labelSoldier.Content = Convert.ToInt16(labelSoldier.Content) + 1;
                else if (areaKnihgt == fight.Kill(areaElephant3, arrayAreasArmee))
                    labelKnight.Content = Convert.ToInt16(labelKnight.Content) + 1;
                areaElephant3.KillArea();
            }

            if (fight.Kill(areaKing, arrayAreasArmee) != null)
            {
                if (areaArcher == fight.Kill(areaKing, arrayAreasArmee))
                {
                    if (Convert.ToInt16(labelArcher.Content) > 0)
                    {
                        labelKing.Content = Convert.ToInt16(labelKing.Content) + Convert.ToInt16(labelArcher.Content);
                        labelArcher.Content = 0;
                    }
                }
                else if (areaSoldier == fight.Kill(areaKing, arrayAreasArmee))
                {
                    if (Convert.ToInt16(labelSoldier.Content) > 0)
                    {
                        labelKing.Content = Convert.ToInt16(labelKing.Content) + Convert.ToInt16(labelSoldier.Content);
                        labelSoldier.Content = 0;
                    }
                }
                else if (areaKnihgt == fight.Kill(areaKing, arrayAreasArmee))
                {
                    if (Convert.ToInt16(labelKnight.Content) > 0)
                    {
                        labelKing.Content = Convert.ToInt16(labelKing.Content) + Convert.ToInt16(labelKnight.Content);
                        labelKnight.Content = 0;
                    }
                }
            }

        }
       

        public bool IsKingAlive()
        {
            if (_time.Seconds == 0)
            {

                if (Convert.ToInt16(labelKing.Content) != objectif)
                {
                    LabelGameOver.Content = "Game Over";
                    mort = true;
                }
                else
                {
                    LabelGameOver.Content="Success";
                    mort = false;
                }
                LabelGameOver.Visibility = Visibility.Visible;
                Button1.Visibility = Visibility.Visible;
            }
            mort=false;
            return mort;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            LabelGameOver.Visibility = Visibility.Hidden;
            Button1.Visibility = Visibility.Hidden;
            arrayAreasArmee.Clear();
            arrayAreasElephant.Clear();
            arrayAreas.Clear();

            new MainWindow().WindowStartupLocation = this.WindowStartupLocation;
            this.Close();
        }
    }
}
