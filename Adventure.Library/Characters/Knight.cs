using Adventure.Library.Behaviors.Fighting;
using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Organisations;

namespace Adventure.Library.Characters
{
    public class Knight : ACharacter
    {
        public Knight(Organisation organisation, string name)
            : base(organisation, name)
        {
            this.FightBehavior = new FightOnHorse();
            this.SoundBehavior = new Gallop();
        }

        public Knight(Area area, string name)
            : base(area, name)
        {
            this.FightBehavior = new FightOnHorse();
            this.SoundBehavior = new Gallop();
        }

        public override string Class
        {
            get { return "Knight"; }
        }
    }
}
