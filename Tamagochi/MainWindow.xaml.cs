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

namespace Tamagochi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var characterFactory = new CharacterFactory();

            var characters = new List<ACharacter>(){
                characterFactory.CreateCharacter<Knight>(new Area(1,1), "Aragorn"),
                characterFactory.CreateCharacter<Princess>(new Area(1,2),"Arwen"),
                characterFactory.CreateCharacter<Soldier>(new Area(1,3),"Gimli"),
                characterFactory.CreateCharacter<Archer>(new Area(1,4),"Legolas")
            };
        }
    }
}
