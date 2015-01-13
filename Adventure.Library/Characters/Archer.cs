using Adventure.Library.Behaviors.Fighting;
using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Organisations;

namespace Adventure.Library.Characters
{
    public class Archer : ACharacter
    {
        public Archer(Organisation organisation, string name)
            : base(organisation, name)
        {
            this.FightBehavior = new FightWithBow();
            this.SoundBehavior = new Cry();
        }

        public Archer(Area area, string name)
            : base(area, name)
        {
            this.FightBehavior = new FightWithBow();
            this.SoundBehavior = new Cry();
        }

        public override string Class
        {
            get { return "Archer"; }
        }
    }
}
