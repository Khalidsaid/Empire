using Adventure.Library.Organisations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Library.Characters.Factories
{
    public enum CharacterClass { Knight, Archer, Soldier, Princess, Rabbit, Boar }

    public class CharacterFactory
    {
        /// <summary>
        /// Create a new ACharater with new() constraint
        /// new T() then set properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="organisation"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public T CreateCharacterWithNewConstraint<T>(Organisation organisation, string name) where T : ACharacter, new()
        {
            var character = new T();
            character.Organisation = organisation;
            character.Name = name;
            return character;
        }

        /// <summary>
        /// Create une ACharacter
        /// Compare typeof(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="organisation"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ACharacter CreateCharacter<T>(Organisation organisation, string name) where T : ACharacter
        {
            if (typeof(T) == typeof(Knight))
                return new Knight(organisation, name);
            if (typeof(T) == typeof(Archer))
                return new Archer(organisation, name);
            if (typeof(T) == typeof(Soldier))
                return new Soldier(organisation, name);
            if (typeof(T) == typeof(Princess))
                return new Princess(organisation, name);
            if (typeof(T) == typeof(Rabbit))
                return new Princess(organisation, name); 
            if (typeof(T) == typeof(Boar))
                return new Princess(organisation, name);

            throw new ArgumentException();
        }

        /// <summary>
        /// Create ACharacter with switch
        /// </summary>
        /// <param name="characterClass">Type of derived ACharacter class</param>
        /// <param name="organisation"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ACharacter CreateCharacter(CharacterClass characterClass, Organisation organisation, string name)
        {
            switch(characterClass)
            {
                case CharacterClass.Archer :
                    return new Archer(organisation, name);
                case CharacterClass.Knight:
                    return new Knight(organisation, name);
                case CharacterClass.Soldier:
                    return new Soldier(organisation, name);
                case CharacterClass.Princess:
                    return new Princess(organisation, name);
                case CharacterClass.Rabbit:
                    return new Rabbit(organisation, name);
                case CharacterClass.Boar:
                    return new Rabbit(organisation, name);
                default: throw new ArgumentException();
            }
        }


       /// <summary>
       /// Create une ACharacter
       /// Compare typeof(T)
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="area"></param>
       /// <param name="name"></param>
       /// <returns></returns>
        public ACharacter CreateCharacter<T>(Area area, string name) where T : ACharacter
        {
            if (typeof(T) == typeof(Knight))
                return new Knight(area, name);
            if (typeof(T) == typeof(Archer))
                return new Archer(area, name);
            if (typeof(T) == typeof(Soldier))
                return new Soldier(area, name);
            if (typeof(T) == typeof(Princess))
                return new Princess(area, name);
            if (typeof(T) == typeof(Rabbit))
                return new Princess(area, name);
            if (typeof(T) == typeof(Boar))
                return new Princess(area, name);

            throw new ArgumentException();
        }
    }
}
