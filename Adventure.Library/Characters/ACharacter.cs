using Adventure.Library.Behaviors.Fighting;
using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Observers;
using Adventure.Library.Organisations;
using System;

namespace Adventure.Library.Characters
{
    public abstract class ACharacter : IObserver
    {
        public string Name { get; set; }
        public abstract string Class { get; }
        public OrganisationState OrganisationState { get; private set; }
        public Organisation Organisation { get; set; }
        public Area Area { get; set; }

        public AFightBehavior FightBehavior { get; set; }
        public ASoundBehavior SoundBehavior { get; set; }


        protected ACharacter(Organisation organisation, string name)
        {
            this.Organisation = organisation;
            this.Name = name;
        }
        protected ACharacter(Area area, string name)
        {
            this.Area = area;
            this.Name = name;
        }

        public virtual string Fight()
        {
            return this.FightBehavior == null ? "I don't know how to fight :( ..." : this.FightBehavior.Execute();
        }

        public virtual string Sound()
        {
            return this.SoundBehavior == null ? "..." : this.SoundBehavior.Execute();
        }


        public override string ToString()
        {
            return String.Format("My name is {0}", this.Name)
                + Environment.NewLine
                + String.Format("I'm a {0}", this.Class)
                + Environment.NewLine
                + String.Format("Fight : {0}", this.Fight())
                + Environment.NewLine
                + String.Format("Sound : {0}", this.Sound());
        }


        public void Update()
        {
            this.OrganisationState = Organisation.State;
        }
    }
}
