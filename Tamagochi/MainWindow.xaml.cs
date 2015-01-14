﻿using Adventure.Library.Characters;
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
        Area areaSoldier;
        Area areaKPrincess;
        Area areaElephant1;
        Area areaElephant2;
        Area areaElephant3;
        Image imageKnight = new Image();
        Image imageSoldier = new Image();
        Image imageArcher = new Image();
        Image imageElephant1 = new Image();
        Image imageElephant2 = new Image();
        Image imageElephant3 = new Image();
        public MainWindow()
        {
            InitializeComponent();
            var characterFactory = new CharacterFactory();
            areaKnihgt = new Area();
            areaKnihgt.SetInitialArea();
            arrayAreas.Add(areaKnihgt);
            

            areaKPrincess = new Area();
            areaKPrincess.SetInitialArea();
            areaKPrincess.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaKPrincess);

            areaSoldier = new Area();
            areaSoldier.SetInitialArea();
            areaSoldier.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaSoldier);

            areaArcher = new Area();
            areaArcher.SetInitialArea();
            areaArcher.ModifyAreaIfExist(arrayAreas);
            arrayAreas.Add(areaArcher);

            
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

            var characters = new List<ACharacter>(){
               
                characterFactory.CreateCharacter<Knight>(areaKnihgt, "Aragorn"),
                characterFactory.CreateCharacter<Princess>(areaKPrincess,"Arwen"),
                characterFactory.CreateCharacter<Soldier>(areaSoldier,"Gimli"),
                characterFactory.CreateCharacter<Archer>(areaArcher,"Legolas"),
                characterFactory.CreateCharacter<Archer>(areaElephant1,"Elephant1"),
                characterFactory.CreateCharacter<Archer>(areaElephant2,"Elephant2"),
                characterFactory.CreateCharacter<Archer>(areaElephant3,"Elephant3")
       
            };
            string a=System.IO.Directory.GetCurrentDirectory();
            CreateImage(imageKnight,areaKnihgt, Directory.GetCurrentDirectory()+@".\..\..\Images\knight.gif");
            CreateImage(imageSoldier, areaSoldier, Directory.GetCurrentDirectory() + @"\..\..\Images\soldier.gif");
            CreateImage(imageArcher, areaArcher, Directory.GetCurrentDirectory() + @"\..\..\Images\archer.gif");
            CreateImage(imageElephant1, areaElephant1, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageElephant2, areaElephant2, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");
            CreateImage(imageElephant3, areaElephant3, Directory.GetCurrentDirectory() + @"\..\..\Images\elephant.gif");

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
        }
       

     
       
    }
}
