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
using System.Windows.Threading;

namespace Tamagochi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Area> arrayAreas = new List<Area>();
        public List<Area> arrayAreasElephant = new List<Area>();
        public List<Area> arrayAreasArmee = new List<Area>();

        Area areaKing;
        Area areaKnihgt;
        Area areaArcher;
        Area areaSoldier;
        Area areaPrincess;
        Area areaElephant1;
        Area areaElephant2;
        Area areaElephant3;
        Image imageKing = new Image();
        Image imageKnight = new Image();
        Image imageSoldier = new Image();
        Image imageArcher = new Image();
        Image imagePrincess = new Image();
        Image imageElephant1 = new Image();
        Image imageElephant2 = new Image();
        Image imageElephant3 = new Image();
        Fight fight = new Fight();

        DispatcherTimer _timer;
        TimeSpan _time = TimeSpan.FromSeconds(20);

        public MainWindow()
        {
            InitializeComponent();
          

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;

            var characterFactory = new CharacterFactory();
            areaKnihgt = new Area();
            areaKnihgt.SetInitialArea();
            arrayAreas.Add(areaKnihgt);


            areaPrincess = new Area();
            areaPrincess.SetInitialArea();
            areaPrincess.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaPrincess);

            areaSoldier = new Area();
            areaSoldier.SetInitialArea();
            areaSoldier.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaSoldier);

            areaArcher = new Area();
            areaArcher.SetInitialArea();
            areaArcher.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaArcher);

            areaKing = new Area();
            areaKing.SetInitialArea();
            areaKing.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaKing);


            areaElephant1 = new Area();
            areaElephant1.SetInitialArea();
            areaElephant1.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaElephant1);

            areaElephant2 = new Area();
            areaElephant2.SetInitialArea();
            areaElephant2.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaElephant2);

            areaElephant3 = new Area();
            areaElephant3.SetInitialArea();
            areaElephant3.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaElephant3);
            arrayAreasElephant.Add(areaElephant1);
            arrayAreasElephant.Add(areaElephant2);
            arrayAreasElephant.Add(areaElephant3);
            arrayAreasArmee.Add(areaKnihgt);
            arrayAreasArmee.Add(areaSoldier);
            arrayAreasArmee.Add(areaArcher);

            var characters = new List<ACharacter>(){
               
                characterFactory.CreateCharacter<Knight>(areaKnihgt, "Aragorn"),
                characterFactory.CreateCharacter<Princess>(areaPrincess,"Arwen"),
                characterFactory.CreateCharacter<Soldier>(areaSoldier,"Gimli"),
                characterFactory.CreateCharacter<Archer>(areaArcher,"Legolas"),
                characterFactory.CreateCharacter<King>(areaKing,"Leonidas"),
                characterFactory.CreateCharacter<Archer>(areaElephant1,"Elephant1"),
                characterFactory.CreateCharacter<Archer>(areaElephant2,"Elephant2"),
                characterFactory.CreateCharacter<Archer>(areaElephant3,"Elephant3")
            };
            
            CreateImage(imageKnight, areaKnihgt, Directory.GetCurrentDirectory() + @".\..\..\Images\knight.gif");
            CreateImage(imageSoldier, areaSoldier, Directory.GetCurrentDirectory() + @"\..\..\Images\soldier.gif");
            CreateImage(imageArcher, areaArcher, Directory.GetCurrentDirectory() + @"\..\..\Images\archer.gif");
            CreateImage(imageKing, areaKing, Directory.GetCurrentDirectory() + @"\..\..\Images\king.png");
            CreateImage(imageElephant1, areaElephant1, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageElephant2, areaElephant2, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageElephant3, areaElephant3, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");


            _timer.Start();

        }

        void _timer_Tick(object sender, EventArgs e)
        {
            label1.Content = _time.ToString("c");
            if (_time.Seconds == 0)
            {
                _timer.Stop();                
                isKingAlive();
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


        public void isKingAlive()
        {            
            bool mort = false;
            int x = _time.Seconds;

            if (x == 0)
            {
                mort = true;
                MessageBox.Show("Le roi est mort");
            }
            else if (x == 4)
                mort = false;
        }
    }
}
