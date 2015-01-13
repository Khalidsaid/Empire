using Adventure.Library.Behaviors.Sounds;
using Adventure.Library.Organisations;

namespace Adventure.Library.Characters
{
    public class Princess : ACharacter
    {
        public Princess(Organisation organisation, string name)
            : base(organisation, name)
        {
            this.SoundBehavior = new PrincessSpeak();
        }

        public Princess(Area area, string name)
            : base(area, name)
        {
            this.SoundBehavior = new PrincessSpeak();
        }

        public override string Class
        {
            get { return "Princess"; }
        }
    }
}
