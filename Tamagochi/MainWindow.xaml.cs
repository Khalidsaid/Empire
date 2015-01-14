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
        public MainWindow()
        {
            InitializeComponent();
            var characterFactory = new CharacterFactory();
            Area areaKnihgt = new Area();
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

            Area areaArcher = new Area();
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
            CreateImage(areaKnihgt, Directory.GetCurrentDirectory()+@".\..\..\Images\knight.gif");
            CreateImage(areaSoldier, Directory.GetCurrentDirectory() + @"\..\..\Images\soldier.gif");
            CreateImage(areaArcher, Directory.GetCurrentDirectory() + @"\..\..\Images\archer.gif");

        }

        public void CreateImage(Area area,String imgUrl)
        {
            Image image = new Image();
            image.Width = 50;
            image.Height = 50;
            ImageSource imageSource = new BitmapImage(new Uri(imgUrl));
            image.Source = imageSource;
            Grid.SetRow(image, area.Row);
            Grid.SetColumn(image, area.Column);
            grid.Children.Add(image);
        }
    }
}
