using Adventure.Library.Behaviors.Fighting;
using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Organisations;

namespace Adventure.Library.Characters
{
    public class Soldier : ACharacter
    {
        public Soldier(Organisation organisation, string name)
            : base(organisation, name)
        {
            this.FightBehavior = new FightWithAx();
            this.SoundBehavior = new Speak();
        }

        public Soldier(Area area, string name)
            : base(area, name)
        {
            this.FightBehavior = new FightWithAx();
            this.SoundBehavior = new Speak();
        }

        public override string Class
        {
            get { return "Soldier"; }
        }
    }
}
