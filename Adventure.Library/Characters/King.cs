using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Organisations;

namespace Adventure.Library.Characters
{
    public class King : ACharacter
    {
        public King(Organisation organisation, string name)
            : base(organisation, name)
        {
            this.SoundBehavior = new KingSpeak();
        }

        public King(Area area, string name)
            : base(area, name)
        {
            this.SoundBehavior = new KingSpeak();
        }

        public override string Class
        {
            get { return "King"; }
        }
    }
}
