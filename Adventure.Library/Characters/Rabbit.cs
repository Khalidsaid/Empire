using Adventure.Library.Behaviors.Fighting;
using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Organisations;

namespace Adventure.Library.Characters
{
    public class Rabbit : ACharacter
    {
        public Rabbit(Organisation organisation, string name)
            : base(organisation, name)
        {
            this.FightBehavior = new FightWithAx();
            this.SoundBehavior = new Speak();
        }

        public Rabbit(Area area, string name)
            : base(area, name)
        {
            this.FightBehavior = new FightWithAx();
            this.SoundBehavior = new Speak();
        }

        public override string Class
        {
            get { return "Rabbit"; }
        }
    }
}
