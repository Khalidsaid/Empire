using Adventure.Library.Gameboards;
using Adventure.Library.Gameboards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Library.Characters;
using Adventure.Library.Characters.Factories;

namespace Adventure.Library.Games
{
    public class GameEnvironment
    {
        public IGameboard CreateGameboard(IGameboardFactory gameboardFactory, int rowCount = 0, int columnCount = 0)
        {
            return gameboardFactory.CreateGameboard(rowCount, columnCount);
        }

        public void CreateGame(CharacterFactory charactereFactory, Area areaKnihgt, Area areaSoldier, Area areaArcher, Area areaKing, Area areaElephant1, Area areaElephant2, Area areaElephant3,List<Area> arrayAreas, List<Area> arrayAreasArmee, List<Area> arrayAreasElephant)
        {
            var characterFactory = new CharacterFactory();
            areaKnihgt.SetInitialArea();
            arrayAreas.Add(areaKnihgt);

            var characters = new List<ACharacter>(){
               
                characterFactory.CreateCharacter<Knight>(areaKnihgt, "Aragorn"),
                characterFactory.CreateCharacter<Soldier>(areaSoldier,"Gimli"),
                characterFactory.CreateCharacter<Archer>(areaArcher,"Legolas"),
                characterFactory.CreateCharacter<King>(areaKing,"Leonidas"),
                characterFactory.CreateCharacter<Elephant>(areaElephant1,"Elephant1"),
                characterFactory.CreateCharacter<Elephant>(areaElephant2,"Elephant2"),
                characterFactory.CreateCharacter<Elephant>(areaElephant3,"Elephant3")
            };
            foreach (var c in characters)
            {
                if (c.Class == "Knight")
                {
                    arrayAreasArmee.Add(c.Area);
                    continue;
                }
                c.Area.SetInitialArea();
                c.Area.ModifyAreaIfExist(arrayAreas);
                arrayAreas.Add(c.Area);
                if (c.Class == "Elephant")
                    arrayAreasElephant.Add(c.Area);
                else if (c.Class != "King")
                    arrayAreasArmee.Add(c.Area);
            }
        }

        public int SetObjectif()
        {
            Random random = new Random();
            int objectif = random.Next(1, 3);
            return objectif;
        }
    }
}
