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

namespace Tamagochi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Area> arrayAreas = new List<Area>();
        Area areaKnihgt;
        Area areaArcher;
        Image imageKnight = new Image();
        Image imageSoldier = new Image();
        Image imageArcher = new Image();
        Image imageRabbit = new Image();
        Image imageBoar = new Image();
        public MainWindow()
        {
            InitializeComponent();
            var characterFactory = new CharacterFactory();
            areaKnihgt = new Area();
            areaKnihgt.SetInitialArea();
            arrayAreas.Add(areaKnihgt);
            

            Area areaKPrincess = new Area();
            areaKPrincess.SetInitialArea();
            areaKPrincess.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaKPrincess);

            Area areaSoldier = new Area();
            areaSoldier.SetInitialArea();
            areaSoldier.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaSoldier);

            areaArcher = new Area();
            areaArcher.SetInitialArea();
            areaArcher.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaArcher);

            Area areaRabbit = new Area();
            areaRabbit.SetInitialArea();
            areaRabbit.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaRabbit);

            Area areaBoar = new Area();
            areaBoar.SetInitialArea();
            areaBoar.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaBoar);

            var characters = new List<ACharacter>(){
               
                characterFactory.CreateCharacter<Knight>(areaKnihgt, "Aragorn"),
                characterFactory.CreateCharacter<Princess>(areaKPrincess,"Arwen"),
                characterFactory.CreateCharacter<Soldier>(areaSoldier,"Gimli"),
                characterFactory.CreateCharacter<Archer>(areaArcher,"Legolas"),                
                characterFactory.CreateCharacter<Soldier>(areaRabbit,"Buggs Bunny"),
                characterFactory.CreateCharacter<Soldier>(areaBoar,"Pumba")
            };
            string a=System.IO.Directory.GetCurrentDirectory();
            CreateImage(imageKnight,areaKnihgt, Directory.GetCurrentDirectory()+@".\..\..\Images\knight.gif");
            CreateImage(imageSoldier, areaSoldier, Directory.GetCurrentDirectory() + @"\..\..\Images\soldier.gif");
            CreateImage(imageArcher, areaArcher, Directory.GetCurrentDirectory() + @"\..\..\Images\archer.gif");
            CreateImage(imageRabbit, areaRabbit, Directory.GetCurrentDirectory() + @"\..\..\Images\rabbit.gif");
            CreateImage(imageBoar, areaBoar, Directory.GetCurrentDirectory() + @"\..\..\Images\boar.gif");

        }

        public void CreateImage(Image image, Area area,String imgUrl)
        {
            image.Width = 50;
            image.Height = 50;
            ImageSource imageSource = new BitmapImage(new Uri(imgUrl));
            image.Source = imageSource;
            Grid.SetRow(image, area.Row);
            Grid.SetColumn(image, area.Column);
            grid.Children.Add(image);
        }

        public void Move(Area area,int row,int column)
        {
            area.Row += 1;
            area.Column += 1;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            grid.Children.Remove(imageKnight);
            grid.Children.Remove(imageArcher);
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

            CreateImage(imageKnight, areaKnihgt, Directory.GetCurrentDirectory() + @".\..\..\Images\knight.gif");
            CreateImage(imageArcher, areaArcher, Directory.GetCurrentDirectory() + @".\..\..\Images\archer.gif");
        }
       

     
       
    }
}
